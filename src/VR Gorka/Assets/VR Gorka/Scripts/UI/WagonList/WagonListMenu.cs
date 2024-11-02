using System.Collections.Generic;
using UnityEngine;

namespace VrGorka.UI
{
    public class WagonListMenu : MonoBehaviour
    {
        public class Context
        {
            public WagonListGeneration.WagonListData wagonListData;
        }
        
        [SerializeField] RectTransform _itemsContainer;
        [SerializeField] WagonListItemWidget _itemWidgetPrefab;

        private Dictionary<string,WagonListItemWidget> _wagonInfoWidgetsMap;
        
        public void Prepare(Context context)
        {
            GenerateWagonListItemWidgets(context.wagonListData);
        }

        void GenerateWagonListItemWidgets(WagonListGeneration.WagonListData wagonListData)
        {
            _wagonInfoWidgetsMap = new ();
            
            for (var index = wagonListData.items.Count - 1; index >= 0; index--)
            {
                var wagonListItemData = wagonListData.items[index];
                WagonListItemWidget itemWidget = Instantiate(_itemWidgetPrefab, _itemsContainer);

                var context = new WagonListItemWidget.Context
                {
                    wagonListItemData = wagonListItemData
                };

                itemWidget.Prepare(context);
                _wagonInfoWidgetsMap[wagonListItemData.wagonId] = itemWidget;
            }
        }

        public void UpdateStatus(Dictionary<string, RouteJournal.Status> statusMap)
        {
            foreach (var (id, widget) in _wagonInfoWidgetsMap)
            {
                widget.DisplayStatus(statusMap[id]);
            }
        }
    }
}