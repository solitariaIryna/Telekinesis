using CodeBase.Infrastructure.States;
using System;
using System.Collections.Generic;

namespace Code.Infrastructure
{
    public class StateMachine
    {
        protected Dictionary<Type, IInitExitableState> _states;
        protected IInitExitableState _activeState;
        public void Enter<TState>() where TState : class, IState
        {
            IState state = ChangeState<TState>();
            state.Enter();
        }

        protected TState ChangeState<TState>() where TState : class, IInitExitableState
        {
            _activeState?.Exit();

            TState state = GetState<TState>();
            _activeState = state;

            return state;
        }

        protected TState GetState<TState>() where TState : class, IInitExitableState =>
            _states[typeof(TState)] as TState;

    }
}
