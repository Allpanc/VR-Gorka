namespace VrGorka.PlayerSpawn.Interface
{
    class Model : IModel
    {
        public bool isPlayerPresent => _playerSpawnData.isSpawned;
        
        readonly Data.PlayerSpawnData _playerSpawnData;

        public Model(Data.PlayerSpawnData playerSpawnData)
        {
            _playerSpawnData = playerSpawnData;
        }
    }
}