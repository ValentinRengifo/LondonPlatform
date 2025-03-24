using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

namespace LondonPlatform.Core.Project.Scripts.Sample
{
    public class DeathCounter : MonoBehaviour
    {
        [SerializeField] private int DeathCount;
        [SerializeField] TextMeshProUGUI DeathCounterText;


        private void OnEnable()
        {
            PlayerMovement.DeathEvent += DeathDetected;
        }

        private void OnDisable()
        {
            PlayerMovement.DeathEvent -= DeathDetected;
        }

        private void Start()
        {
            DeathCounterText.text = $"Total Death : {DeathCount.ToString()}";
        }

        public void DeathDetected()
        {
            DeathCount++;
            RefreshDeathCounter();
        }

        private void RefreshDeathCounter()
        {
            DeathCounterText.text = $"Total Death : {DeathCount.ToString()}";
        }
    }
}