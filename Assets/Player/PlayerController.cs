using System.Collections.Generic;
using UI.GameUIWindow;
using UnityEngine;
using Zenject;

namespace Player
{
    public class PlayerController
    {
        private readonly GameUIWindowController _gameUIWindowController;
        private readonly PlayerConfig _playerConfig;
        private readonly PlayerView.Pool _playerPool; 
        
        private List<PlayerView> _playerViews = new ();
        public PlayerController(
            GameUIWindowController gameUIWindowController,
            PlayerConfig playerConfig,
            PlayerView.Pool playerPool)
        {
            _gameUIWindowController = gameUIWindowController;
            _playerConfig = playerConfig;
            _playerPool = playerPool;
        }
        public void SpawnByCount(Vector3[] positions, Vector3 rotation, int count)
        {
            List<PlayerModel> playerModels = _playerConfig.GetPlayeByCount(count);
            int i = 0;
            foreach (var model in playerModels)
            {
                var player = _playerPool.Spawn(model.playerType, model.sprite,  positions[i], rotation);
                _playerViews.Add(player);
                player.Joystick = _gameUIWindowController.GetJoysticks()[model.playerType];
                _gameUIWindowController.SetActiveTooltip(player.Type);
                i++;
            }
        }
        public List<PlayerView> GetPlayerViews()
        {
            return _playerViews;
        }
    }
}