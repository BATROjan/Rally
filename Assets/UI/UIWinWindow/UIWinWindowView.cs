using UnityEngine;
using UnityEngine.UI;

namespace UI.UIWinWindow
{
    public class UIWinWindowView : UIWindow
    {
        public UIButton[] Buttons
        {
            get => buttons;
            set => buttons = value;
        }

        public Text WinText
        {
            get => _winText;
            set => _winText = value;
        }

        [SerializeField] private UIButton[] buttons;
        [SerializeField] private Text _winText;
        
        public override void Show()
        {
            ShowAction?.Invoke();
        }

        public override void Hide()
        {
            HideAction?.Invoke();
        }
    }
}