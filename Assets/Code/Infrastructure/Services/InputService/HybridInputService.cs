using System;
using Code.CustomJoystics;
using Code.UI;
using UnityEngine;

namespace Code.Infrastructure.Services
{
    public class HybridInputService : InputService
    {
        private readonly InteractionJoystick _interactionJoystick;
        public override event Action InteractButtonPressed;
        public override event Action InteractButtonUp;

        public override Vector2 InteractionAxis =>
            new(_interactionJoystick.Horizontal, _interactionJoystick.Vertical);
        
        public override Vector2 MoveAxis => 
            new (Input.GetAxis(Horizontal), Input.GetAxis(Vertical));

        private HybridInputService(Hud hud)
        {
            _interactionJoystick = hud.InteractionJoystick;
            
            _interactionJoystick.Pressed += 
                () => InteractButtonPressed?.Invoke();
            
            _interactionJoystick.Uped +=
                () => InteractButtonUp?.Invoke();
        }
    }
}