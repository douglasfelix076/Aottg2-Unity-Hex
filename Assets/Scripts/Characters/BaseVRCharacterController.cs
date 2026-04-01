using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Characters;
using DitzelGames.FastIK;
using Unity.VisualScripting;
using UnityEngine.Assertions;
using UnityEngine.Serialization;
using UnityEngine.XR;
using Unity.XR.CoreUtils;
using GameManagers;
using UnityEngine.XR.Interaction.Toolkit;
using Settings;
using UnityEditor.UI;

namespace Controllers
{
    public class BaseVRCharacterController : MonoBehaviour
    {

        public Transform LeftHand;
        public Transform RightHand;
        public Transform Head;
        public Transform UIAnchor;
        public ActionBasedController LeftController;
        public ActionBasedController RightController;

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
        public XROrigin XrOrigin;
        public GameObject CameraOffset;
        private BaseCharacter MainCharacter;
        private FastIKFabric LeftHandIK;
        private FastIKFabric RightHandIK;

        // Start is called before the first frame update
        void Start()
        {
            Head = Camera.main.transform;
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
                float offset = MainCharacter.VRCache.Height - SettingsManager.VRSettings.Height.Value;
                transform.position = MainCharacter.transform.position + Vector3.up * offset;
            }
        }

        public void SetupCharacter(Transform character, Transform leftHand, Transform rightHand)
        {
            MainCharacter = character.gameObject.GetComponent<BaseCharacter>();

            transform.parent = character;
            transform.position = Vector3.zero;
            Scale = MainCharacter.VRCache.Scale;

            if (leftHand != null && rightHand != null)
            {
                LeftHandIK = leftHand.gameObject.GetOrAddComponent<FastIKFabric>();
                RightHandIK = rightHand.gameObject.GetOrAddComponent<FastIKFabric>();

                LeftHandIK.Target = LeftHand;
                RightHandIK.Target = RightHand;
            }

        }

    }

}