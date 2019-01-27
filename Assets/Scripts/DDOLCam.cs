using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDOLCam : MonoBehaviour
{
    public static DDOLCam Instance;

    void Awake()
    {
        if (Instance != null)
        {
            GameObject.Destroy(Instance);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
    }
}
