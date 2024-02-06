using Code.UI;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.Services
{
    public interface IInputSetvice
    {
        Vector2 Axis { get; }
    }
    public abstract class InputService : IInputSetvice
    {
        protected const string Horizontal = "Horizontal";
        protected const string Vertical = "Vertical";
        public abstract Vector2 Axis { get; }

    }

    public class MobileInputService : InputService
    {
        private readonly FloatingJoystick _movingJoystick;
        private readonly FloatingJoystick _attackJoystick;

        public override Vector2 Axis =>
            new (_movingJoystick.Horizontal, _movingJoystick.Vertical);

        private MobileInputService(Hud hud) 
        {
            _movingJoystick = hud.MovingJoystick;
            _attackJoystick = hud.AttackJoystick;
        }
    }
    public class StandaloneInputService : InputService
    {
        public override Vector2 Axis
            => new (Input.GetAxis(Horizontal), Input.GetAxis(Vertical));
    }
}
