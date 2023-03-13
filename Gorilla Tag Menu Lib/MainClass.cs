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
        private const string modVersion = "0.0.2";

        public void Awake()
        {
            var harmony = new Harmony(modGUID);
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }

    [HarmonyPatch(typeof(GorillaLocomotion.Player))]
    [HarmonyPatch("FixedUpdate", MethodType.Normal)]
    public class MainPatch
    {
        public static MenuTemplate menu;

        static bool init = true;

        // The function that's ran when a button is pressed
        private static void IncreasePage()
        {
            if (menu.currentPage + 1 > menu.menuPages.Count)
                return;

            menu.currentPage = menu.currentPage + 1;
        }

        private static void DecreasePage()
        {
            if (menu.currentPage - 1 < menu.menuPages.Count)
                return;

            menu.currentPage = menu.currentPage - 1;
        }

        private static void TEST()
        {
            Debug.Log("TEST");
        }

        static void Prefix(GorillaLocomotion.Player __instance)
        {
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

            // Ignore this, here just because of testing
            // -----
            bool leftControllerGrip;

            List<InputDevice> leftList = new List<InputDevice>();
            InputDevices.GetDevicesWithCharacteristics(InputDeviceCharacteristics.HeldInHand | InputDeviceCharacteristics.Left | InputDeviceCharacteristics.Controller, leftList);

            leftList[0].TryGetFeatureValue(CommonUsages.gripButton, out leftControllerGrip);
            // -----

            // The actual draw update call, needs to be ran every frame
            MenuCore.DrawUpdate(menu, leftControllerGrip);
        }
    }
}