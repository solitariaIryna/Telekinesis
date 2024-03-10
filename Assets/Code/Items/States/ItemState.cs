
namespace Code.Items.States
{
    public class ItemState
    {
        protected readonly Item _stateMachine;
        protected readonly ItemInfo _itemInfo;

        public ItemState(Item stateMachine, ItemInfo itemInfo)
        {
            _stateMachine = stateMachine;
            _itemInfo = itemInfo;
        }
        
    }
}