using System.Collections.Generic;
using Grid;
using UnityEngine;

namespace Player
{
    public class PlayerController
    {
        private readonly PlayerConfig _playerConfig;
        private readonly PlayerView.Pool _playerPool;

        public PlayerController(
            PlayerConfig playerConfig,
            PlayerView.Pool playerPool)
        {
            _playerConfig = playerConfig;
            _playerPool = playerPool;
        }

        public void SpawnByType(Vector3 position, Vector3 rotation, PlayerType type)
        {
            _playerPool.Spawn(_playerConfig.GetPlayer(type).sprite, position, rotation);
        }
        public void SpawnByCount(Vector3[] positions, Vector3 rotation, int count)
        {
            List<PlayerModel> playerModels = _playerConfig.GetPlayeByCount(count);
            int i = 0;
            foreach (var model in playerModels)
            {
            _playerPool.Spawn(model.sprite,  positions[i], rotation);
            i++;
            }
        }
    }
}