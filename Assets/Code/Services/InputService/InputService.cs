using UnityEngine;

namespace Code.Services.InputService
{
    public class InputService : IInputService
    {
        private PlayerInput _playerInput;
        
        public InputService(PlayerInput playerInput)
        {
            _playerInput = playerInput;
        }

        public void Enable()
            => _playerInput.Enable();
        
        public void Disable()
            => _playerInput.Disable();

        public Vector2 ReadMovement()
            => _playerInput.Player.Movement.ReadValue<Vector2>();
    }
}