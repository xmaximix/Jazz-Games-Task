using System;
using System.Collections.Generic;
using UnityEngine;

namespace Source.Scripts.Interactions
{
    [RequireComponent(typeof(Collider2D))]
    public class TriggerHandler : MonoBehaviour
    {
        private readonly HashSet<TriggerType> targetTypes = new();
        public event Action<Collider2D> OnTriggerEnter;
        public event Action<Collider2D> OnTriggerExit;

        public Collider2D Collider { get; private set; }
        
        protected virtual void Awake()
        {
            Collider = GetComponent<Collider2D>();
        }

        public void AddTriggerType(TriggerType triggerType)
        {
            targetTypes.Add(triggerType);
        }

        public void RemoveTriggerType(TriggerType triggerType)
        {
            targetTypes.Remove(triggerType);
        }

        public void ClearTypes()
        {
            targetTypes.Clear();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out ITriggered trigger) && targetTypes.Contains(trigger.TriggerType))
                OnTriggerEnter?.Invoke(collision);
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out ITriggered trigger) && targetTypes.Contains(trigger.TriggerType))
                OnTriggerExit?.Invoke(collision);
        }

        private void OnDestroy()
        {
            OnTriggerEnter = null;
            OnTriggerExit = null;
        }
    }
}