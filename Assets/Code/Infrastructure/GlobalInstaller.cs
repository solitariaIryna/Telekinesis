using Code.Infrastructure.Factory;
using Code.Infrastructure.Services.PersistentProgress;
using Code.Infrastructure.Services.SaveLoad;
using Code.Infrastructure.States;
using CodeBase.Infrastructure;
using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.States;
using Zenject;

namespace Assets.Code.Infrastructure
{
    public class GlobalInstaller : MonoInstaller, ICoroutineRunner
    {
        public override void InstallBindings()
        {
            BindServices();
            BindGameStateMachine();
            BindFactories();
        }

        private void BindFactories()
        {
            Container
                .Bind<IGameFactory>()
                .To<GameFactory>()
                .AsSingle();

            Container
               .Bind<IUIFactory>()
               .To<UIFactory>()
               .AsSingle();
        }

        private void BindServices()
        {
            Container
                .Bind<IAssetProvider>()
                .To<AssetProvider>()
                .AsSingle();

            Container
                .Bind<IStaticDataService>()
                .To<StaticDataService>()
                .AsSingle();

            Container
                .Bind<SceneLoader>()
                .To<SceneLoader>()
                .AsSingle();
            Container
                .Bind<ICoroutineRunner>()
                .FromInstance(this)
                .AsSingle();

            Container
                .Bind<ISaveLoadService>()
                .To<SaveLoadService>()
                .AsSingle();

            Container
                .Bind<IPersistentProgressService>()
                .To<PersistentProgressService>()
                .AsSingle();
        }

       

        private void BindGameStateMachine()
        {
            Container
                .Bind<GameStateMachine>()
                .To<GameStateMachine>()
                .AsSingle()
                .NonLazy();

            Container
                .Bind<BootstrapState>()
                .To<BootstrapState>()
                .AsSingle();

            Container
                .Bind<LoadProgressState>()
                .To<LoadProgressState>()
                .AsSingle();

            Container
                .Bind<LoadLevelState>()
                .To<LoadLevelState>()
                .AsSingle();

            Container
                .Bind<GameLoopState>()
                .To<GameLoopState>()
                .AsSingle();
        }
    }
}