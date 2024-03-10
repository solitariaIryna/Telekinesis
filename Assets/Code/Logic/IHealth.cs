using System;

namespace Code.Logic
{
    public interface IHealth
    {
        float Current { get; }
        float Max { get; }

        event Action HealthChanged;
        void TakeDamage(float damage);
    }

    
}