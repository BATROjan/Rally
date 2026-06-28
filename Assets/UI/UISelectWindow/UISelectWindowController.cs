namespace UI.UISelectWindow
{
    public class UISelectWindowController
    {
        private readonly GameController.GameController _gameController;
        private readonly IUIService _uiService;

        private UISelectWindowView _uiSelectWindowView;

        public UISelectWindowController(
            GameController.GameController gameController,
            IUIService uiService)
        {
            _gameController = gameController;
            _uiService = uiService;
            _uiSelectWindowView = _uiService.Get<UISelectWindowView>();
            
            _uiSelectWindowView.ShowAction += Show;
            _uiSelectWindowView.HideAction += UnSubscribeButtons;
        }

        private void UnSubscribeButtons()
        {
            _uiService.Hide<UISelectWindowView>();
            
            foreach (var button in _uiSelectWindowView.Buttons)
            {
                button.OnSelect -= _gameController.SelectPlayerCount;
                button.OnClick -= _gameController.StartGame;
            }
        }

        private void Show()
        {
            foreach (var button in _uiSelectWindowView.Buttons)
            {
                button.OnSelect += _gameController.SelectPlayerCount;
                button.OnClick += _gameController.StartGame;
            }
        }
    }
}