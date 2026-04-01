/*
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
    [CLType(Name = "VR", Abstract = true, Static = true)]
    partial class CustomLogicVRManagerBuiltin : BuiltinClassInstance
    {
        [CLConstructor]
        public CustomLogicVRManagerBuiltin() {}

        public static bool IsInVR() => VR.IsInVR;
        public static CustomLogicTransformBuiltin GetLeftHandTransform() => new CustomLogicTransformBuiltin(VR.Controller.LeftHand);
        public static CustomLogicTransformBuiltin GetRightHandTransform() => new CustomLogicTransformBuiltin(VR.Controller.RightHand);
        public static CustomLogicTransformBuiltin GetHeadTransform() => new CustomLogicTransformBuiltin(VR.Controller.Head);
        public static CustomLogicTransformBuiltin GetOrigin() => new CustomLogicTransformBuiltin(VR.Controller.gameObject.transform);
        public static void GetOrigin(float scale = 1f) => VR.Controller.SetScale(scale);
        public static void SetControllersVisible(bool visible = true) => VR.Controller.SetControllersVisible(visible);
        public static void Recenter() => VR.Recenter();
    }
}

*/