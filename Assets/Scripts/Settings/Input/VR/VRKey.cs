using Unity.VisualScripting;
using UnityEngine;

namespace Settings
{
    public class VRKey
    {
        private readonly VRController Controller;
        private readonly VRButton Button;
        private readonly bool LeftHandedInvert;

        public VRKey(VRController controller, VRButton button, bool leftHandedInvert = false)
        {
            Controller = controller;
            Button = button;
            LeftHandedInvert = leftHandedInvert;
        }

        public bool GetKey()     => VRInput.GetButton(Controller, Button, LeftHandedInvert);
        public bool GetKeyDown() => VRInput.GetButtonDown(Controller, Button, LeftHandedInvert);
        public bool GetKeyUp()   => VRInput.GetButtonUp(Controller, Button, LeftHandedInvert);
    }
}