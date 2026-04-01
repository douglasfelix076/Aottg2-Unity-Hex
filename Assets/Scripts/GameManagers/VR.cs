using UnityEngine;
using ApplicationManagers;
using Utility;
using Controllers;
using UnityEditor.UI;

namespace GameManagers
{
    public static class VR
    {
        public static bool IsInVR { get; private set; }
        public static VRCharacterController Controller
        {
            get
            {
                CreateVRController();
                return _controller;
            }
        }
        private static VRCharacterController _controller;

        public static void Init()
        {
            IsInVR = UnityEngine.XR.XRSettings.enabled;
        }

        public static void CreateVRController()
        {
            if (_controller != null)
                return;

            GameObject VRController = ResourceManager.InstantiateAsset<GameObject>(ResourcePaths.Characters, "VRController");
            _controller = VRController.transform.gameObject.GetComponent<VRCharacterController>();
        }

        public static void Recenter()
        {
            UnityEngine.XR.InputTracking.Recenter();
        }
    }
}