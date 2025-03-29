using System.Collections;
using Source.Scripts.Damage;
using Source.Scripts.Entity;
using Source.Scripts.Factories;
using UnityEngine;
using VContainer;

namespace Source.Scripts.Spawn
{
    public class EntitySpawnPoint : MonoBehaviour
    {
        [SerializeField] private MonoBehaviour entityPrefab;
        
        private MonoBehaviour currentEntity;
        private DiGameObjectsFactory diGameObjectsFactory;

        [Inject]
        private void Construct(DiGameObjectsFactory diGameObjectsFactory)
        {
            this.diGameObjectsFactory = diGameObjectsFactory;
        }
        
        private void Start()
        {
            SpawnEntity();
        }

        private IEnumerator RespawnCoroutine()
        {
            yield return new WaitForSeconds(5f);
            SpawnEntity();
        }

        private void SpawnEntity()
        {
            if (entityPrefab == null) return;
            
            currentEntity = diGameObjectsFactory.Create(entityPrefab, transform.position, Quaternion.identity);
            currentEntity.transform.SetParent(transform);

            if (currentEntity is IInitialize init)
            {
                init.Initialize();
            }

            if (currentEntity is IEntity entity)
            {
                entity.Health.Died += RecallSpawn;
            }
        }
        
        private void RecallSpawn()
        {
            StartCoroutine(RespawnCoroutine());
        }
    }
}