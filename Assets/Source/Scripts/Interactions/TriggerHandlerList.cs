using System.Collections.Generic;
using UnityEngine;

namespace Source.Scripts.Interactions
{
    public class TriggerHandlerList
    {
        private readonly HashSet<TriggerHandler> triggerHandlers = new();

        public void SetAllTriggerHandlersOnObject(Transform parent)
        {
            foreach (var handler in parent.GetComponents<TriggerHandler>())
            {
                AddTriggerHandler(handler);
            }

            foreach (var handler in parent.GetComponentsInChildren<TriggerHandler>())
            {
                AddTriggerHandler(handler);
            }
        }
        
        public void AddTriggerHandler(TriggerHandler triggerHandler)
        {
            triggerHandlers.Add(triggerHandler);
        }

        public void ClearTypes()
        {
            foreach (var handler in triggerHandlers)
            {
                handler.ClearTypes();
            }
        }

        public void RemoveTriggerHandler(TriggerHandler triggerHandler)
        {
            triggerHandlers.Remove(triggerHandler);
        }

        public void AddTriggerType(TriggerType triggerType)
        {
            foreach (var handler in triggerHandlers)
            {
                handler.AddTriggerType(triggerType);
            }
        }

        public void RemoveTriggerType(TriggerType triggerType)
        {
            foreach (var handler in triggerHandlers)
            {
                handler.RemoveTriggerType(triggerType);
            }
        }
    }
}