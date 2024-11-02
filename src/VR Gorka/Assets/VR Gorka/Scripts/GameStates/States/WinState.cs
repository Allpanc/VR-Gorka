using UnityEngine.SceneManagement;

namespace VrGorka.GameStates
{
    class WinState : IState
    {
        readonly UI.WinMenu _winMenu;

        public WinState(UI.WinMenu winMenu)
        {
            _winMenu = winMenu;
        }

        public void Enter()
        {
            _winMenu.gameObject.SetActive(true);
            _winMenu.restartRequired += OnRestartRequired;
        }

        public void Exit()
        {

        }

        private void OnRestartRequired()
        {
            _winMenu.restartRequired -= OnRestartRequired;
            ReloadScene();
        }

        void ReloadScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}