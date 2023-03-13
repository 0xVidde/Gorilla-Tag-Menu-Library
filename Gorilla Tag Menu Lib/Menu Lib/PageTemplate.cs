using Menu_Library;
using System.Collections.Generic;
using UnityEngine;

namespace Gorilla_Tag_Menu_Lib.Menu_Lib
{
    public class PageTemplate
    {
        public List<ButtonTemplate> pageButtons = new List<ButtonTemplate>();

        public float btnSpace  = 0.13f;

        public float btnWidth  = 0.5f;
        public float btnHeight = 0.09f;

        public static PageTemplate CreatePage()
        {
            return new PageTemplate();
        }

        public void AddButton(ButtonTemplate button)
        {
            pageButtons.Add(button);
        }

        public void AddButton(ButtonTemplate[] buttons)
        {
            foreach (ButtonTemplate button in buttons)
            {
                AddButton(button);
            }
        }
    }
}
