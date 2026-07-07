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
        private readonly TimerController _timerController;
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
            TimerController timerController,
            LapCounterController lapCounterController,
            GameUIWindowController gameUIWindowController,
            PlayerController playerController,
            GameConfig gameConfig,
            IUIService uiService,
            GridController gridController)
        {
            _timerController = timerController;
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
            if (playerCount > 1)
            {
                _lapCounterController.OnLapPassed += CheckLaps;
            }
            else
            {
                _timerController.SetTime(_gameConfig.AddSeconds,  _gameConfig.StartSeconds);
                _timerController.ActiveTimer(true);
                _playerController.GetPlayerViews()[0].OnTriggerPass += _timerController.AddTime;
                _timerController.OnTimeLeft += () =>
                {
                    SetWinner(_playerController.GetPlayerViews()[0], _lapCounterController.GetPlayerLap(_playerController.GetPlayerViews()[0]).ToString());
                };
            }
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
                SetWinner(playerView, " is win");
            }
        }

        private void SetWinner(PlayerView playerView, string winText)
        {
            Debug.Log(playerView.Type + winText);
            string wintext = playerView.Type + winText;
            _uiWinWindowView.WinText.text = wintext;
            _uiService.Show<UIWinWindowView>();
            _uiService.Hide<GameUIWindowView>();
        }
    }
}