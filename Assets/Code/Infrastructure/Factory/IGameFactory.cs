using Code.Infrastructure.Services.PersistentProgress;
using CodeBase.Infrastructure.Services;
using System.Collections.Generic;


namespace CodeBase.Infrastructure.Factory
{
    public interface IGameFactory : IService
    {
        List<ISavedProgressReader> ProgressReaders { get; }
        List<ISavedProgress> ProgressWritters { get; }


        void Cleanup();
        void Register(ISavedProgressReader reader);
        void RegisterSave(ISavedProgress writer);
    }
}