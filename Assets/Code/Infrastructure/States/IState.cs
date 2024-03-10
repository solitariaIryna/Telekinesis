using Code.Infrastructure.States;

namespace CodeBase.Infrastructure.States
{
    public interface IState : IInitExitableState, IEnterState
    {
        
    }
    public interface IEnterState
    {
        void Enter();
    }
    public interface IUpdatebleState : IExitableState, IEnterState
    {
        void Update();
    }
    public interface IPayloadedState<TPayload> : IInitExitableState
    {
        void Enter(TPayload payload);
    }
    public interface IInitState
    {
        void InitState(GameStateMachine gameStateMachine);
    }

    public interface  IInitExitableState: IExitableState, IInitState
    {
        
    }
    public interface IExitableState
    {               
        void Exit();
    }
}