using Source.Scripts.Damage;
using Source.Scripts.Entity;
using Source.Scripts.Interactions;
using Source.Scripts.Movement;
using Source.Scripts.Player;
using UnityEngine;

namespace Source.Scripts.Enemy
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class EnemyEntity : EntityBehaviour<EnemyConfig>, ITriggered, ITrigger, IDamageSource
    {
        [SerializeField] private TriggerHandler targetTriggerHandler;
        public TriggerHandlerList TriggerHandlerList { get; private set; }
        
        public DamageSource Type => DamageSource.Enemy;
        
        private IMovement movementSystem;
        private EnemyBehindMovementCalc behindMovementCalc;
        private AttackController attackController;

        public TriggerType TriggerType => TriggerType.Enemy;

        public override void Initialize()
        {
            base.Initialize();

            TriggerHandlerList = new TriggerHandlerList();
            TriggerHandlerList.SetAllTriggerHandlersOnObject(transform);
            TriggerHandlerList.AddTriggerType(TriggerType.Player);
            targetTriggerHandler.OnTriggerEnter += OnTargetTrigger;

            attackController = new AttackController(this, config.AttackDelay);
            attackController.SetWeapon(config.WeaponPrefab, transform);
            
            movementSystem = new MovementSystem(GetComponent<Rigidbody2D>(), config.MoveSpeed);
            behindMovementCalc = new EnemyBehindMovementCalc(transform, movementSystem, config.FollowOffset);
            behindMovementCalc.TargetPositionReached += () =>
            {
                attackController.Attack(Vector2.up);
            };
        }

        private void OnTargetTrigger(Collider2D obj)
        {
            if (obj.TryGetComponent(out PlayerEntity player))
            {
                behindMovementCalc.SetTarget(player.transform);
            }
        }

        protected override void Update()
        {
            base.Update();
            behindMovementCalc.UpdateMoveDirection();
            movementSystem.Move();
        }
    }
}