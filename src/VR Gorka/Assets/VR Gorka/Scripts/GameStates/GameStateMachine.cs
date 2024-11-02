using System;
using System.Collections.Generic;

namespace VrGorka.GameStates
{
    public class GameStateMachine
    {
        public class Context
        {
            public PlayerComponents.PlayerComponents playerComponents;
            public UI.WagonListMenu wagonListMenu;
            public UI.RouteControlsMenu routeControlsMenu;
            public UI.StartMenu startMenu;
            public UI.TutorialMenu tutorialMenu;
            public UI.CountdownMenu countdownMenu;
            public UI.LoseMenu loseMenu;
            public UI.WinMenu winMenu;
        }
        
        readonly Dictionary<Type, IExitableState> _states;
        IExitableState _activeState;

        public GameStateMachine(Context context)
        {
            _states = new Dictionary<Type, IExitableState>
            {
                [typeof(LoadLevelState)] = new LoadLevelState(
                    this, 
                    context.playerComponents,
                    context.wagonListMenu,
                    context.routeControlsMenu,
                    context.startMenu,
                    context.tutorialMenu,
                    context.countdownMenu),
                
                [typeof(TutorialState)] = new TutorialState(
                    this,
                    context.tutorialMenu),
                
                [typeof(StartState)] = new StartState(
                    this, 
                    context.startMenu),
                
                [typeof(CountdownState)] = new CountdownState(
                    this, 
                    context.playerComponents,
                    context.countdownMenu),
                
                [typeof(GameLoopState)] = new GameLoopState(
                    this, 
                    context.playerComponents,
                    context.wagonListMenu,
                    context.routeControlsMenu),
                
                [typeof(LoseState)] = new LoseState(context.loseMenu),
                
                [typeof(WinState)] = new WinState(context.winMenu)
            };
        }

        public void Enter<TState>() where TState : class, IState
        {
            IState state = ChangeState<TState>();
            state.Enter();
        }

        public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedState<TPayload>
        {
            TState state = ChangeState<TState>();
            state.Enter(payload);
        }

        TState ChangeState<TState>() where TState : class, IExitableState
        {
            _activeState?.Exit();

            TState state = GetState<TState>();
            _activeState = state;

            return state;
        }

        TState GetState<TState>() where TState : class, IExitableState =>
            _states[typeof(TState)] as TState;
    }
}