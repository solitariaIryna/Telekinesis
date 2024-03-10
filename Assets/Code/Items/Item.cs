using Code.Infrastructure;
using Code.Items.States;
using Code.StaticData;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.States;
using System;
using System.Collections.Generic;
using Code.Infrastructure.Services;
using UnityEngine;
using Zenject;

namespace Code.Items
{
    public class Item : MonoBehaviorStateMachine
    {
        [SerializeField] private ItemInfo _itemInfo;
        
        [SerializeField] private ItemStaticData _data;

        private Camera _camera;
        
        public Action<bool> Highlight;
        public Action<Transform> Follow;
        public Action Levitation;
        public Action AttackOrFall;

        [Inject]
        private void Construct(IStaticDataService staticDataService, IInputService inputService)
        {
            _camera = Camera.main;
            
            _itemInfo.Health.Construct(_data.MaxHealth);
            
            if (_itemInfo.Renderer == null)
                _itemInfo.Renderer = transform.GetComponentInChildren<MeshRenderer>();
            
            

            _states = new Dictionary<Type, IUpdatebleState>
            {
                { typeof(ItemRestState), new ItemRestState(this, _itemInfo) },
                { typeof(ItemLevitationState), new ItemLevitationState(this, _itemInfo, _data, inputService, _camera) },
                { typeof(ItemFallState), new ItemFallState(this, _itemInfo) },
                { typeof(ItemAttackState), new ItemAttackState(this, _itemInfo, _data) },

            };
            Enter<ItemRestState>();
        }
        
        private void Update()
        {
            _activeState.Update();
        }
    }
}

