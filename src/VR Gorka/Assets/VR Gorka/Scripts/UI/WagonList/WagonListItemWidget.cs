using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace VrGorka.UI
{
    class WagonListItemWidget : MonoBehaviour
    {
        public class Context
        {
            public WagonListGeneration.WagonListItemData wagonListItemData;
        }
        
        [SerializeField] TMP_Text _idText;
        [SerializeField] TMP_Text _targetTrackText;
        [SerializeField] Image _statusImage; 
        [SerializeField] Sprite _successSprite;
        [SerializeField] Sprite _failSprite;
        [SerializeField] Sprite _unsetSprite;
        
        Dictionary<RouteJournal.Status, Sprite> _statusSpriteMap;
        
        public void Prepare(Context context)
        {
            DisplayItem(context.wagonListItemData);
            DisplayStatus(RouteJournal.Status.Unset);
        }

        public void DisplayStatus(RouteJournal.Status status)
        {
            Sprite sprite = GetStatusSpriteMap()[status];

            _statusImage.sprite = sprite;
        }
        
        void DisplayItem(WagonListGeneration.WagonListItemData wagonListItemData)
        {
            _idText.text = wagonListItemData.wagonId;
            _targetTrackText.text = (wagonListItemData.targetTrackIndex + 1).ToString();
            _statusImage.sprite = _unsetSprite;
        }

        Dictionary<RouteJournal.Status, Sprite> GetStatusSpriteMap()
        {
            return _statusSpriteMap ??= new Dictionary<RouteJournal.Status, Sprite>
            {
                { RouteJournal.Status.Success , _successSprite},
                { RouteJournal.Status.Fail , _failSprite},
                { RouteJournal.Status.Unset , _unsetSprite},
            };
        }
    }
}