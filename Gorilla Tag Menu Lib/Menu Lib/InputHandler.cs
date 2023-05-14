using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

namespace Menu_Lib.Input
{
    public class InputHandler
    {
        /// <summary>
        /// Returns an InputEnum object which contains all controller input you'll most likely need
        /// </summary>
        /// <returns></returns>
        public static InputEnum GetControllerInput()
        {
            bool isHoldingRightGrip;
            bool isHoldingLeftGrip;
            bool isHoldingRightTrigger;
            bool isHoldingLeftTrigger;

            bool isHoldingRightPrimaryButton;
            bool isHoldingRightSecondaryButton;

            bool isHoldingLeftPrimaryButton;
            bool isHoldingLeftSecondaryButton;

            float rightGripValue;
            float leftGripValue;
            float rightTriggerValue;
            float leftTriggerValue;

            List<InputDevice> leftList = new List<InputDevice>();
            List<InputDevice> rightList = new List<InputDevice>();
            InputDevices.GetDevicesWithCharacteristics(InputDeviceCharacteristics.HeldInHand | InputDeviceCharacteristics.Left | InputDeviceCharacteristics.Controller, leftList);
            InputDevices.GetDevicesWithCharacteristics(InputDeviceCharacteristics.HeldInHand | InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller, rightList);

            rightList[0].TryGetFeatureValue(CommonUsages.gripButton, out isHoldingRightGrip);
            leftList[0].TryGetFeatureValue(CommonUsages.gripButton, out isHoldingLeftGrip);
            rightList[0].TryGetFeatureValue(CommonUsages.triggerButton, out isHoldingRightTrigger);
            leftList[0].TryGetFeatureValue(CommonUsages.triggerButton, out isHoldingLeftTrigger);

            rightList[0].TryGetFeatureValue(CommonUsages.grip, out rightGripValue);
            leftList[0].TryGetFeatureValue(CommonUsages.grip, out leftGripValue);
            rightList[0].TryGetFeatureValue(CommonUsages.trigger, out rightTriggerValue);
            leftList[0].TryGetFeatureValue(CommonUsages.trigger, out leftTriggerValue);

            rightList[0].TryGetFeatureValue(CommonUsages.primaryButton, out isHoldingRightPrimaryButton);
            rightList[0].TryGetFeatureValue(CommonUsages.secondaryButton, out isHoldingRightSecondaryButton);

            leftList[0].TryGetFeatureValue(CommonUsages.primaryButton, out isHoldingLeftPrimaryButton);
            leftList[0].TryGetFeatureValue(CommonUsages.secondaryButton, out isHoldingLeftSecondaryButton);

            var input = new InputEnum
            {
                isHoldingRightGrip = isHoldingRightGrip,
                isHoldingLeftGrip = isHoldingLeftGrip,
                isHoldingRightTrigger = isHoldingRightTrigger,
                isHoldingLeftTrigger = isHoldingLeftTrigger,

                isHoldingRightPrimaryButton = isHoldingRightPrimaryButton,
                isHoldingRightSecondaryButton = isHoldingRightSecondaryButton,

                isHoldingLeftPrimaryButton = isHoldingLeftPrimaryButton,
                isHoldingLeftSecondaryButton = isHoldingLeftSecondaryButton,

                rightGripValue = rightGripValue,
                leftGripValue = leftGripValue,
                rightTriggerValue = rightTriggerValue,
                leftTriggerValue = leftTriggerValue,
            };

            return input;
        }
    }
}
