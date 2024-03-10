using Code.Infrastructure.Services;
using Code.Items;
using UnityEngine;
using Zenject;

namespace Code.Hero
{
    [RequireComponent(typeof(ItemDetection))]
    public class HeroAttack : MonoBehaviour
    {
        [SerializeField] private ItemDetection _detection;

        private Item _item;

        private IInputService _inputService;

        private bool _isPressed;
        
        [Inject]
        private void Construct(IInputService inputService)
        {
            _inputService = inputService;
            
            _inputService.InteractButtonPressed += PickUpItem;
            _inputService.InteractButtonUp += AttackOrRelease;
        }
        private void OnDisable()
        {
            _inputService.InteractButtonPressed -= PickUpItem;
            _inputService.InteractButtonUp -= AttackOrRelease;
        }

        private void AttackOrRelease()
        {
            _item?.AttackOrFall?.Invoke();
            _isPressed = false;
            _item = null;
        }
        
        private void PickUpItem()
        {
            if (_isPressed)
                return;
            
            _item = _detection.GetNearestItem();
            if (_item != null)
            {
                _isPressed = true;
                _detection.RemoveDetectedItem(_item);
                _item.Levitation?.Invoke();
                _item.Follow?.Invoke(transform);
            }
            
            
        }
        
    }

}