using System.Collections.Generic;

namespace VrGorka.TrainDataGeneration
{
    public class TrainData
    {
        public List<WagonData> wagons;
    }
    
    public class WagonData
    {
        public string id;
        public WagonType type;
    }

    public enum WagonType
    {
        Container,
        Forest,
        Gondola,
        Tank,
        Platform
    }
}