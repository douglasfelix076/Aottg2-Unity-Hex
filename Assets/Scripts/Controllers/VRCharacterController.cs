using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Serialization;
using UnityEditor.UI;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;
using Unity.XR.CoreUtils;
using Unity.VisualScripting;
using System.Collections;
using System.Collections.Generic;
using Characters;
using DitzelGames.FastIK;
using GameManagers;
using Settings;
using Utility;

namespace Controllers
{
    public class VRCharacterController : MonoBehaviour
    {
        [HideInInspector]
        public Transform Head;
        public Transform LeftHand;
        public Transform RightHand;
        public Transform UIAnchor;
        public Transform LeftHandVisual;
        public Transform RightHandVisual;
        public ActionBasedController LeftController;
        public ActionBasedController RightController;
        public XROrigin XrOrigin;
        public GameObject CameraOffset;
        private BaseCharacter MainCharacter;
        private BasePlayerController MainController;
        private VRCache VRCache;
        private BaseComponentCache Cache;
        private Rigidbody Rigidbody;

        private float _scale = 1.0f;

        public float Scale
        {
            get => _scale;
            set
            {
                _scale = value;
                transform.localScale = Vector3.one * value;
            }
        }
        private FastIKFabric LeftHandIK;
        private FastIKFabric RightHandIK;

        // Start is called before the first frame update
        void Start()
        {
            Head = Camera.main.transform;
            var obj1 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            var obj2 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            obj1.transform.localScale = Vector3.one * 0.1f;
            obj2.transform.localScale = Vector3.one * 0.1f;
            obj1.transform.parent = transform;
            obj2.transform.parent = transform;
            obj1.transform.localPosition = Vector3.zero;
            obj2.transform.localPosition = Vector3.up * SettingsManager.VRSettings.Height.Value/100f;
        }

        // Update is called once per frame
        void Update()
        {
            if (XrOrigin.Camera == null)
            {
                Camera cam = Camera.main;
                cam.transform.parent = CameraOffset.transform;
                XrOrigin.Camera = cam;
            }
            if (MainCharacter != null)
            {
                float userHeight = SettingsManager.VRSettings.Height.Value / 100f;
                float offset = userHeight - (userHeight - VRCache.Height);
                XrOrigin.transform.localPosition = Vector3.up * offset;
                transform.position = MainCharacter.transform.position;

                // Vector3 headOffset = Head.position - transform.position;
                // headOffset.y = 0f;
                // MainCharacter.transform.position -= headOffset;
                // XrOrigin.transform.position += headOffset;
            }
        }

        public void SetupCharacter(Transform charTransform)
        {
            MainCharacter = charTransform.gameObject.GetComponent<BaseCharacter>();
            MainController = charTransform.gameObject.GetComponent<HumanPlayerController>();
            VRCache = MainCharacter.VRCache;
            Cache = MainCharacter.Cache;
            Rigidbody = Cache.Rigidbody;
            Scale = VRCache.Scale;

            transform.position = charTransform.position;

            if (VRCache.HandL != null && VRCache.HandR != null)
            {
                LeftHandIK = VRCache.HandL.gameObject.GetOrAddComponent<FastIKFabric>();
                RightHandIK = VRCache.HandR.gameObject.GetOrAddComponent<FastIKFabric>();

                LeftHandIK.Target = LeftHandVisual;
                RightHandIK.Target = RightHandVisual;
            }

            SetControllersVisible(false);
        }

        public void RemoveParent()
        {
            transform.parent = null;
        }

        public void SetScale(float scale)
        {
            Scale = scale;
        }

        public void SetControllersVisible(bool visible = true)
        {
            SetLeftControllerVisible(visible);
            SetRightControllerVisible(visible);
        }

        public void SetLeftControllerVisible(bool visible = true)
        {
            LeftController.hideControllerModel = !visible;
        }

        public void SetRightControllerVisible(bool visible = true)
        {
            RightController.hideControllerModel = !visible;
        }

    }

}