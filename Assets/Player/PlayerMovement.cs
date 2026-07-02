using Terresquall;
using UnityEngine;

namespace Player
{
    public class PlayerMovement: MonoBehaviour
    {
        public VirtualJoystick Joystick 
        { 
            set => _joystick = value; 
        }
        public Rigidbody2D Rigidbody2D 
        { 
            get => _rigidbody2D;
            set => _rigidbody2D = value; 
        }
        
        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private VirtualJoystick _joystick;
        
        public void FixedUpdate()
        {
            if (!_joystick) return;

            Vector2 moveDirection = new Vector2(_joystick.GetAxis("Horizontal"), _joystick.GetAxis("Vertical"));

            if (moveDirection.magnitude > 0.1f)
            {
                transform.up = moveDirection;
            }

            _rigidbody2D.AddForce(moveDirection * 8, ForceMode2D.Force);
        }
    }
}