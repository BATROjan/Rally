using System;
using System.Collections.Generic;
using UnityEngine;

namespace Grid
{
    [CreateAssetMenu(fileName = "GridConfig", menuName = "Configs/GridConfig")]
    public class GridConfig : ScriptableObject
    {
        [SerializeField] private GridModel[] gridModels;

        private Dictionary<int, GridModel> _dictionaryOfLevels = new();
        private bool _isInit;

        public GridModel GetGrid(int level)
        {
            if (!_isInit)
            {
                Init();
            }

            if (_dictionaryOfLevels.TryGetValue(level, out var levelModel))
            {
                return levelModel;
            }
            throw new Exception($"{nameof(level)}: {level} doesn't contains in dictionary");
        }
        public void Init()
        {
            int lvl = 0;
            
            foreach (var gridModel in gridModels)
            {
                if (!_dictionaryOfLevels.TryAdd(lvl++, gridModel))
                {
                    Debug.LogError($"{lvl} doesn't add to dictionary");
                }
            }
            _isInit = true;
        }
    }
    [Serializable]
    public struct GridModel
    {
        public Vector3[] PlayersPositions;
        public Vector3[] PlayersRotations;
        public GameObject Prefab;
    }
}