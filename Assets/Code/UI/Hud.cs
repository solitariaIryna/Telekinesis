using Code.CustomJoystics;
using UnityEngine;

namespace Code.UI
{
    public class Hud : MonoBehaviour   
    {
        [field: SerializeField] public FloatingJoystick MovingJoystick { get; private set; }
        [field: SerializeField] public InteractionJoystick InteractionJoystick { get; private set; }

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }
    }
}
