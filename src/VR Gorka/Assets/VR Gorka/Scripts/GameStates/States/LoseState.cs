using UnityEngine.SceneManagement;

namespace VrGorka.GameStates
{
    class LoseState : IState
    {
        readonly UI.LoseMenu _loseMenu;

        public LoseState(UI.LoseMenu loseMenu)
        {
            _loseMenu = loseMenu;
        }

        public void Enter()
        {
            _loseMenu.gameObject.SetActive(true);
            _loseMenu.restartRequired += OnRestartRequired;
        }

        public void Exit()
        {

        }

        private void OnRestartRequired()
        {
            _loseMenu.restartRequired -= OnRestartRequired;
            ReloadScene();
        }

        void ReloadScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}