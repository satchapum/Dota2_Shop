using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Dota2.ShopSystem
{
    public class ItemDescription : MonoBehaviour
    {
        [SerializeField] Transform popupText;
        [SerializeField] static string textstatus = "off";
        public TMP_Text nameText;
        public TMP_Text priceItem;
        public TMP_Text itemStats;
        public TMP_Text itemUsing;

        /*void OnMouseEnter()
        {
            if (textstatus == "off") 
            { 
                if ()
                {
                    nameText.text = "";
                    priceItem.text = "";
                    itemStats.text = "";
                    itemUsing.text = "";
                }
                textstatus = "on";
                Instantiate(popupText, new Vector3(transform.position.x+1, transform.position.y,0),popupText.rotation);
            }
        }

        void OnMouseExit()
        {
            if(textstatus == "on") 
            {
                textstatus="off";
            }
        }*/

    }


}


