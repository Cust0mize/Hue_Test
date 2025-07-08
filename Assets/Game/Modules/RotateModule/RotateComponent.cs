using UnityEngine;

namespace Game.Modules.RotateModule {
    public class RotateComponent : MonoBehaviour {
        public IRotateRules RotateRules { get; private set; }

        public void Init(IRotateRules movementRules) {
            RotateRules = movementRules;
        }

        private void Update() {
            RotateRules.Rotate(transform);
        }
    }
}