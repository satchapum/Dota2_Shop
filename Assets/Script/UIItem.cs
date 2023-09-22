using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;


namespace Dota2.ShopSystem
{
    public class UIItem : MonoBehaviour,IPointerClickHandler, IClickable, IPointerExitHandler, IPointerEnterHandler
    {
        [SerializeField] Image itemImage;
        [SerializeField] TMP_Text countText;
        [SerializeField] Image iconItem;
        [SerializeField] TMP_Text nameText;
        [SerializeField] TMP_Text description;
        [SerializeField] TMP_Text price;
        [SerializeField] UIShop uiShop;

        [SerializeField] ItemData itemData;
        [SerializeField] ItemSpriteData itemSpriteData;
        
        [SerializeField] MoneySystem moneySystem;

        public UIItem_Data itemDescription;

        public void SetData(UIItem_Data data)
        {
            countText.text = "" + data.itemData.count;
            if(uiShop.shopTypeIndex == 1)
            {
                nameText.text = data.itemData.displayName;
                description.text = data.itemData.description;
            }
            
            Debug.Log(nameText.text);
            itemDescription = data;
            
        }
        
        public void SetDataSprite(UIItem_Data data)
        {
            itemImage.sprite = data.spriteData.icon;

        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (eventData.pointerEnter.transform.name == itemDescription.itemData.displayName && uiShop.shopTypeIndex == 0)
            {
                iconItem.sprite = itemDescription.spriteData.icon;
                nameText.text = itemDescription.itemData.displayName;
                description.text = itemDescription.itemData.description;
                price.text = itemDescription.itemData.count.ToString();
                uiShop.ShowItemDescription(transform.position);
            }
            
            Debug.Log("Enter");
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            uiShop.HideItemDescription();
            Debug.Log("Exit");
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (eventData.pointerEnter.transform.name == itemDescription.itemData.displayName)
            {
                Debug.Log("Comfirm Buy");
                moneySystem.moneyCount -= itemDescription.itemData.count;
            }
        }

        
    }
    public class UIItem_Data
    {
        public ItemData itemData;
        public ItemSpriteData spriteData;

        public UIItem_Data(ItemData itemData, ItemSpriteData spriteData)
        {
            this.itemData = itemData;
            this.spriteData = spriteData;
        }
    }

}
