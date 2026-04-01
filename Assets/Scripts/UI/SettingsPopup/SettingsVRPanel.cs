using Settings;
using System;
using UnityEngine;
using UnityEngine.UI;
using Utility;

namespace UI
{
    class SettingsVRPanel: SettingsCategoryPanel
    {
        public override void Setup(BasePanel parent = null)
        {
            base.Setup(parent);

            SettingsPopup settingsPopup = (SettingsPopup)parent;
            string cat = settingsPopup.LocaleCategory;
            string sub = "VR";
            VRSettings settings = SettingsManager.VRSettings;
            ElementStyle style = new ElementStyle(titleWidth: 200f, themePanel: ThemePanel);

            ElementFactory.CreateIncrementSetting(DoublePanelLeft, style, settings.Height, UIManager.GetLocale(cat, sub, "Height"));
            ElementFactory.CreateToggleSetting(DoublePanelLeft, style, settings.SeatedMode, UIManager.GetLocale(cat, sub, "Seated"));
        }

    }
}
