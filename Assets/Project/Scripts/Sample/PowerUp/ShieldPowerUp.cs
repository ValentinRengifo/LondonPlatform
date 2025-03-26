using System;
using UnityEngine;

namespace LondonPlatform.Core
{
    public class ShieldPowerUp : MonoBehaviour
    {
        public static event Action OnTakeShieldPowerUp;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                OnTakeShieldPowerUp?.Invoke(); 
                gameObject.SetActive(false);
            }
        }
    }
}