using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Office : LifeEvent
{
    int workCount = 5;
    // Start is called before the first frame update
    void Start()
    {
        stats = FindObjectOfType<PlayerStats>();
        stats.GetComponent<SpriteRenderer>().enabled = false;
        stats.transform.position = transform.GetChild(0).position;
    }

    public override void TriggerEvent()
    {
        if(CanTriggerEvent())
        {
            workCount--;
            if(workCount <= 0)
            {
                base.TriggerEvent();
                stats.IncreaseStat(LifeStat.WEALTH);

            }
        }
    }
}
