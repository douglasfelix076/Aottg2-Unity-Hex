using ApplicationManagers;
using GameManagers;
using Map;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Characters;
using Effects;
using Photon.Pun;
using Projectiles;
using Settings;
using System;
using UI;
using Utility;

namespace CustomLogic
{
    /// <summary>
    /// Virtual Reality functions.
    /// </summary>
    [CLType(Name = "VRManager", Abstract = true, Static = true)]
    partial class CustomLogicVRManagerBuiltin : BuiltinClassInstance
    {
        [CLConstructor]
        public CustomLogicVRManagerBuiltin() {}

        public bool IsInVR() => VRManager.IsInVR;

        public CustomLogicTransformBuiltin GetLeftHandTransform()
        {
            if (VRManager.IsInVR)
                return new CustomLogicTransformBuiltin(VRManager.Controller.LeftHand);
            return null;
        }

        public CustomLogicTransformBuiltin GetRightHandTransform()
        {
            if (VRManager.IsInVR)
                return new CustomLogicTransformBuiltin(VRManager.Controller.RightHand);
            return null;
        }

        public CustomLogicTransformBuiltin GetHeadTransform()
        {
            if (VRManager.IsInVR)
                return new CustomLogicTransformBuiltin(VRManager.Controller.Head);
            return null;
        }

        public CustomLogicTransformBuiltin GetOrigin()
        {
            if (VRManager.IsInVR)
                return new CustomLogicTransformBuiltin(VRManager.Controller.gameObject.transform);
            return null;
        }

        public void GetOrigin(float scale = 1f) => VRManager.SetScale(scale);

        public void SetControllersVisible(bool visible = true) => VRManager.SetControllersVisible(visible);

        public void Recenter() { }
    }
}
