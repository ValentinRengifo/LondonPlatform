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
            Player.DeathEvent += DeathDetected;
        }

        private void OnDisable()
        {
            Player.DeathEvent -= DeathDetected;
        }

        private void Start()
        {
            DeathCounterText.text = $"x {DeathCount}";
        }

        public void DeathDetected()
        {
            DeathCount++;
            RefreshDeathCounter();
        }

        private void RefreshDeathCounter()
        {
            DeathCounterText.text = $"x {DeathCount}";
        }
    }
}