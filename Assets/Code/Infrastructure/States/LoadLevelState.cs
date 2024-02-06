using Code.Infrastructure.Factory;
using Code.Infrastructure.States;


namespace CodeBase.Infrastructure.States
{
    public class LoadLevelState : IPayloadedState<string>
    {
        private const string InitialPointTag = "InitialPoint";

        private GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly IUIFactory _uIFactory;

        public LoadLevelState(SceneLoader sceneLoader, IUIFactory uIFactory)
        {
            _sceneLoader = sceneLoader;
            _uIFactory = uIFactory;
        }

        public void InitState(GameStateMachine gameStateMachine)
            => _stateMachine = gameStateMachine;
        public void Enter(string sceneName)
        {
            _sceneLoader.Load(sceneName, OnLoaded);    
        }

        private void OnLoaded()
        {
            InitGameWorld();
            _stateMachine.Enter<GameLoopState>();

        }

        private void InitGameWorld()
        {
            
        }


        public void Exit()
        {
        }

       
    }
}