using UnityEngine;

namespace VrGorka.PlayerSpawn.Data
{
    [CreateAssetMenu(menuName = "VR Gorka/Create/Player Spawner Config", fileName = "PlayerSpawnerConfig")]
    class PlayerSpawnerConfig : ScriptableObject
    {
        public Interface.Player playerPrefab;
    }
}