using Game.Modules.InputModule;
using UnityEngine;
using Zenject;

namespace Game.Modules.Core.Installers {
    public class GameInstaller : MonoInstaller {
        [SerializeField] private InputManager _inputManager;

        public override void InstallBindings() {
            Container.BindInstance(_inputManager).AsCached().NonLazy();
        }
    }
}