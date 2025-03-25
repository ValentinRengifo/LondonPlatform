using UnityEngine;

namespace LondonPlatform.Core
{
    public class GameController : MonoBehaviour
    {
        private static GameMetrics gameMetrics;
        public static GameMetrics Metrics
        {
            get
            {
                if (!gameMetrics)
                    gameMetrics = Resources.Load<GameMetrics>("GameMetrics");

                return gameMetrics;
            }
        }
    }
}