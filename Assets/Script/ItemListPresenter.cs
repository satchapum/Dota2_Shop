using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

namespace Dota2.ShopSystem
{

    public class ItemListPresenter : MonoBehaviour
    {
        public int currentItemIndex;
        public int currentCategoryIndex;

        int maxShownItemCount;
        int maxCategoryCount = 3;

        [Header("PageSize")]
        [SerializeField] CurrentPageSize pageSizeInput;
        public int currentPagesize;
        [SerializeField] UIShop ui;
        [SerializeField] Shop shop;

        [SerializeField] List<CategoryInfo> categoryInfoList = new List<CategoryInfo>();

        void Start()
        {
           RefreshUI();
        }
        void Update()
        {
            currentPagesize = pageSizeInput.currentPageSize;
        }
        [ContextMenu(nameof(RefreshUI))]
        void RefreshUI()
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
            var currentItem = itemsToDisplay[currentItemIndex];

            var uiDataList = new List<UIItem_Data>();

            var currentPageIndex = currentItemIndex / currentPagesize;
            var startIndexToDisplay = currentPageIndex * currentPagesize;
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
