using UnityEngine;
using System;

namespace Game.Modules.InputModule {
    public abstract class BaseInputSystem {
        public event Action<Vector3> OnRightClick;
        public event Action<Vector3> OnRightClickUp;
        public event Action<Vector3> OnRightClickDown;
        public event Action<Vector3> OnMousePositionUpdate;

        public abstract void Update();

        protected bool IsAllowedInput;

        public void EndInput(Vector2 position) {
            IsAllowedInput = false;
            OnRightClickUp?.Invoke(position);
        }

        protected void StartInput(Vector2 position) {
            IsAllowedInput = true;
            OnRightClickDown?.Invoke(position);
        }

        protected void HandleInput(Vector2 position) {
            if (IsAllowedInput) {
                OnRightClick?.Invoke(position);
            }
        }

        protected void UpdateInput(Vector2 position) {
            OnMousePositionUpdate?.Invoke(position);
        }
    }
}