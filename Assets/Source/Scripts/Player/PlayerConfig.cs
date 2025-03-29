using Source.Scripts.Entity;
using Source.Scripts.Weapons;
using UnityEngine;

namespace Source.Scripts.Player
{
    [CreateAssetMenu(menuName = "Entities/Player Config")]
    public class PlayerConfig : EntityConfig
    {
        [field: SerializeField] public int MoveSpeed { get; private set; } = 2;
        [field: SerializeField] public BaseWeapon WeaponPrefab { get; private set; }
        [field: SerializeField] public float AttackDelay { get; private set; } = .25f;
    }
}