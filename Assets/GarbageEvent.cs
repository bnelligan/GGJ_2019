using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageEvent : LifeEvent
{
    [SerializeField]
    GameObject poop;

    private void Awake()
    {
        EventName = "Garbage Diver";
        EventDescription = "Ewww....";
        PrimaryStat = LifeStat.WELLNESS;
    }

    public override void TriggerEvent()
    {
        if(CanTriggerEvent())
        {
            stats.DecreaseStat(LifeStat.WELLNESS);
            Instantiate(poop, stats.transform);
        }
        base.TriggerEvent();
    }
}
