using UnityEngine;
using VrGorka.GameStates;

namespace VrGorka.EntryPoint
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private SceneBindings _sceneBindings;

        void Start()
        {
            var gameStateMachineContext = new GameStateMachine.Context
            {
                playerComponents = GetPlayerComponents(),
                wagonListMenu = _sceneBindings.wagonListMenu,
                routeControlsMenu = _sceneBindings.routeControlsMenu,
                startMenu = _sceneBindings.startMenu,
                tutorialMenu = _sceneBindings.tutorialMenu,
                countdownMenu = _sceneBindings.countdownMenu,
                loseMenu = _sceneBindings.loseMenu,
                winMenu = _sceneBindings.winMenu,
                teleport = _sceneBindings.teleport,
                teleportArea = _sceneBindings.teleportArea
            };

            var gameStateMachine = new GameStateMachine(gameStateMachineContext);
            
            gameStateMachine.Enter<LoadLevelState>();
        }

        private PlayerComponents.PlayerComponents GetPlayerComponents()
        {
            var playerComponentsContext = new PlayerComponents.PlayerComponents.Context
            {
                trainParent = _sceneBindings.trainParent,
                playerParent = _sceneBindings.playerParent,
                mainSpline = _sceneBindings.mainSpline,
                branchSplines = _sceneBindings.branchSplines,
                junction = _sceneBindings.junction
            };

            var playerComponents = new PlayerComponents.PlayerComponents(playerComponentsContext);
            
            return playerComponents;
        }
    }
}