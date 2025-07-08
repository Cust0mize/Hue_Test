using Game.Modules.RotateModule;
using Game.Modules.InputModule;
using Spine.Unity;
using UnityEngine;
using System;

namespace Game.Modules.PlayerModule.Scripts {
    public class PlayerRotateRules : IRotateRules {
        private readonly InputManager _inputManager;
        
        private SkeletonAnimation _skeletonAnimation;
        private Vector3 _mousePosition;
        private float _lastDirection = 1f;
        private bool _canRotate;

        public event Action<bool> OnChangeDirection;
        
        private const float ROTATE_THRESHOLD = 0.1f;

        public PlayerRotateRules(InputManager inputManager, PlayerAimController playerAimController) {
            _inputManager = inputManager;
            _inputManager.InputSystem.OnMousePositionUpdate += SetMousePosition;
            playerAimController.OnStartAim += BlockRotate;
            playerAimController.OnEndAim += AllowRotate;
            _canRotate = true;
        }

        private void AllowRotate() {
            _canRotate = true;
        }

        private void BlockRotate() {
            _canRotate = false;
        }

        private void SetMousePosition(Vector3 mousePosition) {
            _mousePosition = mousePosition;
        }

        public void Rotate(Transform target) {
            if (TryInitializeComponent(target) == false) {
                return;
            }

            if (_canRotate == false) {
                return;
            }

            Vector3 targetPosition = target.position;
            Vector3 worldMousePosition = _inputManager.GetWorldPosition(targetPosition, _mousePosition);

            float xDifference = worldMousePosition.x - targetPosition.x;

            if (Mathf.Abs(xDifference) > ROTATE_THRESHOLD) {
                float newDirection = Mathf.Sign(xDifference);

                if (Mathf.Approximately(newDirection, _lastDirection) == false) {
                    _lastDirection = newDirection;
                    _skeletonAnimation.skeleton.ScaleX = newDirection;
                    bool isLeftDirection = _lastDirection < 0;
                    OnChangeDirection?.Invoke(isLeftDirection);
                }
            }
        }

        private bool TryInitializeComponent(Transform target) {
            if (_skeletonAnimation == null) {
                if (target.TryGetComponent(out SkeletonAnimation skeletonAnimation)) {
                    _skeletonAnimation = skeletonAnimation;
                }
                else {
                    SkeletonAnimation skeleton = target.GetComponentInChildren<SkeletonAnimation>();

                    if (skeleton != null) {
                        _skeletonAnimation = skeleton;
                    }
                    else {
                        Debug.LogError("SkeletonAnimation not found!");
                        return false;
                    }
                }
            }

            return true;
        }
    }
}