using Gorilla_Tag_Menu_Lib.Menu_Lib;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 
--   = Proposition
-=-  = Info
==>  = Examples of uses

TODO:

-- Menu animation
-=- Ability to animate the menu, like adding a fast scaling up animation when first opening the menu. Will add animation presets
==> AddStartAnim(AnimTemplate anim, float animSpeed); AddOpeningAnim(AnimTemplate anim, float animSpeed)

*/

namespace Menu_Library
{
    public class MenuCore : MonoBehaviour
    {
        private static GameObject currentlyDrawnMenu;

        /// <summary>
        /// The function you want to call every frame to draw your desired menu. 
        /// </summary>
        /// <param name="menu">The MenuTemplate object that you want to draw</param>
        /// <param name="menuStateDepender">The bool that the menu depends on when drawing; for exmaple: if you pass in a right controller grip bool then the menu will only render when holding down grip on the right controller</param>
        public static void DrawUpdate(MenuTemplate menu, bool menuStateDepender)
        {
            if (menuStateDepender && menu.menuRoot == null)
            {
                DrawCall(menu);

                if (menu.reference == null)
                {
                    menu.reference = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    Destroy(menu.reference.GetComponent<MeshRenderer>());

                    // Probably exists a better way of doing this lol
                    if (menu.menuPivotPoint == GorillaLocomotion.Player.Instance.rightHandTransform)
                        menu.reference.transform.parent = GorillaLocomotion.Player.Instance.leftHandTransform;
                    else
                        menu.reference.transform.parent = GorillaLocomotion.Player.Instance.rightHandTransform;

                    menu.reference.transform.localPosition = new Vector3(0f, -0.1f, 0f);
                    menu.reference.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
                }
            }

            if (!menuStateDepender && menu.menuRoot)
            {
                Destroy(menu.menuRoot);
                menu.menuRoot = null;
                Destroy(menu.reference);
                menu.reference = null;
            }

            if (menuStateDepender && menu.menuRoot)
            {
                menu.menuRoot.transform.position = menu.menuPivotPoint.transform.position;
                menu.menuRoot.transform.rotation = menu.menuPivotPoint.transform.rotation;
            }
        }

        private static void DrawCall(MenuTemplate menu)
        {
            menu.menuRoot = new GameObject("[Menumaker 3000] " + menu.menuTitle + " Root");
            menu.menuRoot.transform.localScale = new Vector3(0.1f, 0.3f, 0.4f);

            currentlyDrawnMenu = menu.menuRoot;

            Destroy(menu.menuRoot.GetComponent<Rigidbody>());
            Destroy(menu.menuRoot.GetComponent<BoxCollider>());
            Destroy(menu.menuRoot.GetComponent<Renderer>());

            GameObject bg = GameObject.CreatePrimitive(PrimitiveType.Cube);

            bg.transform.parent = menu.menuRoot.transform;
            bg.transform.rotation = Quaternion.identity;
            bg.transform.localScale = menu.menuSize;
            bg.transform.position = new Vector3(0.05f, 0f, 0f);

            bg.GetComponent<Renderer>().material.color = menu.menuColor;

            Destroy(bg.GetComponent<Rigidbody>());
            Destroy(bg.GetComponent<BoxCollider>());

            menu.canvas = new GameObject();
            menu.canvas.transform.parent = menu.menuRoot.transform;
            Canvas canvas = menu.canvas.AddComponent<Canvas>();
            CanvasScaler canvasScale = menu.canvas.AddComponent<CanvasScaler>();
            menu.canvas.AddComponent<GraphicRaycaster>();
            canvas.renderMode = RenderMode.WorldSpace;
            canvasScale.dynamicPixelsPerUnit = 1000;

            GameObject titleObj = new GameObject();
            titleObj.transform.parent = menu.canvas.transform;
            Text title = titleObj.AddComponent<Text>();
            title.font = Resources.GetBuiltinResource(typeof(Font), menu.menuFont) as Font;
            title.text = menu.menuTitle;
            title.fontSize = 1;
            title.alignment = TextAnchor.MiddleCenter;
            title.color = menu.menuTextColor;
            title.resizeTextForBestFit = true;
            title.resizeTextMinSize = 0;
            RectTransform titleTransform = title.GetComponent<RectTransform>();
            titleTransform.localPosition = Vector3.zero;
            titleTransform.sizeDelta = new Vector2(0.28f, 0.05f);
            titleTransform.position = new Vector3(0.06f, 0f, 0.175f);
            titleTransform.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));

            // overflow check, remove if not wanted
            title.horizontalOverflow = HorizontalWrapMode.Wrap;

            DrawButtons(menu);
        }

        private static void DrawButtons(MenuTemplate menu)
        {
            int btnIndex = 0;
            int pageIndex = 0;

            foreach (PageTemplate page in menu.menuPages)
            {
                if (pageIndex == menu.currentPage)
                {
                    foreach (ButtonTemplate button in page.pageButtons)
                    {
                        GameObject buttonRoot = GameObject.CreatePrimitive(PrimitiveType.Cube);

                        Destroy(buttonRoot.GetComponent<Rigidbody>());

                        buttonRoot.AddComponent<ButtonCollisionHandler>().button = button;
                        buttonRoot.GetComponent<ButtonCollisionHandler>().menu = menu;
                        buttonRoot.GetComponent<BoxCollider>().isTrigger = true;

                        buttonRoot.transform.parent = menu.menuRoot.transform;
                        buttonRoot.transform.rotation = Quaternion.identity;
                        buttonRoot.transform.localScale = new Vector3(page.btnHeight, page.btnWidth, 0.08f);
                        buttonRoot.transform.localPosition = new Vector3(0.56f, 0f, 0.28f - (btnIndex * 0.13f));

                        GameObject titleObj = new GameObject();
                        titleObj.transform.parent = menu.canvas.transform;

                        Text title = titleObj.AddComponent<Text>();
                        title.font = Resources.GetBuiltinResource(typeof(Font), button.btnFont) as Font;
                        title.text = button.btnTitle;
                        title.fontSize = 1;
                        title.color = button.btnTextColor;
                        title.alignment = TextAnchor.MiddleCenter;
                        title.resizeTextForBestFit = true;
                        title.resizeTextMinSize = 0;

                        RectTransform titleTransform = title.GetComponent<RectTransform>();
                        titleTransform.localPosition = Vector3.zero;
                        titleTransform.sizeDelta = new Vector2(0.2f, 0.03f);
                        titleTransform.localPosition = new Vector3(0.064f, 0f, 0.111f - ((btnIndex * page.btnSpace) / 2.55f));
                        titleTransform.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));

                        PageTemplate currentPage = menu.GetCurrentPage();

                        if (button.btnState)
                            buttonRoot.GetComponent<Renderer>().material.color = currentPage.btnOnColor;
                        else
                            buttonRoot.GetComponent<Renderer>().material.color = currentPage.btnOffColor;

                        if (!button.btnWillToggle)
                            buttonRoot.GetComponent<Renderer>().material.color = currentPage.btnNotTogColor;

                        if (button.btnDisabled)
                            buttonRoot.GetComponent<Renderer>().material.color = currentPage.btnDisabledColor;

                        btnIndex++;
                    }
                }

                pageIndex++;
            }
        } 

        /// <summary>
        /// Redraws the menu
        /// </summary>
        public static void RefreshCurrentMenu()
        {
            if (currentlyDrawnMenu == null)
                return;

            Destroy(currentlyDrawnMenu);
            currentlyDrawnMenu = null;
        }
    }
}
