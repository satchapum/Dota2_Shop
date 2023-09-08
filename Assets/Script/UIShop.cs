using UnityEngine;

namespace Dota2.ShopSystem
{
    public class UIShop : MonoBehaviour
    {
        [SerializeField] public UIShopAbs[] shopType;
        [SerializeField] ItemListPresenter ItemListPresenter;
        public int shopTypeIndex = 0;

        public void OnButtonShopTypeClick(int inputShopTypeIndex)
        {
            ClearAllItemUIs();
            shopTypeIndex = inputShopTypeIndex;
            ItemListPresenter.RefreshUI();
        }

        public void ClearAllItemUIs()
        {
            shopType[shopTypeIndex].ClearAllItemUIs();
        }

        public void SetItemList(UIItem_Data[] uiDatas)
        {
            shopType[shopTypeIndex].SetItemList(uiDatas);
        }

        public void ShowItemDescription(Vector3 position)
        {
            shopType[shopTypeIndex].ShowItemDescription(position);
        }

        public void HideItemDescription()
        {
            shopType[shopTypeIndex].HideItemDescription();
        }
    }
}