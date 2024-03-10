using Code.Logic;
using Code.StaticData;
using CodeBase.Infrastructure.States;
using UnityEngine;

namespace Code.Items.States
{
    public class ItemAttackState : ItemState, IUpdatebleState
    {
        private readonly IItemAttackStateData _staticData;

        public ItemAttackState(Item stateMachine, ItemInfo itemInfo, IItemAttackStateData staticData) : base(stateMachine, itemInfo)
        {
            _staticData = staticData;
        }
        public void Enter()
        {
            _itemInfo.Rigidbody.useGravity = true;
            _itemInfo.Rigidbody.AddForce(_itemInfo.Direction * (3f * 10f), ForceMode.Impulse);
        }

        private void Damage(Collider obj)
        {
            if (obj.TryGetComponent<IHealth>(out IHealth health))
            {
                health.TakeDamage(_staticData.Damage);
            }
        }

        public void Update()
        {

        }
        public void Exit()
        {
        }

    }
}
