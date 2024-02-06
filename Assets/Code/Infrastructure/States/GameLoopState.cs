
using Code.Infrastructure.States;

namespace CodeBase.Infrastructure.States
{
    public class GameLoopState : IState
    {
        private GameStateMachine _stateMachine;

        public GameLoopState()
        {
        }

        public void InitState(GameStateMachine gameStateMachine)
            => _stateMachine = gameStateMachine;
        public void Enter()
        {
            

        }
      
        public void Exit()
        {
           

        }
    }
}