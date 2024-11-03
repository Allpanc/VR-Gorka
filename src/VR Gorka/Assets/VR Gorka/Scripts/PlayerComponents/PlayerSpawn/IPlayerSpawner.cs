namespace VrGorka.PlayerSpawn
{
    public interface IPlayerSpawner
    {
        bool IsPlayerPresent();
        void SpawnPlayer();
    }
}