using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDOLPlayer : MonoBehaviour
{
    public static DDOLPlayer Instance;

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
