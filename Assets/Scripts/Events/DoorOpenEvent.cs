using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenEvent : LifeEvent
{
    public GameObject door;
    public GameObject wall;
    protected override void Awake()
    {
        EventName = "Open door";
        EventDescription = "Open door bruh";
        base.Awake();
    }

    public override void TriggerEvent()
    {
        if (CanTriggerEvent())
        {
            Debug.Log("open door");
            if (door.activeSelf)
            {
                door.SetActive(false);
                wall.SetActive(true);
            }

            else
            {
                door.SetActive(true);
                wall.SetActive(false);
            }
                
            base.TriggerEvent();
            IsTriggered = false;
        }
        else
        {
            Debug.LogWarning($"Already triggered event {EventName}");
        }
    }
}
