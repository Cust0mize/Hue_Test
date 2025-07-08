using Game.Modules.PlayerModule.Scripts.PlayerAnimations;
using Game.Modules.InputModule;

namespace Game.Modules.PlayerModule.Scripts {
    public class PlayerCreator {
        private readonly PlayerComponentContainer _playerComponentContainer;
        private readonly PlayerAnimationService _playerAnimationService;
        private readonly InputManager _inputManager;

        public PlayerCreator(PlayerComponentContainer playerComponentContainer, PlayerAnimationService playerAnimationService, InputManager inputManager) {
            _playerComponentContainer = playerComponentContainer;
            _playerAnimationService = playerAnimationService;
            _inputManager = inputManager;
        }

        public void Init() {
            _playerComponentContainer.Init(_playerAnimationService, _inputManager);
        }
    }
}