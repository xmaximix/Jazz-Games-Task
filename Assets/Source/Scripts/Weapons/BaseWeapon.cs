using System;
using Source.Scripts.Damage;
using UnityEngine;

namespace Source.Scripts.Weapons
{
    public abstract class BaseWeapon : MonoBehaviour
    {
        protected IDamageSource damageSource;
        public abstract WeaponType WeaponType { get; }

        public virtual void Initialize(IDamageSource damageSource)
        {
            this.damageSource = damageSource;
        }

        public void StartAttack(Vector2 direction)
        {
            SelectAttackMethod(direction.x, direction.y);
        } 

        protected virtual void AttackDown()
        {
        }

        protected virtual void AttackLeft()
        {
        }

        protected virtual void AttackRight()
        {
        }

        protected virtual void AttackUp()
        {
        }
        
        private void SelectAttackMethod(float horizontal, float vertical)
        {
            Action attackMethod = Math.Abs(horizontal) > Math.Abs(vertical)
                ? horizontal > 0 ? AttackRight : AttackLeft
                : vertical > 0
                    ? AttackUp
                    : AttackDown;
            attackMethod();
        }
    }

    public enum WeaponType
    {
        Melee = 0,
        Range = 10,
    }
}