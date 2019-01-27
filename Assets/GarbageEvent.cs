using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageEvent : LifeEvent
{
    [SerializeField]
    List<GameObject> Loot;

    protected override void Awake()
    {
        EventName = "Garbage Diver";
        EventDescription = "Ewww....";
        PrimaryStat = LifeStat.WELLNESS;
        if(Loot == null)
        {
            Loot = new List<GameObject>();
        }
    }

    public override void TriggerEvent()
    {
        if(CanTriggerEvent())
        {
            stats.DecreaseStat(LifeStat.WELLNESS);
            Instantiate(RandomLoot(), stats.transform);
        }
        base.TriggerEvent();
    }
    private GameObject RandomLoot()
    {
        return Loot[Random.Range(0, Loot.Count)];
    }
}
