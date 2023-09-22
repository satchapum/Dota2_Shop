using System.Collections.Generic;
using UnityEngine;
using Dota2.ShopSystem;

public class UIShop_Old : UIShopAbs
{
    [SerializeField] UIItem itemUIPrefab;
    [SerializeField] List<UIItem> itemUIList = new List<UIItem>();
    [SerializeField] GameObject description;
    
    void Start()
    {
        itemUIPrefab.gameObject.SetActive(false);
    }

    public override void ClearAllItemUIs()
    {
        foreach (UIItem uiItem in itemUIList)
            Destroy(uiItem.gameObject);

        itemUIList.Clear();
    }

    public override void SetItemList(UIItem_Data[] uiDatas)
    {
        ClearAllItemUIs();
        foreach (var uiItemData in uiDatas)
        {
            var newItemUI = Instantiate(itemUIPrefab, itemUIPrefab.transform.parent, false);

            newItemUI.gameObject.SetActive(true);
            itemUIList.Add(newItemUI);
            newItemUI.SetData(uiItemData);

            newItemUI.name = uiItemData.itemData.displayName;
            newItemUI.SetData(uiItemData);
            newItemUI.SetDataSprite(uiItemData);

        }
    }

    public override void ShowItemDescription(Vector3 position)
    {
        description.SetActive(true);
        description.transform.position = position;
    }

    public override void HideItemDescription()
    {
        description.SetActive(false);
    }

}
