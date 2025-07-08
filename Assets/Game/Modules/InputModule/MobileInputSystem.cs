using UnityEngine.EventSystems;
using UnityEngine;

namespace Game.Modules.InputModule {
    public class MobileInputSystem : BaseInputSystem {
        private EventSystem _currentEventSystem;

        public override void Update() {
            if (Input.touches != null && Input.touchCount > 0) {
                Touch touch = Input.touches[0];
                Vector2 position = touch.position;

                if (touch.phase == TouchPhase.Began) {
                    StartInput(position);
                }
                else if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary) {
                    HandleInput(position);
                }
                else if (touch.phase == TouchPhase.Ended) {
                    EndInput(position);
                }
            }
        }
    }
}