using System;
using System.Collections.Generic;
using Player;

namespace GameController
{
    public class LapCounterController
    {
        public Action<PlayerView, int> OnLapPassed;
        
        private readonly LapPartCounterController _lapPartCounterController;

        private List<PlayerView> _playerViews = new();
        private Dictionary<PlayerView, int> _playerLapParts = new();
        
        LapCounterController(
            LapPartCounterController lapPartCounterController)
        {
            _lapPartCounterController = lapPartCounterController;
        }

        public void SetUpLapCounterController()
        {
            _playerViews = _lapPartCounterController.SetUpPlayers();
            _lapPartCounterController.OnLapPass += AddLap;
            foreach (var view in _playerViews)
            {
                _playerLapParts.Add(view, 0);
            }
        }

        private void AddLap(PlayerView playerView)
        {
            _playerLapParts[playerView]++;
            OnLapPassed?.Invoke(playerView, _playerLapParts[playerView]);
        }

        public int GetPlayerLap(PlayerView playerView)
        {
            return _playerLapParts[playerView];
            
        }
    }
}