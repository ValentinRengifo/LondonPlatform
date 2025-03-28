using UnityEngine;
using System;

namespace LondonPlatform.Core
{
    public class JumpBoostPowerUp : MonoBehaviour
    {
        public static event Action OnTakeJumpBoostPowerUp;
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                OnTakeJumpBoostPowerUp?.Invoke(); 
                gameObject.SetActive(false);
            }
        }
    }
}