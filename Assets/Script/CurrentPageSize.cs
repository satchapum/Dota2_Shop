using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Dota2.ShopSystem
{
    public class CurrentPageSize : MonoBehaviour
    {
        [SerializeField] ItemListPresenter refreshUI;
        public int currentPageSize = 10;

        public void buttonPageSize10Pressed()
        {
            currentPageSize = 10;
            refreshUI.RefreshUI();
        }
        public void buttonPageSize20Pressed()
        {
            currentPageSize = 20;
            refreshUI.RefreshUI();
        }
        public void buttonPageSize30Pressed()
        {
            currentPageSize = 30;
            refreshUI.RefreshUI();
        }
    }
}
