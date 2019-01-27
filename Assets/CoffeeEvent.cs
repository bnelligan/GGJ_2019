using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeEvent : LifeEvent
{
    protected override void Awake()
    {
        EventName = "Coffee!";
        EventDescription = "Nothin' like a cup-o-joe in the mornin'";
        PrimaryStat = LifeStat.WELLNESS;
        base.Awake();
    }
    public override void TriggerEvent()
    {
        if(CanTriggerEvent())
        {
            stats.GetComponent<Animator>().SetTrigger("Coffee");
            stats.IncreaseStat(PrimaryStat);
            base.TriggerEvent();
            gameObject.SetActive(false);
        }
    }
}
