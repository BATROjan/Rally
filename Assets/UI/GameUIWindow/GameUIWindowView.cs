using UnityEngine;

namespace UI.GameUIWindow
{
    public class GameUIWindowView : UIWindow
    {
        public UIButton[] Buttons => buttons;
        
        [SerializeField] private UIButton[] buttons;
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