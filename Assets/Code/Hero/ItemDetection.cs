using Code.Observer;
using System.Collections.Generic;
using Code.Items;
using UnityEngine;

namespace Code.Hero
{
    public class ItemDetection : MonoBehaviour
    {
        [SerializeField] private TriggerObserver _observer;

        private readonly List<Transform> _detectedItems = new();

        private Item _nearestItem;
        private float _distanceToNearestItem = 100;

        private void Start()
        {
            _observer.TriggerEnter += AddDetectedItem;
            _observer.TriggerExit += RemoveDetectedItem;
        }
        private void OnDisable()
        {
            _observer.TriggerEnter -= AddDetectedItem;
            _observer.TriggerExit -= RemoveDetectedItem;
        }
        private void AddDetectedItem(Collider collider)
        {
            if (!_detectedItems.Contains(collider.transform))
                _detectedItems.Add(collider.transform);
            
            FindTheNearestItem(collider.transform);
        }

        public void RemoveDetectedItem(Collider collider)
        {
            _detectedItems.Remove(collider.transform);
            collider.GetComponent<Item>().Highlight?.Invoke(false);
            
            _distanceToNearestItem = 100;
            
        }

        public void RemoveDetectedItem(Item item)
        {
            _detectedItems.Remove(item.transform);
            item.Highlight?.Invoke(false);
            
            _distanceToNearestItem = 100;
        }

        public void FindTheNearestItem(Transform item)
        {
            float distance = Vector3.Distance(item.position, transform.position);

            if (distance < _distanceToNearestItem)
            {
                _nearestItem?.Highlight?.Invoke(false);
                
                _nearestItem = item.GetComponent<Item>();
                _nearestItem.Highlight?.Invoke(true);
                _distanceToNearestItem = distance;
            }
        }

        public Item GetNearestItem()
        {
            _nearestItem?.Highlight?.Invoke(false);
            Item item = _nearestItem;
            _nearestItem = null;
            return item;
        }
    }

}