using System.Collections;
using System.Collections.Generic;
using Controllers;
using GameManagers;
using UnityEngine;

public class VRDisable : MonoBehaviour
{
    public GameObject component;

    void Awake()
    {
        if (component != null && VR.IsInVR)
            component.SetActive(false);
    }

}
