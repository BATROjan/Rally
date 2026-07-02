using GameController;
using UI.UISelectWindow;

namespace UI.UIStartWindow
{
    public class UIStartWindowController
    {
        private readonly IUIService _uiService;

        private UIStartWindowView _uiStartWindow;

        public UIStartWindowController(
            IUIService uiService)
        {
            _uiService = uiService;
            _uiStartWindow = _uiService.Get<UIStartWindowView>();
            
            _uiStartWindow.ShowAction += Show;
            _uiStartWindow.HideAction += UnSubscribeButtons;

            _uiService.Show<UIStartWindowView>();
        }

        private void UnSubscribeButtons()
        {
            _uiStartWindow.Buttons[0].OnClick -= ShowSelectWindow;
        }

        private void Show()
        {
            _uiStartWindow.Buttons[0].OnClick += ShowSelectWindow;
        }

        private void ShowSelectWindow()
        {
            _uiService.Hide<UIStartWindowView>();
            _uiService.Show<UISelectWindowView>();
        }
    }
}