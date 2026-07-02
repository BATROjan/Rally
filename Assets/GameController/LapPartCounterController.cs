using System;
using System.Collections.Generic;
using Grid;
using Player;
using UnityEngine;

namespace GameController
{
    public class LapPartCounterController
    {
        public Action<PlayerView> OnLapPass;
        
        private readonly GridConfig _gridConfig;
        private readonly PlayerController _playerController;

        private Dictionary<PlayerView, int> _playerLapParts = new();
        private List<PlayerView> _playerViews = new();
        
        LapPartCounterController(
            GridConfig gridConfig,
            PlayerController playerController)
        {
            _gridConfig = gridConfig;
            _playerController = playerController;
        }

        public List<PlayerView> SetUpPlayers()
        {
         _playerViews = _playerController.GetPlayerViews();
            foreach (var view in _playerViews)
            {
                view.OnTriggerPass += AddLapPart;
                _playerLapParts.Add(view, 0);
            }
            return _playerViews;
        }
        private void AddLapPart(PlayerView playerView, int id)
        {
            id--;
            
            if (_playerLapParts[playerView] == id)
            {
                _playerLapParts[playerView]++;
                if (_playerLapParts[playerView] == _gridConfig.GetGrid(0).TriggerModels.Length)
                {
                    _playerLapParts[playerView] = 0;
                    OnLapPass?.Invoke(playerView);
                }
            }
        }
    }
}