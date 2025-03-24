using System;
using LondonPlatform.Core.Project.Scripts.Sample;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;


namespace LondonPlatform.Core
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D playerRigidbody2D;
        [SerializeField] private GameObject SpawnPoint;
        [SerializeField] private float movementSpeed ;
        [SerializeField] private float jumpForce;

        [SerializeField] private bool _grounded;
        [SerializeField] private bool _canMove = true;

        public static event Action DeathEvent;
        
        private void Start()
        {
            playerRigidbody2D = GetComponent<Rigidbody2D>();
        }


        private void FixedUpdate()
        {
            if (_canMove)
            {
                playerRigidbody2D.linearVelocity = new Vector2(movementSpeed, playerRigidbody2D.linearVelocity.y);
            }
        }


        public void OnCollisionEnter2D(Collision2D other)
        {
            CheckIfGrounded(other);
            CheckIfTrapped(other);
        }

        private void CheckIfTrapped(Collision2D other)
        {
            if (other.gameObject.CompareTag("Traps"))
            {
                Debug.Log("Trapped");
                _canMove = false;
                DeathEvent?.Invoke();
                
                RespawnPlayer();
            }
        }

        private void RespawnPlayer()
        {
            Vector3 position = SpawnPoint.transform.position;
            gameObject.transform.position = position;
            _canMove = true;
        }

        private void CheckIfGrounded(Collision2D other)
        {
            if (other.gameObject.CompareTag("Ground"))
            {
                _grounded = true;
            }
        }


        public void OnJump(InputAction.CallbackContext context)
        {
            if (context.performed && _grounded)
            {
                _grounded = false;
                playerRigidbody2D.linearVelocity = new Vector2(playerRigidbody2D.linearVelocity.x, jumpForce);
            }
        }
    }
}