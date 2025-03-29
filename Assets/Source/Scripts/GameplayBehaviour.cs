using System;
using UnityEngine;

namespace Source.Scripts
{
    public abstract class GameplayBehaviour : MonoBehaviour
    {
        private bool isPaused;

        protected virtual void Update()
        {
            if (isPaused) return;
        }

        public virtual void SetPaused(bool isPaused)
        {
            this.isPaused = isPaused;
        }
    }
}