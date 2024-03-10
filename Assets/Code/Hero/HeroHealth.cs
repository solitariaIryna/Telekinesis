using System;
using Code.Logic;

namespace Code.Hero
{
    public class HeroHealth : IHealth
    {
        private float _current;
        private float _max;
        public float Current
        {
            set
            {
                if (value != _current)
                {
                    Current = value;
                    HealthChanged?.Invoke();
                }
            }
            get
                => _current;
        }

        public float Max
        {
            set
                => _max = value;
            get
                => _max;
        }
        
        public event Action HealthChanged;
        public void TakeDamage(float damage)
        {
            Current -= damage;
        }
    }
}