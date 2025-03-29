using Source.Scripts.Damage;
using Source.Scripts.Entity;
using Source.Scripts.Environment;
using Source.Scripts.Interactions;
using Source.Scripts.Movement;
using UnityEngine;

namespace Source.Scripts.Weapons.Projectiles
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class BaseProjectile : GameplayBehaviour, ITrigger
    {
        [SerializeField] private TriggerHandler damageTrigger;
        private IMovement movementSystem;
        private DamageInstance damageInstance;
        private float maxDistance;
        private Vector3 startPosition;
        public TriggerHandlerList TriggerHandlerList { get; private set; }

        public virtual void Initialize(Vector2 moveDirection, float moveSpeed, float maxTravelDistance, 
            DamageInstance damageInstance, float lifetime = 5f)
        {
            movementSystem = new MovementSystem(GetComponent<Rigidbody2D>(), moveSpeed);
            movementSystem.SetMoveDirection(moveDirection);
            
            this.maxDistance = maxTravelDistance;
            this.damageInstance = damageInstance;
            startPosition = transform.position;
            InitializeTrigger(damageInstance);
            
            Destroy(gameObject, lifetime);
        }

        private void InitializeTrigger(DamageInstance damageInstance)
        {
            TriggerHandlerList = new TriggerHandlerList();
            TriggerHandlerList.SetAllTriggerHandlersOnObject(transform);
            switch (damageInstance.DamageSource.Type)
            {
                case DamageSource.Player:
                    TriggerHandlerList.AddTriggerType(TriggerType.Enemy);
                    break;
                case DamageSource.Enemy:
                    TriggerHandlerList.AddTriggerType(TriggerType.Player);
                    break;
            }
            TriggerHandlerList.AddTriggerType(TriggerType.Wall);
            damageTrigger.OnTriggerEnter += OnDamageTrigger;
        }

        private void OnDamageTrigger(Collider2D obj)
        {
            if (obj.TryGetComponent(out IEntity entity))
            {
                entity.Health.TakeDamage(damageInstance);
                Destroy(gameObject);
            }
            else if (obj.TryGetComponent(out Wall wall))
            {
                Destroy(gameObject);
            }
        }

        protected override void Update()
        {
            base.Update();
            movementSystem.Move();
            if (Vector3.Distance(startPosition, transform.position) > maxDistance)
            {
                Destroy(gameObject);
            }
        }
    }
}