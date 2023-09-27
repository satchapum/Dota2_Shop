using UnityEngine;
using DG.Tweening;

namespace Dota2.ShopSystem
{
    public class UIShop : MonoBehaviour
    {
        [SerializeField] public UIShopAbs[] shopType;
        [SerializeField] ItemListPresenter ItemListPresenter;
        [SerializeField] CanvasGroup newUIShop;
        [SerializeField] CanvasGroup oldUIShop;
        public int shopTypeIndex = 0;

        public void OnButtonShopTypeClick(int inputShopTypeIndex)
        {
            shopTypeIndex = inputShopTypeIndex;
            if (shopTypeIndex == 0) 
            { 
                FadeNewUIShop();    
            }
            else if (shopTypeIndex == 1) 
            { 
                FadeOldUIShop();
            }
            ClearAllItemUIs();
            ItemListPresenter.RefreshUI();
        }

        public void FadeNewUIShop()
        {
            newUIShop.alpha = 1;
            newUIShop.blocksRaycasts = false;
            newUIShop.DOFade(0, 3f);
        }

        public void FadeOldUIShop()
        {
            oldUIShop.alpha = 1;
            oldUIShop.blocksRaycasts = false;
            oldUIShop.DOFade(0, 3f);
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