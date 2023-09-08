using Dota2.ShopSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Category_Natural : Category
{
    [Header("CategoryIndex And GameObject")]
    [SerializeField] int categoryIndexOfNaturalItem = 0;
    [SerializeField] GameObject naturalItemGameObject;
    [SerializeField] ItemListPresenter itemListPresenter;
    public override void SetCategoryIndex(GameObject nameCategory)
    {
        if (nameCategory.name == naturalItemGameObject.name)
        {
            itemListPresenter.currentCategoryIndex = categoryIndexOfNaturalItem;
            itemListPresenter.RefreshUI();
        }
    }
}
