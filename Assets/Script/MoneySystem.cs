using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Dota2.ShopSystem
{

    public class MoneySystem : MonoBehaviour
    {

        [SerializeField] TMP_Text moneyText;
        [SerializeField] int moneyCount = 0;
        [SerializeField] int countNumber = 5;

        protected float Timer;
        // Start is called before the first frame update

        void Start () 
        {
            MoneyUI();
        }

        void MoneyCounting()
        {
            if(countNumber > 0) 
            { 
                moneyCount = moneyCount + 100;
                MoneyUI();

                countNumber--;
            }

        }

        void MoneyUI()
        {
            moneyText.text = "Gold : " + moneyCount;
        }
    }

}


