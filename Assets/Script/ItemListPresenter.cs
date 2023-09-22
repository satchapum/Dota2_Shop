using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;
using System.Collections;

namespace Dota2.ShopSystem
{

    public class ItemListPresenter : MonoBehaviour
    {
        [SerializeField] public int currentCategoryIndex;
        
        int maxShownItemCount;
        int maxCategoryCount = 2;

        [Header("Save")]
        [SerializeField] string savePath;
        [SerializeField] string onlineLoadPath;

        [Header("PageSize")]
        [SerializeField] CurrentPageSize pageSizeInput;
        public float currentPagesize;
        [SerializeField] UIShop ui;
        [SerializeField] Shop shop;

        [SerializeField] float currentShopPage = 0.0f;
        [SerializeField] float maxShopPage = 0.0f;
        [SerializeField] List<Category> categoryList;

        private void Awake()
        {
            LoadScoreFromGoogleDrive();
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
        public void CategoryButton(GameObject nameCategoryButton)
        {
            currentShopPage = 0;
            int firstNumberOfCategory = 0;
            for (int numberOfCategory = firstNumberOfCategory; numberOfCategory < categoryList.Count; numberOfCategory++)
            {
                categoryList[numberOfCategory].SetCategoryIndex(nameCategoryButton);
            }
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

        [ContextMenu(nameof(SaveScoreData))]
        void SaveScoreData()
        {
            if (string.IsNullOrEmpty(savePath))
            {
                Debug.LogError("No save path ja");
                return;
            }

            var scoreJson = JsonConvert.SerializeObject(shop.itemList, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            }); ;
            var dataPath = Application.dataPath;
            var targetFilePath = Path.Combine(dataPath, savePath);

            var directoryPath = Path.GetDirectoryName(targetFilePath);
            if (Directory.Exists(directoryPath) == false)
                Directory.CreateDirectory(directoryPath);

            File.WriteAllText(targetFilePath, scoreJson);
        }
        IEnumerator LoadScoreRoutine(string url)
        {
            var webRequest = UnityWebRequest.Get(url);

            //Get download progress
            var progress = webRequest.downloadProgress;
            Debug.Log(progress);

            yield return webRequest.SendWebRequest();

            if (webRequest.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError(webRequest.error);
            }
            else
            {
                var downloadedText = webRequest.downloadHandler.text;
                Debug.Log("Receive Data : " + downloadedText);
                shop.itemList = JsonConvert.DeserializeObject<List<ItemData>>(downloadedText);
            }
            maxShopPage = Mathf.Ceil((shop.GetItemsByType((ItemType)currentCategoryIndex).Length / currentPagesize)) - 1.0f;
            RefreshUI();
        }

        [ContextMenu(nameof(LoadScoreFromGoogleDrive))]
        void LoadScoreFromGoogleDrive()
        {
            StartCoroutine(LoadScoreRoutine(onlineLoadPath));
        }

        [ContextMenu(nameof(RefreshUI))]
        public void RefreshUI()
        {
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
