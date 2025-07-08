using UnityEngine;

namespace Game.Modules.RotateModule {
    public interface IRotateRules {
        public void Rotate(Transform target);
    }
}