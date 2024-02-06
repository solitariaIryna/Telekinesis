using Code.Infrastructure.States;
using CodeBase.Infrastructure.States;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure
{
    public class GameBootstraper : MonoBehaviour, ICoroutineRunner
    {
        private GameStateMachine _stateMachine;

        [Inject]
        private void Construct(GameStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
         
        }
        
        private void Start()
        {
            _stateMachine.Enter<BootstrapState>();
            DontDestroyOnLoad(gameObject);
        }
        

     
    }
}