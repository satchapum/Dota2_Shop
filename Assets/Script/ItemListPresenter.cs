using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

namespace Dota2.ShopSystem
{

    public class ItemListPresenter : MonoBehaviour
    {
        int currentCategoryIndex;
        
        int maxShownItemCount;
        int maxCategoryCount = 2;

        [Header("PageSize")]
        [SerializeField] CurrentPageSize pageSizeInput;
        public float currentPagesize;
        [SerializeField] UIShop ui;
        [SerializeField] Shop shop;

        [SerializeField] float currentShopPage = 0.0f;
        [SerializeField] float maxShopPage = 0.0f;
        [SerializeField] List<CategoryInfo> categoryInfoList = new List<CategoryInfo>();

        void Start()
        {
            maxShopPage = Mathf.Ceil((shop.GetItemsByType((ItemType)currentCategoryIndex).Length / currentPagesize)) - 1.0f;
            RefreshUI();
        }

        void Update()
        {
            if (currentPagesize != pageSizeInput.currentPageSize) {
                currentPagesize = pageSizeInput.currentPageSize;
                currentShopPage = 0.0f;
                maxShopPage = Mathf.Ceil((shop.GetItemsByType((ItemType)currentCategoryIndex).Length / currentPagesize)) - 1.0f;
                RefreshUI();
            }
            
        }

        public void BasicCategoryButton()
        {
            currentShopPage = 0;
            currentCategoryIndex = 0;
            RefreshUI();
        }

        public void UpgradeCategoryButton()
        {
            currentShopPage = 0;
            currentCategoryIndex = 1;
            RefreshUI();
        }

        public void NaturalItemCategoryButton()
        {
            currentShopPage = 0;
            currentCategoryIndex = 2;
            RefreshUI();
        }

        public void PrevItemPageButton()
        {
            if (currentShopPage == 0)
                return;
            else
            {
                currentShopPage--;
                ui.ClearAllItemUIs();
                RefreshUI();
            }
        }

        public void NextItemPageButton()
        {

            if (currentShopPage == maxShopPage)
                return;
            else
            {
                currentShopPage++;
                ui.ClearAllItemUIs();
                RefreshUI();
            }
        }

        [ContextMenu(nameof(RefreshUI))]
        public void RefreshUI()
        {

            var currentCategoryInfo = categoryInfoList[currentCategoryIndex];

            var currentCategory = (ItemType)currentCategoryIndex;

            var itemsToDisplay = shop.GetItemsByType(currentCategory);
            maxShownItemCount = itemsToDisplay.Length;

            if (maxShownItemCount <= 0)
            {
                ui.ClearAllItemUIs();
                return;
            }
            var uiDataList = new List<UIItem_Data>();

            var startIndexToDisplay = currentShopPage * currentPagesize;
            var endIndexToDisplay = startIndexToDisplay + currentPagesize;

            var i = 0;
            foreach (var item in itemsToDisplay)
            {
                if (i >= startIndexToDisplay && i < endIndexToDisplay)
                {
                    uiDataList.Add(new UIItem_Data(item));
                }

                i++;
            }
            ui.SetItemList(uiDataList.ToArray());
        }
    }
}
