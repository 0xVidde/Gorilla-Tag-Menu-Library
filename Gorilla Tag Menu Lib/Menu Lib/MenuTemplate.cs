using System;
using System.Collections.Generic;
using UnityEngine;

namespace Menu_Library
{
    public class MenuTemplate
    {
        public string  menuTitle;
        public Vector3 menuSize;
        public Color   menuColor;

        public List<ButtonEnum> menuBtns = new List<ButtonEnum>();

        public GameObject pivotPoint;

        public GameObject menuRoot;
        public GameObject reference;
        public GameObject canvas;
        public float framePressCooldown = 0;

        public static MenuTemplate CreateMenu(string title, Vector3 size, Color color, GameObject pivot)
        {
            MenuTemplate menu = new MenuTemplate();
            menu.menuTitle = title;
            menu.menuSize = size;
            menu.menuColor = color;
            menu.pivotPoint = pivot;

            MenuLogger.Log("Created Menu: " + title);

            return menu;
        }

        public void AddButton(ButtonEnum button)
        {
            menuBtns.Add(button);

            MenuLogger.Log("Added Button To " + menuTitle);
        }

        public void AddButton(ButtonEnum[] buttons)
        {
            foreach (ButtonEnum button in buttons)
            {
                AddButton(button);
            }
        }
    }
}
