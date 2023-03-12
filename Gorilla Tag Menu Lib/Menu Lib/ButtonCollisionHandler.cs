using UnityEngine;

namespace Menu_Library
{
    class ButtonCollisionHandler : MonoBehaviour
    {
        public ButtonEnum button;
        public MenuTemplate menu;

        private void OnTriggerEnter(Collider collider)
        {
            if (Time.frameCount >= menu.framePressCooldown + 30)
            {
                foreach (ButtonEnum btn in menu.menuBtns)
                {
                    if (btn == button)
                    {
                        btn.state = !btn.state;

                        btn.btnAction.Invoke();

                        menu.framePressCooldown = Time.frameCount;

                        MenuLogger.Log("Activated Button: " + btn.btnTitle);

                        MenuCore.RefreshMenu();
                    }
                }
            }
        }
    }
}
