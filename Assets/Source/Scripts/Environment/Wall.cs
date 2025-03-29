using Source.Scripts.Interactions;
using UnityEngine;

namespace Source.Scripts.Environment
{
    public class Wall : MonoBehaviour, ITriggered
    {
        public TriggerType TriggerType => TriggerType.Wall;
    }
}