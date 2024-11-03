using UnityEngine;

namespace VrGorka.PlayerSpawn
{
    public class PlayerComponent
    {
        public IController controller => _controller;
        public IModel model => _model;
        
        readonly Interface.Controller _controller;
        readonly Interface.Model _model;
        
        public PlayerComponent(Transform playerParent)
        {
            Data.PlayerSpawnerConfig playerSpawnerConfig = 
                Resources.Load<Data.PlayerSpawnerConfig>("PlayerSpawnerConfig");

            var playerSpawnData = new Data.PlayerSpawnData();
            var playerFactory = new Logic.PlayerFactory(
                playerSpawnerConfig,
                playerSpawnData, 
                playerParent);

            var controller = new Interface.Controller(playerFactory);
            var model = new Interface.Model(playerSpawnData);

            _model = model;
            _controller = controller;
        }
    }
}