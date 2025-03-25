using UnityEngine;
using System;

namespace LondonPlatform.Core
{
    public class JumpBoostPowerUp : MonoBehaviour
    {
        public static event Action OnTakeJumpBoostPowerUp;
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                OnTakeJumpBoostPowerUp?.Invoke();
                Destroy(gameObject);
            }
        }
    }
}