using UnityEngine;

namespace UI.UISelectWindow
{
    public class UISelectWindowView : UIWindow
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