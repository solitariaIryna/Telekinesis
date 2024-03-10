using UnityEngine;

namespace Code.Infrastructure.Services
{
    public class RandomService
    {
        public float Generate(float min, float max) => 
            Random.Range(min, max);
    }
}