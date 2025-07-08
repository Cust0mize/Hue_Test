using Game.Modules.InputModule;
using UnityEngine;
using Spine.Unity;
using System;
using Spine;

namespace Game.Modules.PlayerModule.Scripts {
    public class PlayerAimController : MonoBehaviour {
        [SerializeField] private SkeletonAnimation _skeletonAnimation;

        [SerializeField] [SpineBone(dataField: nameof(_skeletonAnimation))]
        private string _crosshairBoneName;

        private Bone _crosshairBone;

        private InputManager _inputManager;
        private CharacterController _characterController;

        public event Action OnStartAim;
        public event Action OnEndAim;
        public event Action OnSetIdle;
        public event Action OnSetAim;

        private bool _isSetIdle;
        private bool _isSetAim;

        public void Init(InputManager inputManager) {
            _inputManager = inputManager;
            _characterController = GetComponent<CharacterController>();
            _crosshairBone = _skeletonAnimation.Skeleton.FindBone(_crosshairBoneName);
            _inputManager.InputSystem.OnRightClick += AimHandle;
            _inputManager.InputSystem.OnRightClickUp += StopAim;
            _inputManager.InputSystem.OnRightClickDown += StartAim;
        }

        private void StopAim(Vector3 mousePosition) {
            OnEndAim?.Invoke();
        }

        private void AimHandle(Vector3 mousePosition) {
            Vector3 worldMousePosition = _inputManager.GetWorldPosition(transform.position, mousePosition);
            Vector3 bodyWorldPosition = transform.position;
            float heightDifference = Mathf.Abs(worldMousePosition.y - bodyWorldPosition.y);

            if (heightDifference > _characterController.height * 2) {
                Vector3 skeletonSpacePoint = _skeletonAnimation.transform.InverseTransformPoint(worldMousePosition);
                skeletonSpacePoint.x *= _skeletonAnimation.Skeleton.ScaleX;
                skeletonSpacePoint.y *= _skeletonAnimation.Skeleton.ScaleY;
                _crosshairBone.SetLocalPosition(skeletonSpacePoint);

                if (_isSetAim == false) {
                    _isSetIdle = false;
                    _isSetAim = true;
                    OnSetAim?.Invoke();
                }
            }
            else {
                Vector3 skeletonSpacePoint = _skeletonAnimation.transform.InverseTransformPoint(worldMousePosition);
                skeletonSpacePoint.x *= _skeletonAnimation.Skeleton.ScaleX;
                skeletonSpacePoint.y *= _skeletonAnimation.Skeleton.ScaleY;
                _crosshairBone.SetLocalPosition(skeletonSpacePoint);

                if (_isSetIdle == false) {
                    _isSetIdle = true;
                    _isSetAim = false;
                    OnSetIdle?.Invoke();
                }
                
            }
        }

        private void StartAim(Vector3 mousePosition) {
            _isSetIdle = false;
            _isSetAim = false;
            OnStartAim?.Invoke();
        }

        public void Dispose() {
            _inputManager.InputSystem.OnRightClick -= AimHandle;
            _inputManager.InputSystem.OnRightClickUp -= StopAim;
            _inputManager.InputSystem.OnRightClickDown -= StartAim;
            OnStartAim = null;
            OnEndAim = null;
        }
    }
}