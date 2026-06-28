using Grid;
using UnityEngine;
using Zenject;

namespace Player
{
    public class PlayerView : MonoBehaviour
    {
        public SpriteRenderer PlayerSpriteRenderer => playerSpriteRenderer;
        [SerializeField] private SpriteRenderer playerSpriteRenderer;
        
        private void ReInit(Sprite sprite, Vector3 position, Vector3 rotation, PlayerView item)
        {
           playerSpriteRenderer.sprite = sprite;
           transform.position = position;
           transform.rotation = Quaternion.Euler(rotation);
        }
        public class Pool : MonoMemoryPool<Sprite,Vector3, Vector3, PlayerView>
        {
            protected override void Reinitialize(Sprite sprite, Vector3 position, Vector3 rotation, PlayerView item)
            {
                base.Reinitialize(sprite, position, rotation, item);
                item.ReInit(sprite, position, rotation, item);
            }
        }
    }
}