using System;
using System.Collections.Generic;
using UnityEngine;
using VrGorka.TrainDataGeneration;

namespace VrGorka.TrainViewGeneration
{
    [CreateAssetMenu(menuName = "VR Gorka/Create/Wagon View Config", fileName = "WagonViewConfig")]
    class WagonViewConfig : ScriptableObject
    {
        [Range(0f,1f)] public float wagonGap;
        public float timeBetweenWagons;
        public float wagonsSpeed;
        public List<WagonViewData> wagonPrefabs;
    }

    [Serializable]
    class WagonViewData
    {
        public WagonType type;
        public WagonView prefab;
    }
}