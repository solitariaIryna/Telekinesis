using Code.Infrastructure.States;

namespace CodeBase.Infrastructure.States
{
    public interface IState : IExitableState
    {
        void Enter();
        
        
    }

    public interface IUpdatebleState : IState
    {
        void Update();
    }
    public interface IPayloadedState<TPayload> : IExitableState
    {
        void Enter(TPayload payload);
    }

    public interface IExitableState
    {
        
        void InitState(GameStateMachine gameStateMachine);
        void Exit();
    }
}