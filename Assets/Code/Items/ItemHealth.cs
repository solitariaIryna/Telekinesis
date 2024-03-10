using System;
using Code.Logic;
using UnityEngine;

namespace Code.Items
{
    public class ItemHealth : MonoBehaviour, IHealth
    {
        private float _current;
        private float _max;
        public float Current
        {
            set
            {
                if (value != _current)
                {
                    _current = value;
                    HealthChanged?.Invoke();
                }
            }
            get
                => _current;
        }

        public float Max
        {
            get
                => _max;
            set
                => _max = value;
        }
        
        public event Action HealthChanged;
        public void Construct(float maxHp)
        {
            _max = maxHp;
        }

        public void TakeDamage(float damage)
        {
            Current -= damage;
        }
        
    }
}