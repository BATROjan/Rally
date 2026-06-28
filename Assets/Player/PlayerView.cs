using Grid;
using UnityEngine;
using Zenject;

namespace Player
{
    public class PlayerView : MonoBehaviour
    {
        public SpriteRenderer PlayerSpriteRenderer => playerSpriteRenderer;
        [SerializeField] private SpriteRenderer playerSpriteRenderer;
        
        private void ReInit(Sprite sprite, PlayerView item)
        {
           playerSpriteRenderer.sprite = sprite;
        }
        public class Pool : MonoMemoryPool<Sprite, PlayerView>
        {
            protected override void Reinitialize(Sprite sprite, PlayerView item)
            {
                base.Reinitialize(sprite, item);
                item.ReInit(sprite, item);
            }
        }
    }
}