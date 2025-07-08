using UnityEngine;

namespace Game.Modules.MovementModule {
    public class MoveComponent : MonoBehaviour {
        public IMovementRules MovementRules { get; private set; }

        public void Init(IMovementRules movementRules) {
            MovementRules = movementRules;
        }

        private void Update() {
            MovementRules.Move(transform);
        }
    }
}