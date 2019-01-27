using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockerEvent : LifeEvent
{
    SpriteRenderer renderer;
    private void Awake()
    {
        EventName = "Locker";
        EventDescription = "Cool stuff in here...";
        PrimaryStat = LifeStat.INTELLIGENCE;
        renderer = GetComponent<SpriteRenderer>();
    }

    public override void TriggerEvent()
    {
        if(CanTriggerEvent())
        {
            if(renderer.enabled == false)
            {
                renderer.enabled = true;
                Debug.Log("Locker opened!");
            }
            else
            {
                
                base.TriggerEvent();
            }
        }
    }

}
