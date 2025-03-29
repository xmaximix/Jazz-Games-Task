using System;
using Source.Scripts.Damage;
using UnityEngine;

namespace Source.Scripts.Health
{
    public class EntityHealth
    {
        public event Action Damaged;
        public event Action Died;
        
        private int currentHealth;

        public EntityHealth(int currentHealth)
        {
            this.currentHealth = currentHealth;
        }
        
        public void TakeDamage(DamageInstance damage)
        {
            var amount = damage.DamageAmount;
            
            if (amount <= 0 || currentHealth <= 0) return;

            currentHealth -= amount;
            Damaged?.Invoke();
            
            if (currentHealth <= 0)
            {
                Died?.Invoke();
                currentHealth = 0;
            }
        }
    }
}