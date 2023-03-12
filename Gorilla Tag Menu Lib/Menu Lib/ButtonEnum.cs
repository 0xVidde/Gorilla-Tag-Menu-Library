using System;
using UnityEngine;

namespace Menu_Library
{
    public class ButtonEnum
    {
        public string btnTitle;

        public Action btnAction;

        public bool state;

        public static ButtonEnum CreateButton(string title, Action action)
        {
            ButtonEnum button = new ButtonEnum();
            button.btnTitle = title;
            button.btnAction = action;

            return button;
        }
    }
}
