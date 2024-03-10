namespace Code.StaticData
{
    public interface IItemLevitationStateData
    {
        public float Height { get; }
        public float RotationSpeedAroundAxis { get;}
        float RiseTime { get; }
        float ChanceChangeSide { get; }
        float MinTimeToChangeSide { get; }
        float MaxTimeToChangeSide { get; }
        float MoveSpeed { get; }
    }
  
}