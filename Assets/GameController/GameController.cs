using Grid;
using Player;
using UI;
using UI.GameUIWindow;
using UI.UIWinWindow;
using UnityEngine;

namespace GameController
{
    public class GameController
    {
        private readonly LapCounterController _lapCounterController;
        private readonly GameUIWindowController _gameUIWindowController;
        private readonly PlayerController _playerController;
        private readonly GameConfig _gameConfig;
        private readonly IUIService _uiService;
        private readonly GridController _gridController;
        
        private int playerCount;
        private GridModel _gridModel;
        
        private UIWinWindowView _uiWinWindowView;
        public GameController(
            LapCounterController lapCounterController,
            GameUIWindowController gameUIWindowController,
            PlayerController playerController,
            GameConfig gameConfig,
            IUIService uiService,
            GridController gridController)
        {
            _lapCounterController = lapCounterController;
            _gameUIWindowController = gameUIWindowController;
            _playerController = playerController;
            _gameConfig = gameConfig;
            _uiService = uiService;
            _gridController = gridController;
            
            _uiWinWindowView = _uiService.Get<UIWinWindowView>();
        }

        public void StartGame()
        {
            _gridController.SpawnGrid();
            _gridModel = _gridController.GetGrid(0); //поменять если будет несколько карт
            _playerController.SpawnByCount(_gridModel.PlayersPositions, _gridModel.PlayersRotations, playerCount);
            
            _lapCounterController.SetUpLapCounterController();
            _lapCounterController.OnLapPassed += CheckLaps;
            _lapCounterController.OnLapPassed += _gameUIWindowController.UpdateText;
        }

        public void SelectPlayerCount(int  count)
        {
            playerCount = count;
        }

        private void CheckLaps(PlayerView playerView, int lapCount)
        {
            if (lapCount >= _gameConfig.LapsCount)
            {
                Debug.Log(playerView.Type +" is win");
                string wintext = playerView.Type + " is win";
                _uiWinWindowView.WinText.text = wintext;
                _uiService.Show<UIWinWindowView>();
                _uiService.Hide<GameUIWindowView>();
            }
        }
    }
}