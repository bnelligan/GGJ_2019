using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenEvent : LifeEvent
{
    public GameObject door;
    private void Awake()
    {
        EventName = "Open door";
        EventDescription = "Open door bruh";
        
    }

    public override void TriggerEvent()
    {
        if (CanTriggerEvent())
        {
            Debug.Log("open door");
            if(door.activeSelf)
                door.SetActive(false);
            else
                door.SetActive(true);
            base.TriggerEvent();
            IsTriggered = false;
        }
        else
        {
            Debug.LogWarning($"Already triggered event {EventName}");
        }
    }
}
