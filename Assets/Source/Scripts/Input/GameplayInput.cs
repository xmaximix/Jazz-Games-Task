using System;
using UnityEngine;
using UnityEngine.InputSystem;
using static GameInput;

namespace Source.Scripts.Input
{
    public class GameplayInput : IGameplayActions
    {
        private readonly GameInput gameInput;
        
        public event Action<Vector2> AttackEvent;
        public event Action<Vector2> MoveEvent;

        public GameplayInput(GameInput gameInput)
        {
            this.gameInput = gameInput;
        }
        
        public void Initialize()
        {
            gameInput.Gameplay.SetCallbacks(this);
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            MoveEvent?.Invoke(context.ReadValue<Vector2>());
            
            if (context.phase == InputActionPhase.Canceled)
                MoveEvent?.Invoke(Vector2.zero);
        }

        public void OnAttack(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed) 
                AttackEvent?.Invoke(context.ReadValue<Vector2>());
        }

        public void Enable()
        {
            gameInput.Gameplay.Enable();
        }

        public void Disable()
        {
            gameInput.Gameplay.Disable();
        }
    }
}