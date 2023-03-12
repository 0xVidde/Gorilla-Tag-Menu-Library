using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Menu_Library
{
    public class MenuCore : MonoBehaviour
    {
        private static GameObject currentlyDrawnMenu;

        public static void DrawUpdate(MenuTemplate menu, bool menuStateDepender)
        {
            if (menuStateDepender && menu.menuRoot == null)
            {
                DrawCall(menu);

                if (menu.reference == null)
                {
                    menu.reference = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    Destroy(menu.reference.GetComponent<MeshRenderer>());
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
                menu.menuRoot.transform.position = menu.pivotPoint.transform.position;
                menu.menuRoot.transform.rotation = menu.pivotPoint.transform.rotation;
            }
        }

        public static void DrawCall(MenuTemplate menu)
        {
            menu.menuRoot = new GameObject(menu.menuTitle + " Root");
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
            title.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
            title.text = menu.menuTitle;
            title.fontSize = 1;
            title.alignment = TextAnchor.MiddleCenter;
            title.resizeTextForBestFit = true;
            title.resizeTextMinSize = 0;
            RectTransform titleTransform = title.GetComponent<RectTransform>();
            titleTransform.localPosition = Vector3.zero;
            titleTransform.sizeDelta = new Vector2(0.28f, 0.05f);
            titleTransform.position = new Vector3(0.06f, 0f, 0.175f);
            titleTransform.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));

            DrawButtons(menu);
        }

        private static void DrawButtons(MenuTemplate menu)
        {
            int index = 0;

            foreach (ButtonEnum button in menu.menuBtns)
            {
                GameObject buttonRoot = GameObject.CreatePrimitive(PrimitiveType.Cube);

                Destroy(buttonRoot.GetComponent<Rigidbody>());
                buttonRoot.AddComponent<ButtonCollisionHandler>().button = button;
                buttonRoot.GetComponent<ButtonCollisionHandler>().menu = menu;
                buttonRoot.GetComponent<BoxCollider>().isTrigger = true;

                buttonRoot.transform.parent = menu.menuRoot.transform;
                buttonRoot.transform.rotation = Quaternion.identity;
                buttonRoot.transform.localScale = new Vector3(0.09f, 0.5f, 0.08f);
                buttonRoot.transform.localPosition = new Vector3(0.56f, 0f, 0.28f - (index * 0.13f));

                GameObject titleObj = new GameObject();
                titleObj.transform.parent = menu.canvas.transform;
                Text title = titleObj.AddComponent<Text>();
                title.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
                title.text = button.btnTitle;
                title.fontSize = 1;
                title.alignment = TextAnchor.MiddleCenter;
                title.resizeTextForBestFit = true;
                title.resizeTextMinSize = 0;
                RectTransform titleTransform = title.GetComponent<RectTransform>();
                titleTransform.localPosition = Vector3.zero;
                titleTransform.sizeDelta = new Vector2(0.2f, 0.03f);
                titleTransform.localPosition = new Vector3(0.064f, 0f, 0.111f - ((index * 0.13f) / 2.55f));
                titleTransform.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));

                if (button.state)
                    buttonRoot.GetComponent<Renderer>().material.color = Color.green;
                else
                    buttonRoot.GetComponent<Renderer>().material.color = Color.red;

                index++;
            }
        } 

        public static void RefreshMenu()
        {
            Destroy(currentlyDrawnMenu);
            currentlyDrawnMenu = null;
        }
    }
}
