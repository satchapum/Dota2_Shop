using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;
using UnityEngine.UI;
using static Dota2.ShopSystem.Shop;

namespace Dota2.ShopSystem
{
    public class UIShop : MonoBehaviour
    {
        [Header("Item List")]
        [SerializeField] UIItem itemUIPrefab;
        [SerializeField] List<UIItem> itemUIList = new List<UIItem>();
        [SerializeField] GameObject description;


        void Start()
        {
            //Make sure to hide original blueprint of UIItem at the start.
            itemUIPrefab.gameObject.SetActive(false);
        }
        public void ClearAllItemUIs()
        {
            foreach (UIItem uiItem in itemUIList)
                Destroy(uiItem.gameObject);

            itemUIList.Clear();
        }

        public void SetItemList(UIItem_Data[] uiDatas)
        {
            ClearAllItemUIs();
            foreach (var uiItemData in uiDatas)
            {
                var newItemUI = Instantiate(itemUIPrefab, itemUIPrefab.transform.parent, false);

                newItemUI.gameObject.SetActive(true);
                itemUIList.Add(newItemUI);
                newItemUI.SetData(uiItemData);
            }
        }

        public void ShowItemDescription(Vector3 position)
        {
            description.SetActive(true);
            description.transform.position = position;
        }

        public void HideItemDescription()
        {
            description.SetActive(false);
        }
    }

    [Serializable]
    public class CategoryInfo
    {
        public string name;
    }

}

