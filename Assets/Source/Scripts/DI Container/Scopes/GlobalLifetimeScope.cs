using VContainer;

namespace Source.Scripts.DI_Container
{
    public class GlobalLifetimeScope : BaseLifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            base.Configure(builder);
        }
    }
}