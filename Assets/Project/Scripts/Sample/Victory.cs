using System;
using UnityEngine;
using UnityEngine.Playables;

namespace LondonPlatform.Core
{
    public class Victory : MonoBehaviour
    {
        public PlayableDirector playableDirector;

        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                if (playableDirector != null)
                {
                    playableDirector.Play();
                }
            }
        }
    }
}