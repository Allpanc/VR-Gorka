using System;
using System.Collections.Generic;

namespace VrGorka.TrainDataGeneration.Logic
{
    class TrainDataGenerator
    {
        public TrainData GenerateNewTrainData(int wagonCount)
        {
            var trainData = new TrainData
            {
                wagons = new List<WagonData>()
            };

            for (int i = 0; i < wagonCount; i++)
            {
                string id = GenerateWagonId();
                WagonType type = GenerateRandomWagonType();
        
                var wagonData = new WagonData
                {
                    id = id, 
                    type = type
                };
                
                trainData.wagons.Add(wagonData);
            }

            return trainData;
        }
        
        private string GenerateWagonId()
        {
            var random = new Random();
            return random.Next(10000000, 100000000).ToString();
        }
        
        private WagonType GenerateRandomWagonType()
        {
            var random = new Random();
            return (WagonType)random.Next(0, Enum.GetValues(typeof(WagonType)).Length);
        }
    }
}