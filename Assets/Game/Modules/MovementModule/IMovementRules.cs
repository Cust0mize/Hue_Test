using UnityEngine;

namespace Game.Modules.MovementModule {
    public interface IMovementRules {
        public void Move(Transform target);
    }
}