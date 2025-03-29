using UnityEngine;

namespace Source.Scripts.Movement
{
    public class MovementSystem : IMovement
    {
        private readonly Rigidbody2D rb;
        private readonly float moveSpeed;
        private Vector2 moveDirection;

        public MovementSystem(Rigidbody2D rb, float moveSpeed)
        {
            this.moveSpeed = moveSpeed;
            this.rb = rb;
        }

        public void SetMoveDirection(Vector2 moveDirection)
        {
            this.moveDirection = moveDirection;
            if (moveDirection.sqrMagnitude > 0) 
            {
                this.moveDirection = moveDirection.normalized;
            }
        }

        public void Move()
        {
            rb.velocity = moveSpeed * moveDirection;
        }
    }
}