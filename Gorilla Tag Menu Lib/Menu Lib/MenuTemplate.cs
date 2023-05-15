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

        public Color        menuTextColor = Color.white;
        public string       menuFont = FontEnum.ArialFont;

        public GameObject   menuPivotPoint;

        public GameObject   menuRoot;
        public GameObject   reference;
        public GameObject   canvas;
        public float        framePressCooldownTimer = 0;
        public float        btnCooldownTime = 30;

        public int          currentPage;

        public List<PageTemplate> menuPages = new List<PageTemplate>();

        /// <summary>
        /// Returns a MenuTemplate object using the passed arguments
        /// </summary>
        /// <param name="newTitle">The title of the new menu</param>
        /// <param name="newSize">The size of the new menu</param>
        /// <param name="newColor">The color of the new menu</param>
        /// <param name="newPivot">The gameobject that the menu will be located at, for example: __instance.rightHandTransform.gameobject, __instance.leftHandTransform.gameobject</param>
        /// <returns>New Menu Object</returns>
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

        /// <summary>
        /// Adds PageTemplate to already existing MenuTemplate object
        /// </summary>
        /// <param name="button">The desired PageTemplate object to be added</param>
        public void AddPage(PageTemplate page)
        {
            menuPages.Add(page);

            MenuLogger.Log("Added Button To " + menuTitle);
        }

        /// <summary>
        /// Returns the currently selected PageTemplate object
        /// </summary>
        /// <returns>Currently selected page</returns>
        public PageTemplate GetCurrentPage()
        {
            return menuPages[currentPage];
        }

        // Not working currently
        public bool CheckPageValidity(int page)
        {
            if (page > menuPages.Count || page < menuPages.Count)
                return false;

            return true;
        }
    }
}
