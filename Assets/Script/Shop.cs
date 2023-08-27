using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dota2.ShopSystem
{
    public class Shop : MonoBehaviour
    {
        public ItemData[] Items => itemList.ToArray();
        [SerializeField] List<ItemData> itemList = new List<ItemData>();
            public ItemData[] GetItemsByType(ItemType targetType)
        {
            //Create a list that will hold all the items that matched the targetType
            var resultList = new List<ItemData>();
            foreach (var itemData in itemList)
            {
                if (itemData.type == targetType)
                    resultList.Add(itemData);
            }

            //Return the result as Array not List. Because we don't want caller to modify the result afterward.
            return resultList.ToArray();
        }

        [Serializable]
        public class ItemData
        {
            public string displayName;
            public string description;
            public Sprite icon;
            public ItemType type;
            public int count;
        }

        public enum ItemType
        {
            BasicItem, UpgradeItem, NaturalItem
        }
    }   
}


