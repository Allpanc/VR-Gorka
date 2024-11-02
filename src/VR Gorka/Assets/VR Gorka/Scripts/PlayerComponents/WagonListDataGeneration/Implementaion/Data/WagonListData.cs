using System;
using System.Collections.Generic;

namespace VrGorka.WagonListGeneration
{
    [Serializable]
    public class WagonListData
    {
        public List<WagonListItemData> items;
    }

    [Serializable]
    public class WagonListItemData
    {
        public string wagonId;
        public int targetTrackIndex;
    }
}