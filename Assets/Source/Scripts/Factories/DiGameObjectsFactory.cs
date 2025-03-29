using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Source.Scripts.Factories
{
    public class DiGameObjectsFactory
    {
        private readonly IObjectResolver container;

        public DiGameObjectsFactory(IObjectResolver container)
        {
            this.container = container;
        }

        public T Create<T>(T prefab) where T : MonoBehaviour
        {
            return container.Instantiate(prefab);
        }
        
        public T Create<T>(T prefab, Vector3 position, Quaternion rotation) where T : MonoBehaviour
        {
            return container.Instantiate(prefab, position, rotation);
        }
    }
}