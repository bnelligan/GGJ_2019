using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairsDownEvent : LifeEvent
{
    public GameObject player;
    public GameObject downStairs;
    float floorHeight = 0.39f;

    private void Awake()
    {
        EventName = "Go Down Stairs";
        EventDescription = "Walk down stairs bruh";
        player = FindObjectOfType<PlayerStats>().gameObject;
    }

    public override void TriggerEvent()
    {
        if(CanTriggerEvent())
        {
            Debug.Log("Go Down Stairs");
            player.transform.position -= new Vector3(0, floorHeight, 0);
            base.TriggerEvent();
            IsTriggered = false;
        }
        else
        {
            Debug.LogWarning($"Already triggered event {EventName}");
        }
    }

}
