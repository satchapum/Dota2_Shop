using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


namespace Dota2.ShopSystem
{
    public class UIItem : MonoBehaviour
    {
        [SerializeField] Image itemImage;
        [SerializeField] TextMeshPro countText;

        public void SetData(UIItem_Data data)
        {
            itemImage.sprite = data.itemData.icon;
            countText.text = "X " + data.itemData.count;
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
