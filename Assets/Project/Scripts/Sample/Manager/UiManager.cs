using System;
using UnityEngine;

namespace LondonPlatform.Core
{
    public class UiManager : MonoBehaviour
    {
        [SerializeField] private Player player;
        [SerializeField] private GameObject shieldPowerUpImage;
        [SerializeField] private GameObject speedPowerUpImage;
        [SerializeField] private GameObject JumpPowerUpImage;
        
        private void Update()
        {
            shieldPowerUpImage.SetActive(player.gotShield);

            speedPowerUpImage.SetActive(player.gotSpeedPowerUp);

            JumpPowerUpImage.SetActive(player.gotJumpPowerUp);
        }
    }
}