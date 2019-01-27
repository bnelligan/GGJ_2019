using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WifeGraveEvent : LifeEvent
{
    protected override void Awake()
    {
        EventName = "WifeGrave";
        PrimaryStat = LifeStat.WELLNESS;
        base.Awake();
    }

    public override void TriggerEvent()
    {
        if(CanTriggerEvent())
        {
            GetComponent<Animator>().SetTrigger("Cry");
            base.TriggerEvent();
        }
        else
        {
            Debug.LogWarning($"Already Triggered event { EventName }");
        }
        
    }

}
