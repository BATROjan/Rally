using UnityEngine;
using UnityEngine.UI;

namespace UI.GameUIWindow
{
    public class GameUIWindowView : UIWindow
    {
        public Text TimerText
        {
            get => timerText;
            set => timerText = value;
        }

        public UIButton[] Buttons => buttons; 
        public PlayerTooltipView[] PlayerTooltipViews => playerTooltipViews;
       
        [SerializeField] private UIButton[] buttons;
        [SerializeField] PlayerTooltipView[] playerTooltipViews;
        [SerializeField] private Text timerText;
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