using Code.UI;
using CodeBase.Infrastructure.AssetManagement;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.Factory
{
    public class UIFactory : IUIFactory
    {
        private readonly IAssetProvider _assets;
        private readonly DiContainer _container;
        public Hud Hud { get; private set; }

        private UIFactory(IAssetProvider assets, DiContainer container)
        {
            _assets = assets;
            _container = container;
        }

        public Hud CreateHud()
        {
            Hud = InstantiateRegistered(AssetPath.HudPath).
                    GetComponent<Hud>();

            _container
                .Bind<Hud>()
                .FromInstance(Hud)
                .AsSingle();

            return Hud;
        }
        private GameObject InstantiateRegistered(string prefabPath, Vector3 at)
        {
            GameObject gameObject = _assets.Instantiate(prefabPath, at);
            return gameObject;
        }

        private GameObject InstantiateRegistered(string prefabPath)
        {
            GameObject gameObject = _assets.Instantiate(prefabPath);
            return gameObject;
        }
    }
}
