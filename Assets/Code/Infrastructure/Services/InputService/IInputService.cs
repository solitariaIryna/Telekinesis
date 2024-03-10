using System;
using UnityEngine;

namespace Code.Infrastructure.Services
{
    public interface IInputService
    {
        event Action InteractButtonPressed;
        event Action InteractButtonUp;
        Vector2 MoveAxis { get; }
        Vector2 InteractionAxis { get; }

    }
}