using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Dota2.ShopSystem
{

    public class MoneySystem : MonoBehaviour ,IClickable
    {

        [SerializeField] TMP_Text moneyText;
        [SerializeField] int moneyCount = 0;

        void Start () 
        {
            MoneyUI();
        }
        public void OnPointerClick(PointerEventData eventData)
        {
            throw new System.NotImplementedException(); //แก้ตรงนี้อันนี้เวลากดแล้วจะทำให้เกิดอะไร
        }
        void MoneyCounting()
        {
            //ดึงค่าเงินมาจากตัวShopเพื่อเก็บเงิน
        }

        void MoneyUI()
        {
            moneyText.text = "Gold : " + moneyCount; //uiเงิน
        }
    }

}


