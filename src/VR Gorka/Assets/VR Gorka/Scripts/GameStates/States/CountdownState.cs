namespace VrGorka.GameStates
{
    class CountdownState : IState
    {
        readonly GameStateMachine _gameStateMachine;
        readonly PlayerComponents.PlayerComponents _playerComponents;
        readonly UI.CountdownMenu _countdownMenu;

        public CountdownState(
            GameStateMachine gameStateMachine, 
            PlayerComponents.PlayerComponents playerComponents,
            UI.CountdownMenu countdownMenu)
        {
            _gameStateMachine = gameStateMachine;
            _playerComponents = playerComponents;
            _countdownMenu = countdownMenu;
        }

        public void Enter()
        {
            _countdownMenu.gameObject.SetActive(true);
            _countdownMenu.countdownCompleted += OnCountdownCompleted;
            _countdownMenu.StartCountdown();
        }

        public void Exit()
        {
            _countdownMenu.countdownCompleted -= OnCountdownCompleted;
            _countdownMenu.gameObject.SetActive(false);
        }

        private void OnCountdownCompleted()
        {
            _gameStateMachine.Enter<GameLoopState>();
        }
    }
}