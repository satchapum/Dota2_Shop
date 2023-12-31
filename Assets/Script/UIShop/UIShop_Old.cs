using System.Collections.Generic;
using UnityEngine;
using Dota2.ShopSystem;
using DG.Tweening;
using System.Collections;

public class UIShop_Old : UIShopAbs
{
    [SerializeField] UIItem itemUIPrefab;
    [SerializeField] List<UIItem> itemUIList = new List<UIItem>();
    [SerializeField] GameObject description;
    [SerializeField] CanvasGroup oldShopUI;
    
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
        StartCoroutine(ShowItemsWithDelay(uiDatas));
    }

    private IEnumerator ShowItemsWithDelay(UIItem_Data[] uiDatas)
    {

        foreach (var uiItemData in uiDatas)
        {
            var newItemUI = Instantiate(itemUIPrefab, itemUIPrefab.transform.parent, false);
            newItemUI.transform.localScale = Vector3.zero;

            newItemUI.transform.DOScale(1f, 1f);
            oldShopUI.alpha = 1;
            newItemUI.gameObject.SetActive(true);

            itemUIList.Add(newItemUI);
            newItemUI.SetData(uiItemData);

            yield return new WaitForSeconds(0.27f);

            newItemUI.name = uiItemData.itemData.displayName;
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
