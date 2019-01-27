using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarDoorEvent : LifeEvent
{
    public override void TriggerEvent()
    {
        if(CanTriggerEvent())
        {
            FindObjectOfType<LevelChanger>().FadeToNextLevel();
            base.TriggerEvent();
        }
    }
}
