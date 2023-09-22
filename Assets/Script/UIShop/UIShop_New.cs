using System.Collections.Generic;
using UnityEngine;
using Dota2.ShopSystem;
using System.Collections;
using DG.Tweening;
using TMPro;

public class UIShop_New : UIShopAbs
{
    [SerializeField] UIItem itemUIPrefab;
    [SerializeField] List<UIItem> itemUIList = new List<UIItem>();
    [SerializeField] GameObject description;
    [SerializeField] CanvasGroup newShopUI;


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

            newItemUI.gameObject.SetActive(true);
            newShopUI.alpha = 0;
            newShopUI.blocksRaycasts = false;
            newShopUI
                .DOFade(1f, 3f)
                .OnComplete(FadeInFinish)
                .SetUpdate(true);

            itemUIList.Add(newItemUI);
            newItemUI.SetData(uiItemData);
            newItemUI.SetDataSprite(uiItemData);

            yield return new WaitForSeconds(0.27f);
            
            newItemUI.name = uiItemData.itemData.displayName;
        }
    }
    void FadeInFinish()
    {
        newShopUI.blocksRaycasts = true;
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
