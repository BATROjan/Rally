using System;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "Configs/PlayerConfig")]
    
    public class PlayerConfig : ScriptableObject
    {
        [SerializeField] private PlayerModel[] playerModel;

        private Dictionary<PlayerType, PlayerModel> _playerDictionary = new();

        private bool _isInit;

        public PlayerModel GetPlayer(PlayerType type)
        {
            if (!_isInit)
            {
                Init();
            }

            if (_playerDictionary.TryGetValue(type, out var playerModel))
            {
                return playerModel;
            }
            throw new Exception($"{nameof(type)}: {type} doesn't contains in dictionary");
        }
        
        public  List<PlayerModel> GetPlayeByCount(int count)
        {
            if (!_isInit)
            {
                Init();
            } 
            
            List<PlayerModel>  playerModels = new List<PlayerModel>();
            int i = 0;
            
            foreach (var model in _playerDictionary.Values)
            {
                if (i < count)
                {
                    playerModels.Add(model);
                    i++;
                }
            }
            return playerModels;
        }

        public void Init()
        {
            foreach (var model in playerModel)
            {
                if (!_playerDictionary.TryAdd(model.playerType, model))
                {
                    Debug.LogError($"{model.playerType} doesn't add to dictionary");
                }
            }
            _isInit = true;
        }
    }
    
    [Serializable]
    public struct PlayerModel
    {
        public PlayerType playerType;
        public Sprite sprite;
    }

    public enum PlayerType
    {
        Red,
        Green,
        White,
        Blue
    }
}