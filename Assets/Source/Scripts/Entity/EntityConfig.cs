using UnityEngine;

namespace Source.Scripts.Entity
{
    public abstract class EntityConfig : ScriptableObject
    {
        [field: SerializeField] public int HealthAmount { get; private set; } = 200;
    }
}