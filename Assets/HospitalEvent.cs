using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HospitalEvent : LifeEvent
{
    protected override void Awake()
    {
        base.Awake();
    }
    protected override void Start()
    {
        base.Start();
        int totalScore = stats.CalcTotalScore();
        int avgScore = totalScore / 4;
        int fCount = avgScore - 1;
        
        
        Debug.Log($"You have {fCount} friends at your deathbed...");
        GameObject[] friends = GameObject.FindGameObjectsWithTag("HospitalWitness");
        foreach(GameObject f in friends)
        {
            if(fCount <= 0)
            {
                f.SetActive(false);
            }
            else
            {
                f.SetActive(true);
                fCount--;
            }
        }

    }
    public override void TriggerEvent()
    {

        base.TriggerEvent();
    }
    
}
