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

        public Color btnOnColor = Color.green;
        public Color btnOffColor = Color.red;
        public Color btnDisabledColor = Color.black;
        public Color btnNotTogColor = Color.gray;

        /// <summary>
        /// Returns new PageTemplate object
        /// </summary>
        /// <returns></returns>
        public static PageTemplate CreatePage()
        {
            return new PageTemplate();
        }

        /// <summary>
        /// Adds ButtonTemplate to already existing PageTemplate object
        /// </summary>
        /// <param name="button">The desired ButtonTemplate object to be added</param>
        public void AddButton(ButtonTemplate button)
        {
            pageButtons.Add(button);
        }

        /// <summary>
        /// Wrapper for AddButton(ButtonTemplate button). Used to add an array of ButtonTemplate instead of one at a time.
        /// </summary>
        /// <param name="button">The desired ButtonTemplate array to be added</param>
        public void AddButton(ButtonTemplate[] buttons)
        {
            foreach (ButtonTemplate button in buttons)
            {
                AddButton(button);
            }
        }
    }
}
