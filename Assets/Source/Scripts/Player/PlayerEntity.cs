using Source.Scripts.Damage;
using Source.Scripts.Entity;
using Source.Scripts.Input;
using Source.Scripts.Interactions;
using Source.Scripts.Movement;
using UnityEngine;
using VContainer;

namespace Source.Scripts.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerEntity : EntityBehaviour<PlayerConfig>, IDamageSource, ITriggered
    {
        private InputManager inputManager;
        private IMovement movement;
        private AttackController attackController;
        
        public DamageSource Type => DamageSource.Player;
        public TriggerType TriggerType => TriggerType.Player;

        [Inject]
        private void Construct(InputManager inputManager)
        {
            this.inputManager = inputManager;
        }

        public override void Initialize()
        {
            base.Initialize();

            movement = new MovementSystem(GetComponent<Rigidbody2D>(), config.MoveSpeed);
            
            attackController = new AttackController(this, config.AttackDelay);
            attackController.SetWeapon(config.WeaponPrefab, transform);
            
            SubscribeInput();
        }

        protected override void Update()
        {
            base.Update();
            movement.Move();
        }

        protected override void OnDeath()
        {
            base.OnDeath();
            UnsubscribeInput();
        }

        private void SubscribeInput()
        {
            inputManager.GameplayInput.AttackEvent += attackController.Attack;
            inputManager.GameplayInput.MoveEvent += movement.SetMoveDirection;
        }

        private void UnsubscribeInput()
        {
            inputManager.GameplayInput.AttackEvent -= attackController.Attack;
            inputManager.GameplayInput.MoveEvent -= movement.SetMoveDirection;
        }
    }
}