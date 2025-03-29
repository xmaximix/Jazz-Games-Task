using VContainer;
using VContainer.Unity;

namespace Source.Scripts.DI_Container
{
    public class BaseLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            SetupInstallers(builder);
        }

        private void SetupInstallers(IContainerBuilder builder)
        {
            var installers = GetComponentsInChildren<IInstaller>();
            foreach (var installer in installers) installer.Install(builder);
        }
    }
}