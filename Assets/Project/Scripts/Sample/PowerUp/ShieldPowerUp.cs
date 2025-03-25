using System;
using UnityEngine;

namespace LondonPlatform.Core
{
    public class ShieldPowerUp : MonoBehaviour
    {
        public static event Action OnTakeShieldPowerUp;
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                OnTakeShieldPowerUp?.Invoke();
                Destroy(gameObject);
            }
        }
    }
}