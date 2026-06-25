using UnityEngine;

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
            
            //_uiStartWindow.ShowAction += Show;
            //_uiStartWindow.HideAction += UnSubscribeButtons;

            _uiService.Show<UIStartWindowView>();
        }

        private void UnSubscribeButtons()
        {
            throw new System.NotImplementedException();
        }

        private void Show()
        {
            throw new System.NotImplementedException();
        }
    }
}