using Unity.VisualScripting;
using UnityEngine;

namespace Settings
{
    public static class VRHumanInput
    {
        public static VRKey HookLeft = new(VRController.Left, VRButton.Grip, false);
        public static VRKey HookRight = new(VRController.Right, VRButton.Grip, false);
        public static VRKey AttackDirectionalLeft = new(VRController.Left, VRButton.Trigger, false);
        public static VRKey AttackDirectionalRight = new(VRController.Right, VRButton.Trigger, false);
        public static VRKey AttackSpecial = new(VRController.Right, VRButton.Secondary, true);
        public static VRKey Jump = new(VRController.Right, VRButton.Primary, true);
        public static VRKey Gas = new(VRController.Right, VRButton.Primary, true);
        public static VRKey Dash = new(VRController.Left, VRButton.AxisClick, true);
        public static VRKey Dodge = new(VRController.Left, VRButton.AxisClick, true);
        public static VRKey HorseMount = new(VRController.Left, VRButton.Secondary, true);

        // hooks left/right     : grips
        // attack (directional) : triggers
        // special              : right secondary
        // jump gas             : right primary
        // movement             : left joystick
        // dodge                : left joystick press
        // reel/in out          : right joystick up/down
    }
}
