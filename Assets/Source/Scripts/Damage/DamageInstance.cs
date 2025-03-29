namespace Source.Scripts.Damage
{
    public class DamageInstance
    {
        public IDamageSource DamageSource { get; }
        public int DamageAmount { get; }

        public DamageInstance(IDamageSource damageSource, int damageAmount)
        {
            DamageSource = damageSource;
            DamageAmount = damageAmount;
        }
    }
}