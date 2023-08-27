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
        [Header("Category")]
        [SerializeField] Image categoryIconImage;
        [SerializeField] Text categoryText;

        [Header("Current Item")]
        [SerializeField] Image currentItemIconImage;
        [SerializeField] Text descriptionText;

        [Header("Item List")]
        [SerializeField] UIItem itemUIPrefab;
        [SerializeField] List<UIItem> itemUIList = new List<UIItem>();

        public void SetCategory(CategoryInfo info)
        {
            categoryIconImage.sprite = info.icon;
            categoryText.text = info.name;
        }

        public void SetCurrentItemInfo(ItemData data)
        {
            descriptionText.text = data.description;
            currentItemIconImage.sprite = data.icon;
        }
    }

    [Serializable]
    public class CategoryInfo
    {
        public string name;
        public Sprite icon;
    }
}

