using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocksEvent : LifeEvent
{
    private void Awake()
    {
        EventName = "Blocks";
        EventDescription = "Playing with blocks can make you smarter";
        PrimaryStat = LifeStat.INTELLIGENCE;
    }

    public override void TriggerEvent()
    {
        if(CanTriggerEvent())
        {
            // Play animation of playing with the blocks
            stats.IncreaseStat(PrimaryStat);
            Debug.Log("Blocks");
        }
        base.TriggerEvent();
    }


}
