using UnityEngine;

namespace GameController
{
    [CreateAssetMenu(fileName = "GameConfig", menuName = "Configs/GameConfig")]

    public class GameConfig: ScriptableObject
    {
        public int LapsCount => lapsCount;

        public bool IsPvE
        {
            get => isPvE;
            set => isPvE = value;
        }
        [SerializeField] private bool isPvE; 
        [SerializeField] private int lapsCount;
    }
}