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
