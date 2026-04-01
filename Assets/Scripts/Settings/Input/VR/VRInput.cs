using UnityEngine;
using UnityEngine.XR;
using System.Collections.Generic;
using System;
namespace Settings
{
    class VRInput
    {
        static readonly Dictionary<VRButton, InputFeatureUsage<bool>> ButtonMap = new()
        {
            { VRButton.Primary  , CommonUsages.primaryButton      },
            { VRButton.Secondary, CommonUsages.secondaryButton    },
            { VRButton.Trigger  , CommonUsages.triggerButton      },
            { VRButton.Grip     , CommonUsages.gripButton         },
            { VRButton.Menu     , CommonUsages.menuButton         },
            { VRButton.AxisClick, CommonUsages.primary2DAxisClick }
        };
        static readonly Dictionary<VRAxis1D, InputFeatureUsage<float>> Axis1DMap = new()
        {
            { VRAxis1D.Trigger, CommonUsages.trigger },
            { VRAxis1D.Grip   , CommonUsages.grip    }
        };
        static readonly Dictionary<VRAxis2D, InputFeatureUsage<Vector2>> Axis2DMap = new()
        {
            { VRAxis2D.PrimaryStick  , CommonUsages.primary2DAxis   },
            { VRAxis2D.SecondaryStick, CommonUsages.secondary2DAxis }
        };
        static readonly Dictionary<VRButton, ButtonState> leftInput = new();
        static readonly Dictionary<VRButton, ButtonState> rightInput = new();
        private static InputDevice LeftController = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);
        private static InputDevice RightController = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);

        public static void Init()
        {
            foreach (VRButton key in Enum.GetValues(typeof(VRButton)))
            {
                rightInput[key] = new ButtonState();
                leftInput[key] = new ButtonState();
            }
            LeftController = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);
            RightController = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
        }

        public static void Update()
        {
            foreach (var buttonState in leftInput)
                buttonState.Value.Update(IsButtonHeld(ref LeftController, XRNode.LeftHand, buttonState.Key));
            foreach (var buttonState in rightInput)
                buttonState.Value.Update(IsButtonHeld(ref RightController, XRNode.RightHand, buttonState.Key));
        }

        private static bool IsButtonHeld(ref InputDevice device, XRNode node, VRButton button)
        {
            if (!device.isValid)
                device = InputDevices.GetDeviceAtXRNode(node);

            if (device.isValid && ButtonMap.TryGetValue(button, out var usage) && device.TryGetFeatureValue(usage, out bool pressed))
                return pressed;

            return false;
        }

        public static bool GetButton(VRController controller, VRButton button, bool LeftHandedInvert = false)
        {
            var device = GetDevice(controller, LeftHandedInvert);

            XRNode node = GetNode(VRController.Left, LeftHandedInvert);

            return IsButtonHeld(ref device, node, button);
        }

        public static bool GetButtonDown(VRController controller, VRButton button, bool LeftHandedInvert = false)
        {
            bool left = controller == VRController.Left;

            if (LeftHandedInvert && SettingsManager.VRSettings.LeftHanded.Value)
                left = !left;

            if (left)
                return leftInput[button].Down;

            return rightInput[button].Down;
        }

        public static bool GetButtonUp(VRController controller, VRButton button, bool LeftHandedInvert = false)
        {
            bool left = controller == VRController.Left;

            if (LeftHandedInvert && SettingsManager.VRSettings.LeftHanded.Value)
                left = !left;

            if (left)
                return leftInput[button].Up;

            return rightInput[button].Up;
        }

        public static float GetAxis1D(VRController controller, VRAxis1D axis, bool LeftHandedInvert = false)
        {
            InputDevice device = GetDevice(controller, LeftHandedInvert);

            if (device.isValid && device.TryGetFeatureValue(Axis1DMap[axis], out float value))
                return value;

            return 0;
        }

        public static Vector2 GetAxis2D(VRController controller, VRAxis2D axis, bool LeftHandedInvert = false)
        {
            InputDevice device = GetDevice(controller, LeftHandedInvert);

            if (device.isValid && device.TryGetFeatureValue(Axis2DMap[axis], out Vector2 vector))
                return vector;
            return Vector2.zero;
        }

        public static Vector3 GetVelocity(VRController controller, bool LeftHandedInvert = false)
        {
            InputDevice device = GetDevice(controller, LeftHandedInvert);

            if (device.isValid && device.TryGetFeatureValue(CommonUsages.deviceVelocity, out Vector3 velocity))
                return velocity;

            return Vector3.zero;
        }

        public static Vector3 GetAcceleration(VRController controller, bool LeftHandedInvert = false)
        {
            InputDevice device = GetDevice(controller, LeftHandedInvert);

            if (device.isValid && device.TryGetFeatureValue(CommonUsages.deviceAcceleration, out Vector3 velocity))
                return velocity;

            return Vector3.zero;
        }

        public static Vector3 GetAngularVelocity(VRController controller, bool LeftHandedInvert = false)
        {
            InputDevice device = GetDevice(controller, LeftHandedInvert);

            if (device.isValid && device.TryGetFeatureValue(CommonUsages.deviceAngularVelocity, out Vector3 velocity))
                return velocity;

            return Vector3.zero;
        }

        public static Vector3 GetAngularAcceleration(VRController controller, bool LeftHandedInvert = false)
        {
            InputDevice device = GetDevice(controller, LeftHandedInvert);

            if (device.isValid && device.TryGetFeatureValue(CommonUsages.deviceAngularAcceleration, out Vector3 velocity))
                return velocity;

            return Vector3.zero;
        }

        private static InputDevice GetDevice(VRController controller, bool LeftHandedInvert = false)
        {
            bool left = controller == VRController.Left;

            if (LeftHandedInvert && SettingsManager.VRSettings.LeftHanded.Value)
                left = !left;

            return left ? LeftController : RightController;
        }

        private static XRNode GetNode(VRController controller, bool LeftHandedInvert = false)
        {
            bool left = controller == VRController.Left;

            if (LeftHandedInvert && SettingsManager.VRSettings.LeftHanded.Value)
                left = !left;

            return left ? XRNode.LeftHand : XRNode.RightHand;
        }
    }

    class ButtonState
    {
        public bool Current;
        public bool Last;

        public void Update(bool value)
        {
            Last = Current;
            Current = value;
        }

        public bool Down => Current && !Last;
        public bool Up => !Current && Last;
        public bool Held => Current;
    }

    public enum VRController
    {
        Left,
        Right
    }

    public enum VRButton
    {
        Primary,
        Secondary,
        Trigger,
        Grip,
        Menu,
        AxisClick
    }

    public enum VRAxis1D
    {
        Trigger,
        Grip
    }

    public enum VRAxis2D
    {
        PrimaryStick,
        SecondaryStick
    }
}

