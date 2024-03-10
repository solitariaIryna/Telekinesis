using UnityEngine;

namespace Code.Items
{
    [System.Serializable]
    public class ItemInfo
    {
        [field: SerializeField] public ItemHealth Health { get; private set;}
        [field: SerializeField] public Rigidbody Rigidbody { get; private set; }
        [field: SerializeField] public MeshRenderer Renderer { get; set; }
        [field: SerializeField] public Transform Transform { get; private set; }
        [field: SerializeField] public Transform RaycastTransform { get; private set;}
        
        [field: SerializeField] public Vector3 Direction { get; set; }

        public Vector3 Position
        {
            get 
                => Transform.position;
            set 
                => Transform.position = value;
        }

        public Color Color
        {
            get
                => Renderer.material.color;
            set
                => Renderer.material.color = value;
        }
    }
}