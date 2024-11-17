using System.Collections;
using System.Collections.Generic;
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
        
        RouteParameters.IRouteParametersProvider routeParametersProvider =>
            _playerComponents.routeParametersComponent.routeParametersProvider;
        
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
            _routeControlsMenu.EnableInteraction();
            
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
            SetStopPercent(id, routeIndex);

            _playerComponents.routeJournalComponent.controller.SetChosenTrack(id, routeIndex);
        }

        private void SetStopPercent(string id, int routeIndex)
        {
            TrainViewGeneration.WagonView wagonView = trainViewData.wagonViews
                .Find(x => x.id == id);
            
            var wagonsCountOnChosenRoute = routeJournalModel.GetWagonsCountOnRoute(routeIndex);
            float wagonGapForChosenRoute = routeParametersProvider.GetWagonGapForRoute(routeIndex);
            float stopPercent = 1 - (wagonGapForChosenRoute * wagonsCountOnChosenRoute);
            RouteStop.IRouteStopper routeStopper = wagonView.routeStopper;
            routeStopper.SetStopPercent(stopPercent);
            routeStopper.isActive = true;
        }

        public void Exit()
        {
            _routeControlsMenu.DisableInteraction();
            
            routeJournalEvents.wrongTrackChosen -= OnWrongTrackChosen;
            routeJournalEvents.rightTrackChosen -= OnRightTrackChosen;
            routeJournalEvents.succesfullyCompleted -= OnSuccessfullyCompleted;
        }

        private void OnRightTrackChosen()
        {
            _wagonListMenu.UpdateStatus(routeJournalModel.GetStatusMap());
        }

        private void OnWrongTrackChosen()
        {
            _wagonListMenu.UpdateStatus(routeJournalModel.GetStatusMap());
            
            _coroutineRunner.EndCoroutine(_wagonsCoroutine);
            StopWagons();
            
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