using BepInEx;
using Gorilla_Tag_Menu_Lib.Menu_Lib;
using HarmonyLib;
using Menu_Library;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.XR;

namespace Gorilla_Tag_Mod_Menu_Library
{
    [BepInPlugin(modGUID, modName, modVersion)]
    public class LoaderClass : BaseUnityPlugin
    {
        private const string modGUID = "GT.Menu.Lib";
        private const string modName = "An Example For Vidde's Gorilla Tag Menu Library";
        private const string modVersion = "0.0.3";

        public void Awake()
        {
            var harmony = new Harmony(modGUID);
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }

    [HarmonyPatch(typeof(GorillaLocomotion.Player))]
    [HarmonyPatch("FixedUpdate", MethodType.Normal)]
    public class ExampleClass
    {
        public static MenuTemplate menu;

        static bool init = true;

        // Increases the menu's currentPage when called
        private static void IncreasePage()
        {
            int page = menu.currentPage + 1;

            if (menu.CheckPageValidity(page))
                menu.currentPage = page;
        }

        // Decreases the menu's currentPage when called
        private static void DecreasePage()
        {
            int page = menu.currentPage - 1;

            if (menu.CheckPageValidity(page))
                menu.currentPage = page;
        }

        // Test function
        private static void TEST()
        {
            Debug.Log("TEST");
        }

        static void Prefix(GorillaLocomotion.Player __instance)
        {
            // Everything here will be called once at the start. All this does it just inits every menu object
            if (init)
            {
                // menu innit                   // Title              // Size            // Colour                     // Where you want the menu to be
                menu = MenuTemplate.CreateMenu("Hello World", new Vector3(0.1f, 1f, 1f), Color.black, GorillaLocomotion.Player.Instance.leftHandTransform.gameObject);

                // Creating pages
                PageTemplate page1 = PageTemplate.CreatePage();
                PageTemplate page2 = PageTemplate.CreatePage();

                // Creating buttons for page 1
                ButtonTemplate[] page1Buttons =
                {
                    ButtonTemplate.CreateButton("Page >>", IncreasePage, false),
                    ButtonTemplate.CreateButton("<< Page", DecreasePage, false),
                    ButtonTemplate.CreateButton("Page 1 Test 1", TEST),
                    ButtonTemplate.CreateButton("Page 1 Test 2", TEST),
                    ButtonTemplate.CreateButton("Page 1 Test 3", TEST)
                };

                // Creating buttons for page 2
                ButtonTemplate[] page2Buttons =
                {
                    ButtonTemplate.CreateButton("Page >>", IncreasePage, false),
                    ButtonTemplate.CreateButton("<< Page", DecreasePage, false),
                    ButtonTemplate.CreateButton("Page 2 Test 1", TEST),
                    ButtonTemplate.CreateButton("Page 2 Test 2", TEST),
                    ButtonTemplate.CreateButton("Page 2 Test 3", TEST)
                };

                // Adding the buttons to the pages
                page1.AddButton(page1Buttons);
                page2.AddButton(page2Buttons);

                // Adding the pages to the menu
                menu.AddPage(page1);
                menu.AddPage(page2);

                init = false;
            }

            // Gets the controller input through the InputHandler inside this lib ;)
            Menu_Lib.Input.InputEnum input = Menu_Lib.Input.InputHandler.GetControllerInput();

            // The actual draw update call, needs to be ran every frame
            MenuCore.DrawUpdate(menu, input.isHoldingLeftGrip);
        }
    }
}