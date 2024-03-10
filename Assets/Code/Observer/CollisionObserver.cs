using System;
using UnityEngine;

namespace Code.Observer
{
    public class CollisionObserver : MonoBehaviour
    {
        public Action<Collision> CollisionEnter;
        public Action<Collision> CollisionExit;
        private void OnCollisionEnter(Collision other) => 
            CollisionEnter?.Invoke(other);

        private void OnCollisionExit(Collision other) => 
            CollisionExit?.Invoke(other);
    }
}