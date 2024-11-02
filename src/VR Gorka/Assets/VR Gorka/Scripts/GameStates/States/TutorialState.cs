using VrGorka.UI;

namespace VrGorka.GameStates
{
    class TutorialState : IState
    {
        public static bool isTutorialCompleted { get; private set; }
        
        readonly GameStateMachine _gameStateMachine;
        readonly TutorialMenu _tutorialMenu;

        public TutorialState(
            GameStateMachine gameStateMachine, 
            TutorialMenu tutorialMenu)
        {
            _gameStateMachine = gameStateMachine;
            _tutorialMenu = tutorialMenu;
        }
        
        public void Enter()
        {
            _tutorialMenu.gameObject.SetActive(true);
            _tutorialMenu.tutorialCompleted += OnTutorialCompleted;
        }

        public void Exit()
        {
            _tutorialMenu.tutorialCompleted -= OnTutorialCompleted;
            _tutorialMenu.gameObject.SetActive(false);
        }

        private void OnTutorialCompleted()
        {
            isTutorialCompleted = true;
            _gameStateMachine.Enter<StartState>();
        }
    }
}