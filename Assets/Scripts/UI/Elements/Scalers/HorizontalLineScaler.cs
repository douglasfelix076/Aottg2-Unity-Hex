using System;
using System.Collections.Generic;
using System.Text;
using GameManagers;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    class HorizontalLineScaler: BaseScaler
    {
        public override void ApplyScale()
        {
            var layoutElement = GetComponent<LayoutElement>();
            layoutElement.minHeight = 50;
        }
    }
}
