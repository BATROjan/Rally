using System.Collections.Generic;
using Player;
using Terresquall;
using UnityEngine;

namespace UI.GameUIWindow
{
    public class GameUIWindowController
    {
        private readonly PlayerTooltipConfig _playerTooltipConfig;
        private readonly IUIService _uiService;

        private GameUIWindowView _gameUIWindowView;
        private Dictionary<PlayerType, VirtualJoystick> _joysticks = new ();
        private Dictionary<PlayerType, PlayerTooltipView> _playerTooltipViews = new ();

        public GameUIWindowController(
            PlayerTooltipConfig playerTooltipConfig,
            IUIService uiService)
        {
            _playerTooltipConfig = playerTooltipConfig;
            _uiService = uiService;
            _gameUIWindowView = _uiService.Get<GameUIWindowView>();
            
            _gameUIWindowView.ShowAction += Show;
            _gameUIWindowView.HideAction += UnSubscribeButtons;
            foreach (var view in _gameUIWindowView.PlayerTooltipViews)
            {
                _joysticks.Add(view.PlayerType, view.Joystick);
                _playerTooltipViews.Add(view.PlayerType, view);
            }
        }

        private void UnSubscribeButtons()
        {
        }

        private void Show()
        {
        }

        public void UpdateText(PlayerView view, int lapCount)
        {
            _playerTooltipViews[view.Type].PlayerScore.text = lapCount.ToString();
        }

        public void UpdateTimerText(float time)
        {
            _gameUIWindowView.TimerText.text = time.ToString("F2");
        }

        public Dictionary<PlayerType, VirtualJoystick> GetJoysticks()
        {
            return _joysticks;
        }

        public void SetActiveTooltip(PlayerType  playerType)
        {
            _playerTooltipViews[playerType].gameObject.SetActive(true);
        }
    }
}