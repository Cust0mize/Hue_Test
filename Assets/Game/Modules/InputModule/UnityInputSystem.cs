using UnityEngine.EventSystems;
using UnityEngine;

namespace Game.Modules.InputModule {
    public class UnityInputSystem : BaseInputSystem {
        private EventSystem _currentEventSystem;

        private const int LEFT_MOUSE_BUTTON_INDEX = 0;
        private const int RIGHT_MOUSE_BUTTON_INDEX = 1;

        public override void Update() {
            Vector3 position = Input.mousePosition;
            UpdateInput(position);

            if (Input.GetMouseButton(RIGHT_MOUSE_BUTTON_INDEX)) {
                HandleInput(position);
            }

            if (Input.GetMouseButtonUp(RIGHT_MOUSE_BUTTON_INDEX)) {
                EndInput(position);
            }

            if (Input.GetMouseButtonDown(RIGHT_MOUSE_BUTTON_INDEX)) {
                StartInput(position);
            }
        }
    }
}