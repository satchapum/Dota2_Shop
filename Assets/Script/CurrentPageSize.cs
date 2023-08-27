using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
namespace Dota2.ShopSystem
{
    public class CurrentPageSize : MonoBehaviour
    {
        public int currentPageSize = 10;

        public void buttonPageSize10Pressed()
        {
            currentPageSize = 10;
        }
        public void buttonPageSize20Pressed()
        {
            currentPageSize = 20;
        }
        public void buttonPageSize30Pressed()
        {
            currentPageSize = 30;
        }
    }
}
