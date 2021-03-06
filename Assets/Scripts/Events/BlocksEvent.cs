﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocksEvent: LifeEvent
{
    protected override void Awake()
    {
        EventName = "Blocks";
        EventDescription = "Playing with blocks can make you smarter";
        PrimaryStat = LifeStat.INTELLIGENCE;
        base.Awake();
    }

    public override void TriggerEvent()
    {
        if(CanTriggerEvent())
        {
            // Play animation of playing with the blocks
            stats.IncreaseStat(PrimaryStat);
            GetComponent<Animator>().SetBool("Build", true);
            Debug.Log(PrimaryStat.ToString());
            base.TriggerEvent();
        }
        else
        {
            Debug.LogWarning($"Already triggered event {EventName}");
        }
    }


}
