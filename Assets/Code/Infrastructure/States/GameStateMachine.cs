using CodeBase.Infrastructure.States;
using System;
using System.Collections.Generic;
using Zenject;

namespace Code.Infrastructure.States
{
    public class GameStateMachine : StateMachine
    {
        [Inject]
        public GameStateMachine(BootstrapState bootstrapState, LoadLevelState loadLevelState, LoadProgressState loadProgressState,
            GameLoopState gameLoopState)
        {
            _states = new Dictionary<Type, IInitExitableState>
            {
                { typeof(BootstrapState), bootstrapState },
                { typeof(LoadProgressState), loadProgressState },
                { typeof(LoadLevelState), loadLevelState },
                { typeof(GameLoopState), gameLoopState },

            };

            foreach (var state in _states.Values)
            {
                state.InitState(this);
            }
                
        }


        public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedState<TPayload>
        {
            TState state = ChangeState<TState>();
            state.Enter(payload);
        }

    }
}