using Source.Scripts.Health;
using Source.Scripts.Utils;
using UnityEngine;

namespace Source.Scripts.Entity
{
    [RequireComponent(typeof(DamageBlinkingSystem))]
    public abstract class EntityBehaviour<T> : GameplayBehaviour, IInitialize, IEntity where T : EntityConfig
    {
        public EntityHealth Health { get; private set; }
        [SerializeField] protected T config;
        
        private DamageBlinkingSystem damageBlinkingSystem;
        
        public virtual void Initialize()
        {
            damageBlinkingSystem = GetComponent<DamageBlinkingSystem>();
            damageBlinkingSystem.Initialize();
            
            Health = new EntityHealth(config.HealthAmount);
            Health.Died += OnDeath;
            Health.Damaged += () => damageBlinkingSystem.RepeatedBlink(1, .2f);
        }

        protected virtual void OnDeath()
        {
            Health.Died -= OnDeath;
            Destroy(gameObject, .1f);
        }
    }
}