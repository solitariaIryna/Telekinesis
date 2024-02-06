using Code.Data;
using Code.Infrastructure.Services.PersistentProgress;
using CodeBase.Infrastructure.Factory;
using UnityEngine;

namespace Code.Infrastructure.Services.SaveLoad
{
    public class SaveLoadService : ISaveLoadService
    {
        private const string ProgressKey = "Progress";
        private readonly IPersistentProgressService _progressService;
        private readonly IGameFactory _gameFactory;

        public SaveLoadService( IPersistentProgressService progressService, IGameFactory gameFactory)
        {
            _progressService = progressService;
            _gameFactory = gameFactory;
        }

        public void SaveProgress()
        {
            foreach (ISavedProgress writter in _gameFactory.ProgressWritters)
            {
                writter.UpdateProgress(_progressService.Progress);
            }

            PlayerPrefs.SetString(ProgressKey, _progressService.Progress.ToJson());
        }
        public PlayerProgress LoadProgress() => 
            PlayerPrefs.GetString(ProgressKey)?
           .ToDeseralized<PlayerProgress>();
    }
}