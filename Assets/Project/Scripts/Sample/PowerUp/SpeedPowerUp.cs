using System;
using UnityEngine;

namespace LondonPlatform.Core
{
    public class SpeedPowerUp : MonoBehaviour
    {
        public static event Action OnTakeSpeedPowerUp;
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                OnTakeSpeedPowerUp?.Invoke(); 
                gameObject.SetActive(false);
            }
        }
    }
}