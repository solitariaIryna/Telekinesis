using Code.Infrastructure.Services.PersistentProgress;
using CodeBase.Infrastructure.AssetManagement;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssetProvider _assets;

        private readonly DiContainer _container;
        public List<ISavedProgressReader> ProgressReaders { get; } = new List<ISavedProgressReader>();
        public List<ISavedProgress> ProgressWritters { get; } = new List<ISavedProgress>();

        public GameFactory(IAssetProvider asset, DiContainer container)
        {
            _assets = asset;
            _container = container;
        }
        public void Cleanup()
        {
            ProgressReaders.Clear();
            ProgressWritters.Clear();
        }
        public void Register(ISavedProgressReader reader)
        {
            if (reader is ISavedProgress progressWriter)
                ProgressWritters.Add(progressWriter);

            ProgressReaders.Add(reader);
        }
        public void RegisterSave(ISavedProgress writer)
        {
            ProgressWritters.Add(writer);
        }
        private GameObject InstantiateRegistered(string prefabPath, Vector3 at)
        {
            GameObject gameObject = _assets.Instantiate(prefabPath, at);
            return gameObject;
        }
        private GameObject InstantiateRegistered(string prefabPath, Vector3 at, Transform parent)
        {
            GameObject gameObject = _assets.Instantiate(prefabPath, at, parent);
            return gameObject;
        }
        private GameObject InstantiateRegistered(string prefabPath)
        {
            GameObject gameObject = _assets.Instantiate(prefabPath);
            return gameObject;
        }



    }
}