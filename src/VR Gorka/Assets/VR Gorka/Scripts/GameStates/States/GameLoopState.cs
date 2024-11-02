using System.Collections;
using UnityEngine;

namespace VrGorka.GameStates
{
    class GameLoopState : IState
    {
        TrainViewGeneration.TrainViewData trainViewData => 
            _playerComponents.trainViewGeneratorComponent.model.trainViewData;
        RouteJournal.IEvents routeJournalEvents =>
            _playerComponents.routeJournalComponent.events;
        RouteJournal.IModel routeJournalModel =>
            _playerComponents.routeJournalComponent.model;
        
        TrainViewGeneration.IModel trainViewModel =>
            _playerComponents.trainViewGeneratorComponent.model;
        
        readonly GameStateMachine _gameStateMachine;
        readonly PlayerComponents.PlayerComponents _playerComponents;
        readonly Utils.CoroutineRunner _coroutineRunner;
        readonly UI.WagonListMenu _wagonListMenu;
        readonly UI.RouteControlsMenu _routeControlsMenu;
        Coroutine _wagonsCoroutine;

        public GameLoopState(
            GameStateMachine gameStateMachine, 
            PlayerComponents.PlayerComponents playerComponents,
            UI.WagonListMenu wagonListMenu,
            UI.RouteControlsMenu routeControlsMenu)
        {
            _gameStateMachine = gameStateMachine;
            _playerComponents = playerComponents;
            _wagonListMenu = wagonListMenu;
            _routeControlsMenu = routeControlsMenu;
            
            GameObject gameObject = new GameObject("[COROUTINE RUNNER]");
            _coroutineRunner = gameObject.AddComponent<Utils.CoroutineRunner>();
        }

        public void Enter()
        {
            _wagonListMenu.gameObject.SetActive(true);
            _routeControlsMenu.gameObject.SetActive(true);
            
            _wagonsCoroutine = _coroutineRunner.RunCoroutine(MoveWagons());
            routeJournalEvents.wrongTrackChosen += OnWrongTrackChosen;
            routeJournalEvents.rightTrackChosen += OnRightTrackChosen;
            routeJournalEvents.succesfullyCompleted += OnSuccessfullyCompleted;
            
            foreach (TrainViewGeneration.WagonView wagonView in trainViewData.wagonViews)
            {
                wagonView.routeSwitched += OnRouteSwitched;
            }
        }

        private void OnRouteSwitched(string id, int routeIndex)
        {
            _playerComponents.routeJournalComponent.controller.SetChosenTrack(id, routeIndex);
        }

        public void Exit()
        {
            _routeControlsMenu.gameObject.SetActive(false);
            
            routeJournalEvents.wrongTrackChosen -= OnWrongTrackChosen;
            routeJournalEvents.rightTrackChosen -= OnRightTrackChosen;
            routeJournalEvents.succesfullyCompleted -= OnSuccessfullyCompleted;
            
            _coroutineRunner.EndCoroutine(_wagonsCoroutine);

            StopWagons();
        }

        private void OnRightTrackChosen()
        {
            _wagonListMenu.UpdateStatus(routeJournalModel.GetStatusMap());
        }

        private void OnWrongTrackChosen()
        {
            _wagonListMenu.UpdateStatus(routeJournalModel.GetStatusMap());
            _gameStateMachine.Enter<LoseState>();
        }

        private void OnSuccessfullyCompleted()
        {
            _gameStateMachine.Enter<WinState>();
        }

        IEnumerator MoveWagons()
        {
            for (var index = trainViewData.wagonViews.Count - 1; index >= 0; index--)
            {
                TrainViewGeneration.WagonView wagonView = trainViewData.wagonViews[index];
                wagonView.movable.StartMovement(trainViewModel.wagonsSpeed);
                yield return new WaitForSeconds(trainViewModel.timeBetweenWagons);
            }
        }

        private void StopWagons()
        {
            foreach (TrainViewGeneration.WagonView wagonView in trainViewData.wagonViews)
            {
                wagonView.movable.StopMovement();
            }
        }
    }
}