using VrGorka.UI;

namespace VrGorka.GameStates
{
    class StartState : IState
    {
        private readonly StartMenu _startMenu;
        readonly GameStateMachine _gameStateMachine;

        public StartState(
            GameStateMachine gameStateMachine, 
            StartMenu startMenu)
        {
            _startMenu = startMenu;
            _gameStateMachine = gameStateMachine;
        }

        public void Enter()
        {
            _startMenu.gameObject.SetActive(true);
            _startMenu.startRequired += OnStartRequired;
        }

        public void Exit()
        {
            _startMenu.startRequired -= OnStartRequired;
            _startMenu.gameObject.SetActive(false);
        }

        private void OnStartRequired()
        {
            _gameStateMachine.Enter<CountdownState>();
        }
    }
}