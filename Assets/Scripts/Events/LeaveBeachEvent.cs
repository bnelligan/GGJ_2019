using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveBeachEvent : LifeEvent
{
    public LevelChanger levelChanger;
    private void Awake()
    {
        EventName = "Leave Beach" +
                    "";
        EventDescription = "leave beach bruh";

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
