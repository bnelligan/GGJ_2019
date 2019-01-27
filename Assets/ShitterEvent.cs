using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShitterEvent : LifeEvent
{
    private void Awake()
    {
        EventName = "The Ole Shitter";
        EventDescription = "Everyone's gotta go...";
        PrimaryStat = LifeStat.WELLNESS;
    }

    public override void TriggerEvent()
    {
        if(CanTriggerEvent())
        {
            transform.GetChild(0).gameObject.SetActive(true);
            stats.IncreaseStat(PrimaryStat);
            Debug.Log("Sweet relief!");
        }
        base.TriggerEvent();
    }
}
