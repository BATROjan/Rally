using UnityEngine;

namespace UI.GameUIWindow
{
    public class GameUIWindowView : UIWindow
    {
        public UIButton[] Buttons => buttons; 
        public PlayerTooltipView[] PlayerTooltipViews => playerTooltipViews;
       
        [SerializeField] private UIButton[] buttons;
        [SerializeField] PlayerTooltipView[] playerTooltipViews;
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