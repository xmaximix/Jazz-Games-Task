using Source.Scripts.Weapons.Projectiles;
using UnityEngine;

namespace Source.Scripts.Weapons.Configs
{
    [CreateAssetMenu(menuName = "Weapons/Range Weapon Config")]
    public class RangeWeaponConfig : ScriptableObject
    {
        [field: SerializeField] public BaseProjectile ProjectilePrefab { get; private set; }
        [field: SerializeField] public float ProjectileSpeed { get; private set; }
        [field: SerializeField] public int DamageAmount { get; private set; }
    }
}