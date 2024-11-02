using UnityEngine;

namespace VrGorka.WagonListGeneration.Logic
{
    class WagonListDataGenerator
    {
        readonly int _trackCount;

        public WagonListDataGenerator(int trackCount)
        {
            _trackCount = trackCount;
        }
        
        public WagonListData GenerateWagonListData(TrainDataGeneration.TrainData trainData)
        {
            var wagonListData = new WagonListData
            {
                items = new()
            };

            foreach (TrainDataGeneration.WagonData wagonData in trainData.wagons)
            {
                var wagonListItemData = new WagonListItemData
                {
                    wagonId = wagonData.id,
                    targetTrackIndex = Random.Range(0, _trackCount - 1)
                };
                
                wagonListData.items.Add(wagonListItemData);
            }
            
            return wagonListData;
        }
    }
}