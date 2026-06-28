using Grid;
using Player;
using UI;

namespace GameController
{
    public class GameController
    {
        private readonly PlayerController _playerController;
        private readonly GameConfig _gameConfig;
        private readonly IUIService _uiService;
        private readonly GridController _gridController;
        
        private int playerCount;
        
        public GameController(
            PlayerController playerController,
            GameConfig gameConfig,
            IUIService uiService,
            GridController gridController)
        {
            _playerController = playerController;
            _gameConfig = gameConfig;
            _uiService = uiService;
            _gridController = gridController;
        }

        public void StartGame()
        {
            _gridController.SpawnGrid();

            _playerController.SpawnByCount(playerCount);
        }

        public void SelectPlayerCount(int  count)
        {
            playerCount = count;
        }
    }
}