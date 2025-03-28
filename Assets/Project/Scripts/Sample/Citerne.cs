using System;
using UnityEngine;

namespace LondonPlatform.Core
{
    public class Citerne : MonoBehaviour
    {
        public static event Action OnCiterneUp;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                OnCiterneUp?.Invoke();
            }
        }
    }
}