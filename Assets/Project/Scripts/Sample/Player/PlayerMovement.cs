using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;



namespace LondonPlatform.Core
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D playerRigidbody2D;
        
        [SerializeField] private float movementSpeed ;
        [SerializeField] private float jumpForce;

        [SerializeField] private bool _grounded;
        
        private void Start()
        {
            playerRigidbody2D = GetComponent<Rigidbody2D>();
        }


        private void FixedUpdate()
        {
            playerRigidbody2D.linearVelocity = new Vector2(movementSpeed, playerRigidbody2D.linearVelocity.y);
        }


        public void OnCollisionEnter2D(Collision2D other)
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