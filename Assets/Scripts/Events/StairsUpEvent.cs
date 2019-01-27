using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairsUpEvent : LifeEvent
{
    public GameObject player;
    public GameObject upStairs;
    float floorHeight = 0.39f;

    private void Awake()
    {
        EventName = "Go Up Stairs";
        EventDescription = "Walk up stairs bruh";
        player = FindObjectOfType<PlayerStats>().gameObject;
    }

    public override void TriggerEvent()
    {
        if(CanTriggerEvent())
        {
            Debug.Log("Go Down Stairs");
            player.transform.position += new Vector3(0, floorHeight, 0);
            base.TriggerEvent();
            IsTriggered = false;
        }
        else
        {
            Debug.LogWarning($"Already triggered event {EventName}");
        }
    }

}
