namespace UI.GameUIWindow
{
    public class GameUIWindowController
    {
        private readonly IUIService _uiService;

        private GameUIWindowView _gameUIWindowView;

        public GameUIWindowController(
            IUIService uiService)
        {
            _uiService = uiService;
            _gameUIWindowView = _uiService.Get<GameUIWindowView>();
            
            _gameUIWindowView.ShowAction += Show;
            _gameUIWindowView.HideAction += UnSubscribeButtons;
        }

        private void UnSubscribeButtons()
        {
        }

        private void Show()
        {
        }
    }
}