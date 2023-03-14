using System;
using UnityEngine;

namespace Menu_Library
{
    public class ButtonTemplate
    {
        public string   btnTitle;

        public Action   btnAction;

        public bool     btnWillToggle;

        public bool     btnState;

        public bool     btnDisabled;

        /// <summary>
        /// Returns a new button object using the passed arguments
        /// </summary>
        /// <param name="newTitle">Title of new button</param>
        /// <param name="newAction">The function the button will run when activated</param>
        /// <param name="newWillToggle">If the button will be toggleable or if it will just run the function without being turned on or off, button will be gray if this is false</param>
        /// <returns></returns>
        public static ButtonTemplate CreateButton(string newTitle, Action newAction, bool newWillToggle = true)
        {
            ButtonTemplate newButton = new ButtonTemplate();

            newButton.btnTitle = newTitle;
            newButton.btnAction = newAction;
            newButton.btnWillToggle = newWillToggle;

            newButton.btnDisabled = false;

            return newButton;
        }
    }
}
