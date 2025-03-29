using System;
using Source.Scripts.Damage;
using Source.Scripts.Weapons;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Source.Scripts
{
    public class AttackController
    {
        private readonly IDamageSource damageSource;
        private readonly float attackDelay;
        
        private BaseWeapon currentWeapon;
        private float lastAttackTime;

        public AttackController(IDamageSource damageSource, float attackDelay)
        {
            this.attackDelay = attackDelay;
            this.damageSource = damageSource;
        }
        
        public void SetWeapon(BaseWeapon weaponPrefab, Transform owner)
        { 
            currentWeapon = Object.Instantiate(weaponPrefab, owner.transform.position,
                Quaternion.identity, owner.transform);
            
            currentWeapon.Initialize(damageSource);
        }

        public void Attack(Vector2 direction)
        {
            if (Time.time - lastAttackTime < attackDelay) return;

            lastAttackTime = Time.time;
            currentWeapon.StartAttack(direction);
        }
    }
}