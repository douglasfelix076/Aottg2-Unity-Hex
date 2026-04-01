using Settings;
using UnityEngine;

public class FirstUpdate : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        VRInput.Update();
    }

    public static void Init()
    {
        var obj = new GameObject();
        obj.AddComponent<FirstUpdate>();
        GameObject.DontDestroyOnLoad(obj);
    }
}
