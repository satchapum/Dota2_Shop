using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dota2.ShopSystem;
public abstract class UIShopAbs : MonoBehaviour
{
    public abstract void ClearAllItemUIs();

    public abstract void SetItemList(UIItem_Data[] uiDatas);

    public abstract void ShowItemDescription(Vector3 position);

    public abstract void HideItemDescription();

} 
