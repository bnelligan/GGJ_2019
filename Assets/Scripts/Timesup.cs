using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timesup : MonoBehaviour
{
    public float timer;

    private bool called;

    public LevelChanger levelChanger;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 25 && !called)
        {
            //ring bell events
            levelChanger.FadeToNextLevel();
            called = true;
        }
    }
}
