using Source.Scripts.Input;
using VContainer;

namespace Source.Scripts.DI_Container
{
    public class InputInstaller : BaseInstaller
    {
        public override void Install(IContainerBuilder builder)
        {
            var inputManager = new InputManager();
            inputManager.Initialize();
            builder.RegisterInstance(inputManager);
        }
    }
}