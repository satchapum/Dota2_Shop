using UnityEngine.UI;

namespace Dota2.ShopSystem
{
    internal class WaitForUIButtons
    {
        private Button yesButton;
        private Button noButton;

        public WaitForUIButtons(Button yesButton, Button noButton)
        {
            this.yesButton = yesButton;
            this.noButton = noButton;
        }
    }
}