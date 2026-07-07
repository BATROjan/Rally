using UnityEngine;

namespace GameController
{
    [CreateAssetMenu(fileName = "GameConfig", menuName = "Configs/GameConfig")]

    public class GameConfig: ScriptableObject
    {
        public int LapsCount => lapsCount;
        public float AddSeconds => addSeconds;
        public float StartSeconds => startSeconds;

        public bool IsPvE
        {
            get => isPvE;
            set => isPvE = value;
        }
        [SerializeField] private bool isPvE; 
        [SerializeField] private int lapsCount;
        [SerializeField] private float addSeconds;
        [SerializeField] private float startSeconds;
    }
}