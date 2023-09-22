using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

namespace Dota2.ShopSystem
{
    public class Shop : MonoBehaviour
    {
        public ItemSpriteData[] ItemSprites => itemSprites.ToArray();
        [SerializeField] public List<ItemSpriteData> itemSprites = new List<ItemSpriteData>();

        public ItemData[] Items => itemList.ToArray();
        [SerializeField] public List<ItemData> itemList = new List<ItemData>();
        public ItemData[] GetItemsByType(ItemType targetType)
        {
            var resultList = new List<ItemData>();

            foreach (var itemData in itemList)
            {
                if (itemData.type == targetType)
                {
                    int i = 0;
                    foreach (var itemSprite in ItemSprites)
                    {
                        if (itemData.displayName == itemSprite.displayName)
                        {
                            itemData.image = itemSprite.icon;
                        }
                        i++;
                    }
                    resultList.Add(itemData);
                }
            }
            return resultList.ToArray();
        }

    }
    [Serializable]
    public class ItemData
    {
        public string displayName;
        public string description;
        public ItemType type;
        public int count;
        public Sprite image;
    }

    [Serializable]
    public class ItemSpriteData
    {
        public string displayName;
        public Sprite icon;
    }
    public enum ItemType
    {
        BasicItem, UpgradeItem, NaturalItem
    }
}


