using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Dota2.ShopSystem
{

    public class MoneySystem : MonoBehaviour 
    {

        [SerializeField] TMP_Text moneyText;
        public int moneyCount = 0;
            
                
        void Update()
        {
            moneyText.text = "Gold : " + moneyCount; 
        }

        
    }

}


