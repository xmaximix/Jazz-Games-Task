using Source.Scripts.Damage;
using Source.Scripts.Weapons.Configs;
using UnityEngine;

namespace Source.Scripts.Weapons
{
    public class RangeWeapon : BaseWeapon
    {
        [SerializeField] private RangeWeaponConfig rangeWeaponConfig;
        public override WeaponType WeaponType => WeaponType.Range;

        protected override void AttackDown()
        {
            base.AttackDown();
            SpawnProjectile(Vector2.down);
        }

        protected override void AttackLeft()
        {
            base.AttackLeft();
            SpawnProjectile(Vector2.left);
        }
        
        protected override void AttackRight()
        {
            base.AttackRight();
            SpawnProjectile(Vector2.right);
        }
        
        protected override void AttackUp()
        {
            base.AttackUp();
            SpawnProjectile(Vector2.up);
        }

        private void SpawnProjectile(Vector2 direction)
        {
            var projectile = Instantiate(rangeWeaponConfig.ProjectilePrefab, transform.position, Quaternion.identity);
            projectile.Initialize(direction, rangeWeaponConfig.ProjectileSpeed, 
                5f, new DamageInstance(damageSource, rangeWeaponConfig.DamageAmount));
        }
    }
}