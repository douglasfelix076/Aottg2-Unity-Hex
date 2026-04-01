using ApplicationManagers;
using Photon.Pun;
using System.Collections.Generic;
using UnityEngine;

namespace Utility
{
    public class VRCache
    {
        public float Height = 1.0f;
        public float Scale = 1.0f;
        public Transform HandL = null;
        public Transform HandR = null;
        public Transform FootL = null;
        public Transform FootR = null;
        public Vector3 HandLLocalPosition = Vector3.zero;
        public Vector3 HandRLocalRotation = Vector3.zero;
    }
}
