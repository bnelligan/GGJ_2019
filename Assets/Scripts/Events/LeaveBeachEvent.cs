using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveBeachEvent : LifeEvent
{
    public LevelChanger levelChanger;
    protected override void Awake()
    {
        EventName = "Leave Beach" +
                    "";
        EventDescription = "leave beach bruh";
        base.Awake();
    }

    public override void TriggerEvent()
    {
        if(CanTriggerEvent())
        {
            levelChanger.FadeToNextLevel();
            base.TriggerEvent();
        }
        else
        {
            Debug.LogWarning($"Already triggered event {EventName}");
        }
    }


}
