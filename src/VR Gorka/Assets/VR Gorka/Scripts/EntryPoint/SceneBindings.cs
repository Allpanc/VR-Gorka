using Dreamteck.Splines;
using UnityEngine;
using VrGorka.UI;

namespace VrGorka.EntryPoint
{
    public class SceneBindings : MonoBehaviour
    {
        public Transform trainParent;
        public Transform playerParent;
        public GameObject teleport;
        public GameObject teleportArea;
        public SplineComputer mainSpline;
        public SplineComputer[] branchSplines;
        public Node junction;
        public WagonListMenu wagonListMenu;
        public RouteControlsMenu routeControlsMenu;
        public StartMenu startMenu;
        public TutorialMenu tutorialMenu;
        public CountdownMenu countdownMenu;
        public LoseMenu loseMenu;
        public WinMenu winMenu;
    }
}