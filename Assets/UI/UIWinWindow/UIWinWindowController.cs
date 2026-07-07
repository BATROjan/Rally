namespace UI.UIWinWindow
{
    public class UIWinWindowController
    {
        private readonly IUIService _uiService;
        private UIWinWindowView _uiWinWindowView;
        
        UIWinWindowController(
            IUIService uiService)
        {
            _uiService = uiService;
            _uiWinWindowView = _uiService.Get<UIWinWindowView>();
            
            _uiWinWindowView.ShowAction += Show;
            _uiWinWindowView.HideAction += UnSubscribeButtons;
        }

        private void UnSubscribeButtons()
        {
            
        }

        private void Show()
        {
            
        }

        public void SetText( string text)
        {
            _uiWinWindowView.WinText.text = text;
        }
    }
}