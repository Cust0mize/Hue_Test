using UnityEngine;

namespace Game.Modules.InputModule {
    public class InputManager : MonoBehaviour {
        public BaseInputSystem InputSystem { get; private set; }
        public bool InputIsAllowed { get; private set; } = true;
        private Camera _mainCamera;

        public void Init() {
            _mainCamera = Camera.main;

#if UNITY_EDITOR
            InputSystem = new UnityInputSystem();
#else
            InputSystem = new MobileInputSystem();
#endif
        }

        private void Update() {
            if (InputIsAllowed == false) {
                InputSystem.EndInput(Vector2.zero);
                return;
            }

            InputSystem.Update();
        }

        public void SetInputState(bool state) {
            InputIsAllowed = state;
        }

        public Vector3 GetWorldPosition(Vector3 targetObjectPosition, Vector3 screenPosition) {
            if (_mainCamera == null) {
                _mainCamera = Camera.main;
            }

            float minValue;
            float maxValue;

            if (targetObjectPosition.z < _mainCamera.transform.position.z) {
                minValue = targetObjectPosition.z;
                maxValue = _mainCamera.transform.position.z;
            }
            else {
                minValue = _mainCamera.transform.position.z;
                maxValue = targetObjectPosition.z;
            }

            float zPosition = Mathf.Abs(maxValue - minValue);
            Vector3 worldPosition = _mainCamera.ScreenToWorldPoint(new Vector3(screenPosition.x, screenPosition.y, zPosition));
            return worldPosition;
        }
    }
}