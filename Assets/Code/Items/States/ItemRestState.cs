using CodeBase.Infrastructure.States;
using UnityEngine;

namespace Code.Items.States
{
    public class ItemRestState : ItemState, IUpdatebleState
    {
        public ItemRestState(Item stateMachine, ItemInfo itemInfo) : base(stateMachine, itemInfo)
        {
            
        }

        private void EnterLevitate() => 
            _stateMachine.Enter<ItemLevitationState>();

        private void Highlight(bool isHighlight)
        {
            _itemInfo.Color = isHighlight ? Color.red : Color.white;
        }
        
        public void Enter()
        {
            _stateMachine.Levitation += EnterLevitate;
            _stateMachine.Highlight += Highlight;
            
            _itemInfo.Rigidbody.useGravity = false;
        }
        public void Update()
        {

        }
        public void Exit()
        {
            _stateMachine.Levitation -= EnterLevitate;
            _stateMachine.Highlight -= Highlight;
        }

    }
}