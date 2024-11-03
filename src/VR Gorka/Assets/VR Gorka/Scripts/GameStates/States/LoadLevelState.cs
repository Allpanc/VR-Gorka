using UnityEngine;

namespace VrGorka.GameStates
{
    public class LoadLevelState : IState
    {
        PlayerSpawn.IModel playerSpawnModel => _playerComponents.playerSpawnComponent.model;
        PlayerSpawn.IController playerSpawnController => _playerComponents.playerSpawnComponent.controller;
        
        readonly GameStateMachine _gameStateMachine;
        readonly PlayerComponents.PlayerComponents _playerComponents;
        readonly UI.WagonListMenu _wagonListMenu;
        readonly UI.RouteControlsMenu _routeControlsMenu;
        readonly UI.StartMenu _startMenu;
        readonly UI.TutorialMenu _tutorialMenu;
        readonly UI.CountdownMenu _countdownMenu;
        readonly GameObject _teleport;
        readonly GameObject _teleportArea;

        public LoadLevelState(
            GameStateMachine gameStateMachine,
            PlayerComponents.PlayerComponents playerComponents,
            UI.WagonListMenu wagonListMenu,
            UI.RouteControlsMenu routeControlsMenu,
            UI.StartMenu startMenu,
            UI.TutorialMenu tutorialMenu,
            UI.CountdownMenu countdownMenu,
            GameObject teleport,
            GameObject teleportArea)
        {
            _gameStateMachine = gameStateMachine;
            _playerComponents = playerComponents;
            _wagonListMenu = wagonListMenu;
            _routeControlsMenu = routeControlsMenu;
            _startMenu = startMenu;
            _tutorialMenu = tutorialMenu;
            _countdownMenu = countdownMenu;
            _teleport = teleport;
            _teleportArea = teleportArea;
        }

        public void Enter()
        {
            SpawnPlayer();
            
            _teleport.gameObject.SetActive(true);
            _teleportArea.gameObject.SetActive(true);
            
            TrainViewGeneration.TrainViewData trainViewData = 
                _playerComponents.trainViewGeneratorComponent.model.trainViewData;
            
            WagonListGeneration.WagonListData wagonListData =
                _playerComponents.wagonListGenerationComponent.model.wagonListData;
            
            _wagonListMenu.gameObject.SetActive(true);
            _routeControlsMenu.gameObject.SetActive(true);
            
            _wagonListMenu.Prepare(new UI.WagonListMenu.Context
            {
                wagonListData = wagonListData
            });

            _routeControlsMenu.Prepare(new UI.RouteControlsMenu.Context
            {
                routeControlsController = _playerComponents.routeControlsComponent.controller,
                routeControlsModel = _playerComponents.routeControlsComponent.model,
                trainViewData = trainViewData
            });

            _wagonListMenu.gameObject.SetActive(false);
            _routeControlsMenu.gameObject.SetActive(false);
            _tutorialMenu.gameObject.SetActive(false);
            _startMenu.gameObject.SetActive(false);
            _countdownMenu.gameObject.SetActive(false);
            
            ShowStartOrTutorial();
        }

        public void Exit()
        {
            
        }

        private void SpawnPlayer()
        {
            bool isPlayerPresent = playerSpawnModel.isPlayerPresent;

            if (isPlayerPresent)
            {
                return;
            }

            var spawnPlayer = playerSpawnController.SpawnPlayer();
        }

        private void ShowStartOrTutorial()
        {
            if (!TutorialState.isTutorialCompleted)
            {
                _gameStateMachine.Enter<TutorialState>();
                return;
            }

            _gameStateMachine.Enter<StartState>();
        }
    }
}