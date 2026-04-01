using UnityEngine;

namespace Settings
{
    public static class VRGeneralInput
    {
        public static VRKey Pause => new(VRController.Left, VRButton.Menu, false);
        public static VRKey Emote => new(VRController.Right, VRButton.AxisClick, true);
        public static Vector2 GetMovementJoystick() => VRInput.GetAxis2D(VRController.Left, VRAxis2D.PrimaryStick, true);
        public static Vector2 GetCameraJoystick() => VRInput.GetAxis2D(VRController.Right, VRAxis2D.PrimaryStick, true);

        // emote menu           : right joystick press
    }
}
