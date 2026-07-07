using UI.UIStartWindow;

namespace UI.UIWinWindow
{
    public class UIWinWindowController
    {
        private readonly IUIService _uiService;
        private UIStartWindowView _uiStartWindow;
        
        UIWinWindowController(
            IUIService uiService)
        {
            _uiService = uiService;
            _uiStartWindow = _uiService.Get<UIStartWindowView>();
            
            _uiStartWindow.ShowAction += Show;
            _uiStartWindow.HideAction += UnSubscribeButtons;
        }

        private void UnSubscribeButtons()
        {
            
        }

        private void Show()
        {
            
            
        }
    }
}