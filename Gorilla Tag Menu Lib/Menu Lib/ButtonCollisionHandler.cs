using UnityEngine;

namespace Menu_Library
{
    class ButtonCollisionHandler : MonoBehaviour
    {
        public ButtonTemplate button;
        public MenuTemplate menu;

        private void OnTriggerEnter(Collider collider)
        {
            if (Time.frameCount >= menu.framePressCooldownTimer + menu.btnCooldownTime)
            {
                foreach (ButtonTemplate btn in menu.menuPages[menu.currentPage].pageButtons)
                {
                    if (btn == button)
                    {
                        if (btn.btnDisabled)
                            return;

                        if (btn.btnWillToggle)
                            btn.btnState = !btn.btnState;

                        if (btn.btnAction != null)
                            btn.btnAction.Invoke();

                        menu.framePressCooldownTimer = Time.frameCount;

                        MenuCore.RefreshCurrentMenu();
                    }
                }
            }
        }
    }
}