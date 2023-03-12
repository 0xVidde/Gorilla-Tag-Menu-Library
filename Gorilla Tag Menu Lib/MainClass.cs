using BepInEx;
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
        private const string modVersion = "0.0.1";

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
        private static void TEST()
        {
            Debug.Log("Random Number: " + Random.Range(1, 10000));
        }

        static void Prefix(GorillaLocomotion.Player __instance)
        {
            if (init)
            {
                // menu innit                   // Title              // Size            // Colour                     // Where you want the menu to be
                menu = MenuTemplate.CreateMenu("Hello World", new Vector3(0.1f, 1f, 1f), Color.black, GorillaLocomotion.Player.Instance.leftHandTransform.gameObject);

                // Button Init                                // Button Name     // The button action
                ButtonEnum testButton = ButtonEnum.CreateButton("Test Button", new System.Action(TEST));

                menu.AddButton(testButton);

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