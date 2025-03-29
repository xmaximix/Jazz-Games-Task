using Source.Scripts.Entity;
using Source.Scripts.Weapons;
using UnityEngine;

namespace Source.Scripts.Enemy
{
    [CreateAssetMenu(menuName = "Entities/Enemy Config")]
    public class EnemyConfig : EntityConfig
    {
        [field: SerializeField] public int MoveSpeed { get; private set; } = 1;
        [field: SerializeField] public BaseWeapon WeaponPrefab { get; private set; }
        [field: SerializeField] public float AttackDelay { get; private set; }
        [field: SerializeField] public float FollowOffset { get; private set; }
    }
}