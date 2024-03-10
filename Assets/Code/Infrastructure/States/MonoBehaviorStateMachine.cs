using CodeBase.Infrastructure.States;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Code.Infrastructure
{
    public class MonoBehaviorStateMachine : MonoBehaviour
    {
        protected Dictionary<Type, IUpdatebleState> _states;
        protected IUpdatebleState _activeState;
        public void Enter<TState>() where TState : class, IUpdatebleState
        {
            IUpdatebleState state = ChangeState<TState>();
            state.Enter();
        }
        protected TState ChangeState<TState>() where TState : class, IUpdatebleState
        {
            _activeState?.Exit();

            TState state = GetState<TState>();
            _activeState = state;

            return state;
        }

        protected TState GetState<TState>() where TState : class, IUpdatebleState =>
            _states[typeof(TState)] as TState;


    }
}
