using System;
using System.Collections.Generic;
using UnityEngine;

namespace LondonPlatform.Core
{
    public class RespawnPowerUp : MonoBehaviour
    {
        [SerializeField] private List<GameObject> powerUps;

        private void OnEnable()
        {
            Player.DeathEvent += RespawnPowerUps;

        }
        private void OnDisable()
        {
            Player.DeathEvent -= RespawnPowerUps;
        }

        private void RespawnPowerUps()
        {
            foreach (var PowerUp in powerUps)
            {
                PowerUp.SetActive(true);
            }
        }
    }
}