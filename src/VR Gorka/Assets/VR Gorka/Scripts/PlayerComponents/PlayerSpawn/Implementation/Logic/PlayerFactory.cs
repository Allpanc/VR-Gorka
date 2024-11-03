using UnityEngine;

namespace VrGorka.PlayerSpawn.Logic
{
    class PlayerFactory
    {
        readonly Data.PlayerSpawnerConfig _config;
        readonly Data.PlayerSpawnData _playerSpawnData;
        readonly Transform _parent;

        public PlayerFactory(
            Data.PlayerSpawnerConfig config, 
            Data.PlayerSpawnData playerSpawnData,
            Transform parent)
        {
            _config = config;
            _playerSpawnData = playerSpawnData;
            _parent = parent;
        }

        public IPlayer Create()
        {
            _playerSpawnData.isSpawned = true;
            Interface.Player player = Object.Instantiate(_config.playerPrefab, _parent);
            return player;
        }
    }
}