namespace Source.Scripts.Input
{
    public class InputManager
    {
        public GameplayInput GameplayInput { get; }

        public InputManager()
        {
            var gameInput = new GameInput();
            GameplayInput = new GameplayInput(gameInput);
        }

        public void Initialize()
        {
            GameplayInput.Initialize();
            GameplayInput.Enable();
        }
    }
}