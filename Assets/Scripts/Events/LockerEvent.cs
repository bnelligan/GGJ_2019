using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockerEvent : LifeEvent
{
    SpriteRenderer spriteRenderer;

    [SerializeField]
    Sprite Sprite_MissingBook;


    protected override void Awake()
    {
        EventName = "Locker";
        EventDescription = "Cool stuff in here...";
        PrimaryStat = LifeStat.INTELLIGENCE;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public override void TriggerEvent()
    {
        if(CanTriggerEvent())
        {
            if(spriteRenderer.enabled == false)
            {
                spriteRenderer.enabled = true;
                Debug.Log("Locker opened!");
            }
            else
            {
                spriteRenderer.sprite = Sprite_MissingBook;
                stats.IncreaseStat(PrimaryStat);
                Debug.Log("Took Book!");
                base.TriggerEvent();
            }
        }
    }

}
