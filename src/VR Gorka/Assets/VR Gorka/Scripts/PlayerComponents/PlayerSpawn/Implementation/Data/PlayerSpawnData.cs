namespace VrGorka.PlayerSpawn.Data
{
    class PlayerSpawnData
    {
        static bool _isSpawned;

        public bool isSpawned
        {
            get => _isSpawned;
            set => _isSpawned = value;
        }
    }
}