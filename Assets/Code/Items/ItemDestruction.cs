using UnityEngine;

namespace Code.Items
{
    [RequireComponent(typeof(ItemHealth))]
    public class ItemDestruction : MonoBehaviour
    {
        [SerializeField] private ItemHealth _health;

        private void Awake()
        {
            _health.HealthChanged += HealthChanged;
        }

        private void OnDestroy()
        {
            _health.HealthChanged -= HealthChanged;
        }

        private void HealthChanged()
        {
            if (_health.Current <= 0)
                Destroy();
        }

        private void Destroy()
        {
            Destroy(gameObject);
        }
    }
}