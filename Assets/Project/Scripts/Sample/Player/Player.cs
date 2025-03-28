using System;
using System.Collections;
using System.Collections.Generic;
using LondonPlatform.Core.Project.Scripts.Sample;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;


namespace LondonPlatform.Core
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private List<GameObject> DestroyedTraps;
        
        [SerializeField] private Rigidbody2D playerRigidbody2D;
        [SerializeField] private GameObject SpawnPoint;
        [SerializeField] private float movementSpeed;
        [SerializeField] private float Acceleration;
        [SerializeField] private float Deceleration;
        [SerializeField] private float jumpForce;
        [SerializeField] private float SpeedBonusTime;
        [SerializeField] private float SpeedBonusAmount;
        [SerializeField] private float JumpBonusTime;
        [SerializeField] private float JumpBonusAmount;
        [SerializeField] private float CiterneJumpForce;
        [SerializeField] private bool _grounded;
        [SerializeField] private bool _canMove = true;
        
        [field : SerializeField] public bool gotShield { get; private set; }
        [field : SerializeField] public bool gotSpeedPowerUp { get; private set; }
        [field : SerializeField] public bool gotJumpPowerUp { get; private set; }
        
        public static event Action DeathEvent;

        private void OnEnable()
        {
            ShieldPowerUp.OnTakeShieldPowerUp += ShieldUp;
            SpeedPowerUp.OnTakeSpeedPowerUp += SpeedUp;
            JumpBoostPowerUp.OnTakeJumpBoostPowerUp += JumpUp;
            Citerne.OnCiterneUp += CiterneUp;
        }


        private void OnDisable()
        {
            ShieldPowerUp.OnTakeShieldPowerUp -= ShieldUp;
            SpeedPowerUp.OnTakeSpeedPowerUp -= SpeedUp;
            JumpBoostPowerUp.OnTakeJumpBoostPowerUp -= JumpUp;
            Citerne.OnCiterneUp -= CiterneUp;

        }
        private void CiterneUp()
        {
            Debug.Log("CiterneUp");
            playerRigidbody2D.AddForce(Vector2.up * CiterneJumpForce, ForceMode2D.Impulse);
        }
        
        private void JumpUp()
        {
            gotJumpPowerUp = true;
            jumpForce += JumpBonusAmount;
            StartCoroutine(JumpBoostPowerUpDuration());
        }

        private IEnumerator JumpBoostPowerUpDuration()
        {
            yield return new WaitForSeconds(JumpBonusTime); 
            if(gotJumpPowerUp) jumpForce -= JumpBonusAmount;
            gotJumpPowerUp = false;
            
        }

        private void SpeedUp()
        {
            gotSpeedPowerUp = true;
            movementSpeed += SpeedBonusAmount;
            StartCoroutine(SpeedPowerUpDuration());
        }

        private IEnumerator SpeedPowerUpDuration()
        {
            yield return new WaitForSeconds(SpeedBonusTime); 
            if(gotSpeedPowerUp) movementSpeed -= SpeedBonusAmount;
            gotSpeedPowerUp = false;
        }
        
        

        private void ShieldUp()
        {
            gotShield = true;
        }


        private void Start()
        {
            playerRigidbody2D = GetComponent<Rigidbody2D>();
        }


        private void FixedUpdate()
        {
            if (_canMove)
            {
                if (playerRigidbody2D.linearVelocity.x < movementSpeed)
                {
                    playerRigidbody2D.AddForce(Vector2.right * Acceleration);
                }

                if (playerRigidbody2D.linearVelocity.x > movementSpeed)
                {
                    playerRigidbody2D.AddForce(Vector2.left * Deceleration);
                }
                //playerRigidbody2D.linearVelocity = new Vector2(movementSpeed, playerRigidbody2D.linearVelocity.y);
            }
        }


        public void OnCollisionEnter2D(Collision2D other)
        {
            CheckIfTrapped(other);
        }

        private void CheckIfTrapped(Collision2D other)
        {
            if (other.gameObject.CompareTag("Traps") && !gotShield)
            {
                Debug.Log("Trapped");
                _canMove = false;
                DeathEvent?.Invoke();
                ResetAllPowerUps();
                RespawnPlayer();
            }
            else if (other.gameObject.CompareTag("Traps") && gotShield)
            {
                other.gameObject.SetActive(false);
                DestroyedTraps.Add(other.gameObject);
                gotShield = false;
            }
        }

        private void ResetAllPowerUps()
        {
            if (gotSpeedPowerUp)
            {
                movementSpeed -= SpeedBonusAmount;
                gotSpeedPowerUp = false;
            }

            if (gotJumpPowerUp)
            {
                gotJumpPowerUp = false;
                jumpForce -= JumpBonusAmount;
            }
        }

        private void RespawnPlayer()
        {
            RespawnTraps();
            Vector3 position = SpawnPoint.transform.position;
            gameObject.transform.position = position;
            _canMove = true;
        }

        private void RespawnTraps()
        {
            foreach (var trapDestroyed in DestroyedTraps)
            {
                trapDestroyed.SetActive(true);
            }
            DestroyedTraps.Clear();
            
        }

        private void OnCollisionStay2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Ground"))
            {
                _grounded = true;
            }
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Ground"))
            {
                _grounded = false;
            }
        }


        public void OnJump(InputAction.CallbackContext context)
        {
            if (context.performed && _grounded)
            {
                _grounded = false;
                playerRigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
        }
    }
}