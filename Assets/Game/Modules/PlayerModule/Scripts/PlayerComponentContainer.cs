using Game.Modules.PlayerModule.Scripts.PlayerAnimations;
using Game.Modules.MovementModule;
using Game.Modules.RotateModule;
using Game.Modules.InputModule;
using Game.Modules.PlayerModule.Scripts.SoConfigs;
using Game.Modules.SpineModule;
using UnityEngine;

namespace Game.Modules.PlayerModule.Scripts {
    public class PlayerComponentContainer : MonoBehaviour {
        [SerializeField] private PlayerAnimationComponent _playerAnimationComponent;
        [SerializeField] private PlayerMovementSettings _playerMovementSettings;
        [SerializeField] private PlayerAimController _playerAimController;
        [SerializeField] private RotateComponent _rotateComponent;
        [SerializeField] private MoveComponent _moveComponent;

        public void Init(PlayerAnimationService playerAnimationService, InputManager inputManager) {
            _playerAimController.Init(inputManager);
            _moveComponent.Init(new PlayerMovementRules(inputManager, _playerMovementSettings));
            _rotateComponent.Init(new PlayerRotateRules(inputManager, _playerAimController));
            _playerAnimationComponent.Init(this, playerAnimationService, new SpineAnimationService(), _playerAimController);
        }

        public PlayerMovementSettings GetPlayerMovementSetting() {
            return _playerMovementSettings;
        }

        private void OnDestroy() {
            _playerAimController.Dispose();
        }
    }
}