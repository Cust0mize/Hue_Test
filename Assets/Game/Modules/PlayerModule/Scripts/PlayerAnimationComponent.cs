using Game.Modules.PlayerModule.Scripts.PlayerAnimations;
using AnimationState = Spine.AnimationState;
using Game.Modules.MovementModule;
using Game.Modules.PlayerModule.Scripts.SoConfigs;
using Game.Modules.RotateModule;
using Game.Modules.SpineModule;
using Spine.Unity;
using UnityEngine;

namespace Game.Modules.PlayerModule.Scripts {
    public class PlayerAnimationComponent : MonoBehaviour {
        [SerializeField] private SkeletonAnimation _skeleton;
        [SerializeField] private AnimationReferenceAsset _idleAnimation;
        [SerializeField] private AnimationReferenceAsset _walkAnimation;
        [SerializeField] private AnimationReferenceAsset _runAnimation;
        [SerializeField] private AnimationReferenceAsset _aimAnimation;

        private AnimationState AnimationState => _skeleton.AnimationState;
        private float AbsCurrentSpeed => _playerMovementRules.AbsCurrentSpeed;

        private PlayerAnimationService _playerAnimationService;
        private PlayerMovementSettings _playerMovementSettings;
        private SpineAnimationService _spineAnimationService;
        private PlayerAimController _playerAimController;
        private PlayerMovementRules _playerMovementRules;
        private PlayerRotateRules _playerRotateRules;
        private bool _isLeftDirection;

        public void Init(
        PlayerComponentContainer playerComponentContainer,
        PlayerAnimationService playerAnimationService,
        SpineAnimationService spineAnimationService,
        PlayerAimController playerAimController
        ) {
            _playerAnimationService = playerAnimationService;
            _spineAnimationService = spineAnimationService;
            _playerAimController = playerAimController;
            _playerMovementSettings = playerComponentContainer.GetPlayerMovementSetting();
            _playerMovementRules = (PlayerMovementRules)playerComponentContainer.GetComponent<MoveComponent>().MovementRules;
            _playerRotateRules = (PlayerRotateRules)playerComponentContainer.GetComponent<RotateComponent>().RotateRules;
            _playerRotateRules.OnChangeDirection += SetDirection;
            _playerAimController.OnEndAim += EndAim;
            _playerAimController.OnSetIdle += SetIdleAim;
            _playerAimController.OnSetAim += StartAim;
            _spineAnimationService.AnimationInit(_skeleton);
            SetIdleAnimation();
        }

        private void SetDirection(bool isLeftDirection) {
            _isLeftDirection = isLeftDirection;
        }

        private void SetIdleAnimation() {
            _playerAnimationService.PlayAnimation<IdlePlayerAnimation>(_playerMovementSettings, _spineAnimationService, AnimationState, transform, _isLeftDirection, _idleAnimation);
        }

        private void SetIdleAim() {
            _playerAnimationService.PlayAnimation<IdleAimPlayerAnimation>(_playerMovementSettings, _spineAnimationService, AnimationState, transform, _isLeftDirection, _idleAnimation, _aimAnimation);
        }

        private void StartAim() {
            _playerAnimationService.PlayAnimation<StartAimPlayerAnimation>(_playerMovementSettings, _spineAnimationService, AnimationState, transform, _isLeftDirection, _aimAnimation);
        }

        private void EndAim() {
            _playerAnimationService.PlayAnimation<EndAimPlayerAnimation>(_playerMovementSettings, _spineAnimationService, AnimationState, transform, _isLeftDirection, _aimAnimation);
        }

        private void Update() {
            UpdateAnimation();
        }

        private void UpdateAnimation() {
            BasePlayerAnimation newMovementAnimation = GetDesiredMovementState(out AnimationReferenceAsset targetAnimation);
            _playerAnimationService.PlayAnimation<RunningPlayerAnimation>(_playerMovementSettings, _spineAnimationService, AnimationState, transform, _isLeftDirection, targetAnimation);
        }

        private BasePlayerAnimation GetDesiredMovementState(out AnimationReferenceAsset targetAnimation) {
            if (AbsCurrentSpeed > _playerMovementSettings.SpeedToMovingAnimation) {
                if (AbsCurrentSpeed >= _playerMovementSettings.RunThreshold) {
                    targetAnimation = _runAnimation;
                    return _playerAnimationService.GetAnimation<RunningPlayerAnimation>();
                }
                else {
                    targetAnimation = _walkAnimation;
                    return _playerAnimationService.GetAnimation<WalkingPlayerAnimation>();
                }
            }
            else {
                targetAnimation = _idleAnimation;
                return _playerAnimationService.GetAnimation<IdlePlayerAnimation>();
            }
        }

        private void OnDestroy() {
            _playerRotateRules.OnChangeDirection -= SetDirection;
        }
    }
}