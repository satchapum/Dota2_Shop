using Dota2.ShopSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Category_Upgrade : Category
{
    [Header("CategoryIndex And GameObject")]
    [SerializeField] int categoryIndexOfUpgradeItem = 0;
    [SerializeField] GameObject naturalItemGameObject;
    [SerializeField] ItemListPresenter itemListPresenter;
    public override void SetCategoryIndex(GameObject nameCategory)
    {
        if (nameCategory.name == naturalItemGameObject.name)
        {
            itemListPresenter.currentCategoryIndex = categoryIndexOfUpgradeItem;
            itemListPresenter.RefreshUI();
        }
    }
}
