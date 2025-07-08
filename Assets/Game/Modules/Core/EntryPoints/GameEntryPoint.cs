using Game.Modules.PlayerModule.Scripts;
using Game.Modules.InputModule;
using UnityEngine;
using Zenject;

namespace Game.Modules.Core.EntryPoints {
    public class GameEntryPoint : MonoBehaviour {
        private PlayerCreator _playerCreator;
        private InputManager _inputManager;

        [Inject]
        private void Inject(PlayerCreator playerCreator, InputManager inputManager) {
            _playerCreator = playerCreator;
            _inputManager = inputManager;
        }

        private void Start() {
            _inputManager.Init();
            _playerCreator.Init();
        }
    }
}