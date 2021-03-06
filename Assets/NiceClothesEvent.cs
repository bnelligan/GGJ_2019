﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NiceClothesEvent : LifeEvent
{
    SpriteRenderer sprite;

    protected override  void Awake()
    {
        EventName = "Nice Clothes";
        EventDescription = "Wear nice clothes to work";
        PrimaryStat = LifeStat.WEALTH;
        sprite = GetComponent<SpriteRenderer>();
        base.Awake();
    }

    public override void TriggerEvent()
    {
        if(CanTriggerEvent())
        {
            sprite.enabled = false;
            stats.IncreaseStat(PrimaryStat);
            //stats.GetComponentInChildren<SpriteRenderer>().sprite = niceClothes;
            stats.GetComponent<Animator>().SetBool("Nice Clothes", true);
            base.TriggerEvent();
        }
    }
}
