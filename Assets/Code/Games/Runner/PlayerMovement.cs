using Code.Services.InputService;
using UnityEngine;

namespace Code.Games.Runner
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private float _moveSpeed;
        
        private IInputService _inputService;

        public void Init(IInputService inputService)
        {
            _inputService = inputService;
        }

        private void Awake()
        {
            _inputService = new InputService(new PlayerInput());
            _inputService.Enable();
        }

        private void Update()
        {
            Vector3 moveDirection = new Vector3(_inputService.ReadMovement().x, 0, _inputService.ReadMovement().y);
            _characterController.Move(moveDirection * _moveSpeed * Time.deltaTime);
            
            if (moveDirection != Vector3.zero)
                transform.rotation = Quaternion.LookRotation(moveDirection, Vector3.up);
        }
    }
}