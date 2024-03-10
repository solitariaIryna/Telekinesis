using System;
using Code.CustomJoystics;
using Code.UI;
using UnityEngine;

namespace Code.Infrastructure.Services
{
    public class MobileInputService : InputService
    {
        private readonly FloatingJoystick _movingJoystick;
        private readonly InteractionJoystick _interactionJoystick;

        public override event Action InteractButtonPressed;
        public override event Action InteractButtonUp;
        

        public override Vector2 MoveAxis =>
            new (_movingJoystick.Horizontal, _movingJoystick.Vertical);

        public override Vector2 InteractionAxis =>
            new(_interactionJoystick.Horizontal, _interactionJoystick.Vertical);

        private MobileInputService(Hud hud) 
        {
            _movingJoystick = hud.MovingJoystick;
            _interactionJoystick = hud.InteractionJoystick;

            _interactionJoystick.Pressed += 
                () => InteractButtonPressed?.Invoke();
            
            _interactionJoystick.Uped +=
                () => InteractButtonUp?.Invoke();
        }

    }
}