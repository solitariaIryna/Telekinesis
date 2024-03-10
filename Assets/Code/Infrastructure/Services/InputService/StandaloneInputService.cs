using System;
using System.Collections;
using CodeBase.Infrastructure;
using UnityEngine;

namespace Code.Infrastructure.Services
{
    public class StandaloneInputService : InputService
    {
        private readonly ICoroutineRunner _coroutineRunner;
        public override event Action InteractButtonPressed;
        public override event Action InteractButtonUp;

        public override Vector2 MoveAxis
            => new (Input.GetAxis(Horizontal), Input.GetAxis(Vertical));

        public override Vector2 InteractionAxis { get; }

        private StandaloneInputService(ICoroutineRunner coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
            _coroutineRunner.StartCoroutine(Interaction());
        }

        private IEnumerator Interaction()
        {
            if (Input.GetKeyDown(KeyCode.E))
                InteractButtonPressed?.Invoke();
            else
                InteractButtonUp?.Invoke();
            

            yield return null;
        }
    }
}