using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JukeboxEvent : LifeEvent
{
    public override void TriggerEvent()
    {
        if(CanTriggerEvent())
        {
            GetComponent<Animator>().enabled = true;
            stats.DecreaseStat(LifeStat.WEALTH);
            stats.IncreaseStat(LifeStat.WELLNESS);
            base.TriggerEvent();
        }
    }
}
