using System;
using UnityEngine;

namespace Code.Infrastructure.Services
{
    public abstract class InputService : IInputService
    {
        protected const string Horizontal = "Horizontal";
        protected const string Vertical = "Vertical";

        public abstract event Action InteractButtonPressed;
        public abstract event Action InteractButtonUp;
        public abstract Vector2 MoveAxis { get; }
        public abstract Vector2 InteractionAxis { get; }


    }
}
