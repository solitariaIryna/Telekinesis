using Code.Logic;
using System;
using UnityEngine;

namespace Code.Hero
{
    [RequireComponent(typeof(CharacterController))]
    public class HeroAnimator : MonoBehaviour, IAnimationStateReader
    {

        private static readonly int WalkHash = Animator.StringToHash("Walk");
        private static readonly int AttackHash = Animator.StringToHash("Attack");
        private static readonly int RunHash = Animator.StringToHash("Run");
        private static readonly int HitHash = Animator.StringToHash("Hit");
        private static readonly int DieHash = Animator.StringToHash("Die");

        private readonly int _idleStateHash = Animator.StringToHash("Idle");
        private readonly int _attackStateHash = Animator.StringToHash("Attack");
        private readonly int _walkStateHash = Animator.StringToHash("Walk");
        private readonly int _deathStateHash = Animator.StringToHash("Die");

        [SerializeField] private Animator _animator;
        [SerializeField] private CharacterController _characterController;

        public event Action<AnimatorState> StateEntered;
        public event Action<AnimatorState> StateExited;

        public AnimatorState State { get; private set; }

        private void Update()
        {
            _animator.SetFloat(WalkHash, _characterController.velocity.magnitude, 0.1f, Time.deltaTime);
        }
        public bool IsAttaking() =>
            State == AnimatorState.Attack;

        public void PlayHit() =>
            _animator.SetTrigger(HitHash);

        public void PlayAttack() =>
            _animator.SetTrigger(AttackHash);

        public void PlayDeath() =>
            _animator.SetTrigger(DieHash);

        public void ResetToIdle() =>
            _animator.Play(_idleStateHash, -1);

        public void EnteredState(int stateHash)
        {
            State = StateFor(stateHash);
            StateEntered?.Invoke(State);
        }

        public void ExitedState(int stateHash) => 
            StateExited?.Invoke(StateFor(stateHash));
        private AnimatorState StateFor(int stateHash)
        {
            AnimatorState state;
            if (stateHash == _idleStateHash)
                state = AnimatorState.Idle;
            else if (stateHash == _attackStateHash)
                state = AnimatorState.Attack;
            else if (stateHash == _walkStateHash)
                state = AnimatorState.Walk;
            else if (stateHash == _deathStateHash)
                state = AnimatorState.Died;
            else
                state = AnimatorState.Unknown;

            return state;
        }

    }



}

