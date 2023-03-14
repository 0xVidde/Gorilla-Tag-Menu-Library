using UnityEngine;

namespace Menu_Library
{
    class ButtonCollisionHandler : MonoBehaviour
    {
        public ButtonTemplate button;
        public MenuTemplate menu;

        private void OnTriggerEnter(Collider collider)
        {
            Debug.Log("TEST");

            if (Time.frameCount >= menu.framePressCooldown + 30)
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

                        menu.framePressCooldown = Time.frameCount;

                        MenuCore.RefreshMenu();
                    }
                }
            }
        }
    }
}
