﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandCastleEvent : LifeEvent
{

    protected override void Awake()
    {
        EventName = "Sand Castle";
        EventDescription = "Building sand castles is fun! It will make you happy.";
        PrimaryStat = LifeStat.WELLNESS;
        base.Awake();
    }

    public override void TriggerEvent()
    {
        if(CanTriggerEvent())
        {
            stats.IncreaseStat(LifeStat.WELLNESS);
            GetComponent<Animator>().SetBool("Build", true);
        }
        base.TriggerEvent();
    }
}
