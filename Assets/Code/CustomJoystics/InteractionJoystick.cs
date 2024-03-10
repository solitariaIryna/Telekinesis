using System;
using UnityEngine.EventSystems;

namespace Code.CustomJoystics
{
    public class InteractionJoystick : FloatingJoystick, IEndDragHandler
    {
        public Action Pressed;
        public Action Uped;
        public override void OnDrag(PointerEventData eventData)
        {
            base.OnDrag(eventData);
            Pressed?.Invoke();
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            Uped?.Invoke();
        }
    }
}