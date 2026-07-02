using System;
using System.Collections.Generic;
using Player;
using UnityEngine;

namespace UI.GameUIWindow
{
    [CreateAssetMenu(fileName = "PlayerTooltipConfig", menuName = "Configs/PlayerTooltipConfig")]
    
    public class PlayerTooltipConfig : ScriptableObject
    {
        [SerializeField] private TooltipModel[] tooltipModel;

        private Dictionary<PlayerType, TooltipModel> _tooltipModels = new();

        private bool _isInit;

        public TooltipModel GetModel(PlayerType type)
        {
            if (!_isInit || _tooltipModels.Count != tooltipModel.Length)
            {
                Init();
            }

            if (_tooltipModels.TryGetValue(type, out var playerModel))
            {
                return playerModel;
            }
            throw new Exception($"{nameof(type)}: {type} doesn't contains in dictionary");
        }

        public void Init()
        {
            foreach (var model in tooltipModel)
            {
                if (!_tooltipModels.TryAdd(model.playerType, model))
                {
                    Debug.LogError($"{model.playerType} doesn't add to dictionary");
                }
            }
            _isInit = true;
        }
    }
    
    [Serializable]
    public struct TooltipModel
    {
        public PlayerType playerType;
        public Sprite sprite;
        public Color color;
        public Vector3 position;
        public Vector3 rotation;
        public TextAnchor textAnchor;
    }
}