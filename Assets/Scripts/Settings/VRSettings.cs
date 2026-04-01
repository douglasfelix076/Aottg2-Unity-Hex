using ApplicationManagers;
using Cameras;
using System;
using System.Linq;
using UI;
using UnityEngine;
using UnityStandardAssets.ImageEffects;
using Utility;

namespace Settings
{
    class VRSettings : SaveableSettingsContainer
    {
        protected override string FileName { get { return "VR.json"; } }
        public IntSetting Height = new IntSetting(170, minValue: 50, maxValue: 250);
        public BoolSetting SeatedMode = new BoolSetting(false);
        public BoolSetting LeftHanded = new BoolSetting(false);

        public override void Apply()
        {

        }
    }
}
