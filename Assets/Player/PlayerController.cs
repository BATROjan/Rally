using System.Collections.Generic;

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

        public void SpawnByType(PlayerType type)
        {
            _playerPool.Spawn(_playerConfig.GetPlayer(type).sprite);
        }
        public void SpawnByCount(int count)
        {
            List<PlayerModel> playerModels = _playerConfig.GetPlayeByCount(count);
            foreach (var model in playerModels)
            {
            _playerPool.Spawn(model.sprite);
            }
        }
    }
}