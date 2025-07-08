using Game.Modules.PlayerModule.Scripts.SoConfigs;
using Game.Modules.MovementModule;
using Game.Modules.InputModule;
using UnityEngine;

namespace Game.Modules.PlayerModule.Scripts {
    public class PlayerMovementRules : IMovementRules {
        private readonly PlayerMovementSettings _movementSettings;
        private readonly InputManager _inputManager;
        private CharacterController _characterController;

        public float AbsCurrentSpeed => Mathf.Abs(_currentSpeed);
        private Vector3 _currentMousePosition;
        private float _currentSpeed;

        public PlayerMovementRules(InputManager inputManager, PlayerMovementSettings movementSettings) {
            _movementSettings = movementSettings;
            _inputManager = inputManager;
            _inputManager.InputSystem.OnMousePositionUpdate += UpdateMousePosition;
        }

        private void UpdateMousePosition(Vector3 mousePosition) {
            _currentMousePosition = mousePosition;
        }

        public void Move(Transform target) {
            if (TryInitializeComponent(target) == false) {
                return;
            }

            Vector3 targetPosition = target.position;
            Vector3 mouseWorldPosition = _inputManager.GetWorldPosition(targetPosition, _currentMousePosition);
            float distance = mouseWorldPosition.x - targetPosition.x;
            bool shouldAcceleration = Mathf.Abs(distance) > _movementSettings.MinAccelerationDistance;

            if (shouldAcceleration) {
                _currentSpeed = Mathf.MoveTowards(_currentSpeed, _movementSettings.MaxSpeed * Mathf.Sign(distance), _movementSettings.Acceleration * Time.deltaTime);
            }
            else {
                _currentSpeed = Mathf.MoveTowards(_currentSpeed, _movementSettings.TargetOnDeceleration, _movementSettings.Deceleration * Time.deltaTime);
            }

            Vector3 motion = Vector3.zero;
            motion.x = _currentSpeed * Time.deltaTime;
            _characterController.Move(motion);
        }

        private bool TryInitializeComponent(Transform target) {
            if (_characterController == null) {
                if (target.TryGetComponent(out CharacterController characterController)) {
                    _characterController = characterController;
                }
                else {
                    Debug.Log("no character controller");
                    return false;
                }
            }

            return true;
        }
    }
}