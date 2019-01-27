﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokerEvent : LifeEvent
{
    private void Awake()
    {
        EventName = "Smoker";
        EventDescription = "Smoking is bad for you... But girls might think you're cool?";
        PrimaryStat = LifeStat.INTELLIGENCE;
    }

    public override void TriggerEvent()
    {
        if (CanTriggerEvent())
        {
            stats.DecreaseStat(LifeStat.WELLNESS);
            stats.DecreaseStat(LifeStat.INTELLIGENCE);
            stats.IncreaseStat(LifeStat.ROMANCE);
        }

        base.TriggerEvent();
    }
}
