using Gorilla_Tag_Menu_Lib.Menu_Lib;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Menu_Library
{
    public class MenuTemplate
    {
        public string       menuTitle;
        public Vector3      menuSize;
        public Color        menuColor;

        public GameObject   menuPivotPoint;

        public GameObject   menuRoot;
        public GameObject   reference;
        public GameObject   canvas;
        public float        framePressCooldown = 0;

        public int currentPage;

        public List<PageTemplate> menuPages = new List<PageTemplate>();


        public static MenuTemplate CreateMenu(string newTitle, Vector3 newSize, Color newColor, GameObject newPivot)
        {
            MenuTemplate newMenu = new MenuTemplate();

            newMenu.menuTitle = newTitle;
            newMenu.menuSize = newSize;
            newMenu.menuColor = newColor;
            newMenu.menuPivotPoint = newPivot;

            newMenu.currentPage = 0;

            MenuLogger.Log("Created Menu: " + newTitle);

            return newMenu;
        }

        public void AddPage(PageTemplate page)
        {
            menuPages.Add(page);

            MenuLogger.Log("Added Button To " + menuTitle);
        }

        public void AddPage(PageTemplate[] page)
        {
            foreach (PageTemplate pageToAdd in menuPages)
            {
                AddPage(pageToAdd);
            }
        }

        public PageTemplate GetCurrentPage()
        {
            return menuPages[currentPage];
        }
    }
}
