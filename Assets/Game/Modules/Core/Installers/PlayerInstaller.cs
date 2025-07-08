using Game.Modules.PlayerModule.Scripts.PlayerAnimations;
using Game.Modules.PlayerModule.Scripts;
using Game.Modules.PlayerModule.Scripts.SoConfigs;
using UnityEngine;
using Zenject;

namespace Game.Modules.Core.Installers {
    public class PlayerInstaller : MonoInstaller {
        [SerializeField] private PlayerComponentContainer _playerComponentContainer;
        [SerializeField] private IdleAimSO _idleAimSo;

        public override void InstallBindings() {
            Container.Bind<BasePlayerAnimation>().To(x => x.AllNonAbstractClasses().DerivingFrom<BasePlayerAnimation>()).AsCached().NonLazy();
            Container.BindInstance(_playerComponentContainer).AsCached().NonLazy();
            Container.Bind<PlayerAnimationService>().AsCached().NonLazy();
            Container.BindInstance(_idleAimSo).AsCached().NonLazy();
            Container.Bind<PlayerCreator>().AsCached().NonLazy();
        }
    }
}