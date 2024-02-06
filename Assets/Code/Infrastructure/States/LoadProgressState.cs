using Code.Infrastructure.Services.PersistentProgress;
using Code.Infrastructure.Services.SaveLoad;
using Code.Infrastructure.States;

namespace CodeBase.Infrastructure.States
{
    public class LoadProgressState : IState
    {
        private const string GameScene = "Game";
        private GameStateMachine _stateMachine;
        private readonly IPersistentProgressService _progressService;
        private ISaveLoadService _saveLoadService;

        public LoadProgressState(IPersistentProgressService progressService, 
            ISaveLoadService saveLoadService)
        {
            _progressService = progressService;
            _saveLoadService = saveLoadService;
        }
        public void Enter()
        {
            LoadProgressOrInitNew();

            _stateMachine.Enter<LoadLevelState, string>(GameScene);
        }

        private void LoadProgressOrInitNew()
        {
            _progressService.Progress = NewProgress();
            //_progressService.Progress = _saveLoadService.LoadProgress() ?? NewProgress();
            _saveLoadService.SaveProgress();
        }

        private PlayerProgress NewProgress() => 
            new PlayerProgress();

        public void Exit()
        {
            
        }

        public void InitState(GameStateMachine gameStateMachine)
        {
            _stateMachine = gameStateMachine;
        }
    }
}