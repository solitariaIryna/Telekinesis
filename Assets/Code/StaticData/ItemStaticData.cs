using UnityEngine;

namespace Code.StaticData
{
    [CreateAssetMenu(fileName = "ItemData", menuName = "StaticData/ItemData")]
    public class ItemStaticData : ScriptableObject, IItemLevitationStateData, IItemAttackStateData
    {
        [SerializeField] private int _level;
        [SerializeField] private float _weight;
        [SerializeField] private float _durability;
        [SerializeField] private float _size;
        [field: SerializeField] public int MaxHealth { get; private set; }

        [field: Header("AttackState")]
        [field: SerializeField] public int Damage { get; private set; }

        [field: Header("LevitationState")]
        [field: SerializeField] public float Height { get; private set; }
        [field: SerializeField] public float RotationSpeedAroundAxis { get; private set; }
        [field: SerializeField] public float RiseTime { get; private set; }
        [field: SerializeField , Range(0, 1)] public float ChanceChangeSide { get; private set; }
        [field: SerializeField] public float MinTimeToChangeSide { get; private set; }
        [field: SerializeField] public float MaxTimeToChangeSide { get;  private set;}

        [field: SerializeField] public float MoveSpeed { get; private set; }
    }
  
}