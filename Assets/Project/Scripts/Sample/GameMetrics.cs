using UnityEngine;

namespace LondonPlatform.Core
{
    [CreateAssetMenu(menuName = "GameMetrics")]
    public class GameMetrics : ScriptableObject
    {
        
        public GameMetrics Global => GameController.Metrics;

        [field: SerializeField]
        public float playerSpeed { get; private set; }        
        
    }
}