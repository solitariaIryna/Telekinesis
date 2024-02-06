using Code.Infrastructure.Factory;
using Code.Infrastructure.States;

namespace CodeBase.Infrastructure.States
{
    public class BootstrapState : IState
    {
        private const string Initial = "Initial";
        private GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly IUIFactory _uIFactory;

        public BootstrapState(SceneLoader sceneLoader, IUIFactory uIFactory)
        {
            _sceneLoader = sceneLoader;
            _uIFactory = uIFactory;
        }

        public void InitState(GameStateMachine gameStateMachine)
            => _stateMachine = gameStateMachine;
        public void Enter() => 
            _sceneLoader.Load(Initial, OnLoaded: EnterLoadLevel);

        private void EnterLoadLevel()
        {
            _uIFactory.CreateHud();
            _stateMachine.Enter<LoadProgressState>();
        }

        public void Exit()
        {

        }
       

    }
}