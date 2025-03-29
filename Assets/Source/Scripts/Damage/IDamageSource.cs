namespace Source.Scripts.Damage
{
    public interface IDamageSource
    {
        public DamageSource Type { get; }
    }

    public enum DamageSource
    {
        Default = 0,
        Player = 10,
        Enemy = 20,
        Wall = 30,
    }
}