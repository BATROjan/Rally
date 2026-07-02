using Player;
using Terresquall;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI.GameUIWindow
{
    public class PlayerTooltipView : MonoBehaviour
    {
        public PlayerType PlayerType => playerType;
        public VirtualJoystick Joystick => joystick;
        public Image Image => _image;
        public Text PlayerScore=> playerScore;
        
        [SerializeField] PlayerType playerType;
        [SerializeField] VirtualJoystick joystick;
        [SerializeField] Image _image;
        [SerializeField] Text playerScore;

        public void Reinit(Color color)
        {
            Image.color = color;
        }
        
        public class Pool : MonoMemoryPool<Color, Transform, Vector3, Vector3, TextAnchor, PlayerTooltipView>
        {
            protected override void Reinitialize(Color color, Transform parent, Vector3 position, Vector3 rotation, TextAnchor anchor, PlayerTooltipView item)
            {
                base.Reinitialize(color, parent, position, rotation, anchor,item);
            }
        }
    }
}