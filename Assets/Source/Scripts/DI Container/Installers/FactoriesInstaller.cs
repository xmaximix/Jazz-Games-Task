using Source.Scripts.Factories;
using VContainer;

namespace Source.Scripts.DI_Container
{
    public class FactoriesInstaller : BaseInstaller
    {
        public override void Install(IContainerBuilder builder)
        {
            builder.Register<DiGameObjectsFactory>(Lifetime.Singleton);
        }
    }
}