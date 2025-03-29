using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Source.Scripts.DI_Container
{
    public abstract class BaseInstaller : MonoBehaviour, IInstaller
    {
        public abstract void Install(IContainerBuilder builder);
    }
}