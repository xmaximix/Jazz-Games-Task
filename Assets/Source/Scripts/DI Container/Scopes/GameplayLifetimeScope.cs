using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Source.Scripts.DI_Container
{
    public class GameplayLifetimeScope : BaseLifetimeScope
    {
        [SerializeField] private LifetimeScope parentScope;
        
        protected override void Configure(IContainerBuilder builder)
        {
            base.Configure(builder);
        }
    }
}