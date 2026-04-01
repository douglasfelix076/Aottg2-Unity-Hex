using UnityEngine;
using ApplicationManagers;
using Utility;
using Controllers;

namespace GameManagers
{
    public class VRManager : MonoBehaviour
    {
        #if UNITY_EDITOR
            public static bool IsInVR => true;
        #else
            public static bool IsInVR => UnityEngine.XR.XRSettings.enabled;
        #endif
        public static BaseVRCharacterController Controller;

        public static void CreateVRController()
        {
            if (Controller != null)
                return;

            GameObject VRController = ResourceManager.InstantiateAsset<GameObject>(ResourcePaths.Characters, "VRController");
            BaseVRCharacterController controller = VRController.transform.gameObject.GetComponent<BaseVRCharacterController>();
            Controller = controller;
        }

        public static void SetScale(float scale)
        {
            if (Controller != null)
                Controller.Scale = scale;
        }

        public static void SetControllersVisible(bool visible = true)
        {
            if (Controller != null)
            {
                Controller.LeftController.hideControllerModel = !visible;
                Controller.RightController.hideControllerModel = !visible;
            }
        }
    }
}