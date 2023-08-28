using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;


namespace Dota2.ShopSystem
{
    public class UIItem : MonoBehaviour, IPointerClickHandler, IClickable, IPointerExitHandler, IPointerEnterHandler
    {
        [SerializeField] Image itemImage;
        [SerializeField] TMP_Text countText;
        [SerializeField] UIShop uiShop;

        public void SetData(UIItem_Data data)
        {
            itemImage.sprite = data.itemData.icon;
            countText.text = "" + data.itemData.count;
        }
        public void OnPointerClick(PointerEventData eventData)
        {
            throw new System.NotImplementedException();
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
           uiShop.ShowItemDescription(transform.position);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            uiShop.HideItemDescription();
        }
    }
        public class UIItem_Data
        {
            public ItemData itemData;

            public UIItem_Data(ItemData itemData)
            {
                this.itemData = itemData;
            }
        }
    
}
