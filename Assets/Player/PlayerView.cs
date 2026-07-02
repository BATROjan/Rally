using System;
using Grid;
using Terresquall;
using Trigger;
using UnityEngine;
using Zenject;

namespace Player
{
    public class PlayerView : MonoBehaviour
    {
        public Action<PlayerView, int> OnTriggerPass;
        public PlayerType Type => _type;
        public VirtualJoystick Joystick
        {
            set => playerMovement.Joystick = value;
        }

        [SerializeField] private PlayerMovement playerMovement;
        [SerializeField] private SpriteRenderer playerSpriteRenderer;
        [SerializeField] private Rigidbody2D rigidbody2D;
        [SerializeField] private PlayerType _type;
        
        private void ReInit(PlayerType type, Sprite sprite, Vector3 position, Vector3 rotation, PlayerView item)
        {
           playerSpriteRenderer.sprite = sprite;
           transform.position = position;
           transform.rotation = Quaternion.Euler(rotation);
           _type = type;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            var trigger = other.GetComponent<TriggerView>();
            if (trigger)
            {
                OnTriggerPass?.Invoke(this, trigger.GetID());
            }
        }

        public class Pool : MonoMemoryPool<PlayerType, Sprite,Vector3, Vector3, PlayerView>
        {
            protected override void Reinitialize(PlayerType type, Sprite sprite, Vector3 position, Vector3 rotation, PlayerView item)
            {
                base.Reinitialize(type, sprite, position, rotation, item);
                item.ReInit(type, sprite, position, rotation, item);
            }
        }
    }
}