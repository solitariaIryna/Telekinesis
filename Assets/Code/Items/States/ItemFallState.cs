using Code.StaticData;
using CodeBase.Infrastructure.States;
using UnityEngine;

namespace Code.Items.States
{
    public class ItemFallState : ItemState, IUpdatebleState
    {
        private readonly IItemMoveStateData _staticData;

        private Vector3 _positionRaycast;

        public ItemFallState(Item stateMachine,
            ItemInfo itemInfo) : base(stateMachine, itemInfo)
        {

        }

        public void Enter()
        {
            _itemInfo.Rigidbody.useGravity = true;
        }

        public void Exit()
        {
        }

        public void Update()
        {
            if (!IsFallen())
                return;


            _stateMachine.Enter<ItemRestState>();
        }

        private bool IsFallen() => 
            Physics.Raycast(_itemInfo.RaycastTransform.position, Vector3.down, out RaycastHit hit, 0.1f);
    }
}
