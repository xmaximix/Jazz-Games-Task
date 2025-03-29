using UnityEngine;

namespace Source.Scripts.Movement
{
    public interface IMovement
    {
        void SetMoveDirection(Vector2 moveDirection);
        void Move();
    }
}