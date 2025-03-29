using System;
using Source.Scripts.Movement;
using UnityEngine;

namespace Source.Scripts.Enemy
{
    public class EnemyBehindMovementCalc
    {
        private Transform owner;
        private Transform target;
        private IMovement movementSystem;
        private float offset;

        public event Action TargetPositionReached;

        public EnemyBehindMovementCalc(Transform owner, IMovement movementSystem, float offset)
        {
            this.offset = offset;
            this.owner = owner;
            this.movementSystem = movementSystem;
        }

        public void SetTarget(Transform target)
        {
            this.target = target;
        }

        private Vector2 CalculateMoveDirection()
        {
            var targetPosition = new Vector2(target.position.x, target.position.y - offset);
            var moveDirection = targetPosition - (Vector2)owner.position;

            if (moveDirection.magnitude < 0.5f) 
            {
                TargetPositionReached?.Invoke();
            }

            return moveDirection.normalized;
        }

        public void UpdateMoveDirection()
        {
            if (target == null)
            {
                movementSystem.SetMoveDirection(Vector2.zero);
                return;
            }
            movementSystem.SetMoveDirection(CalculateMoveDirection());
        }
    }
}