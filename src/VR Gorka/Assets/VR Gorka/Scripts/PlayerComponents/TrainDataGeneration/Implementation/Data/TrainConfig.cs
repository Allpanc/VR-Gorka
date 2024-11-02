using UnityEngine;

namespace VrGorka.TrainDataGeneration
{
    [CreateAssetMenu(menuName = "VR Gorka/Create/Train Config", fileName = "TrainConfig")]
    class TrainConfig : ScriptableObject
    {
        public int wagonsCount;
    }
}