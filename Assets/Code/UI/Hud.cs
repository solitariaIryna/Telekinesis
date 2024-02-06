using UnityEngine;

namespace Code.UI
{
    public class Hud : MonoBehaviour   
    {
        [field: SerializeField] public FloatingJoystick MovingJoystick { get; private set; }
        [field: SerializeField] public FloatingJoystick AttackJoystick { get; private set; }

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }
    }
}
