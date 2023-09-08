using Dota2.ShopSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Category_Basic : Category
{
    [Header("CategoryIndex And GameObject")]
    [SerializeField] int categoryIndexOfBasicItem = 0;
    [SerializeField] GameObject naturalItemGameObject;
    [SerializeField] ItemListPresenter itemListPresenter;
    public override void SetCategoryIndex(GameObject nameCategory)
    {
        if (nameCategory.name == naturalItemGameObject.name)
        {
            itemListPresenter.currentCategoryIndex = categoryIndexOfBasicItem;
            itemListPresenter.RefreshUI();
        }
    }
}
