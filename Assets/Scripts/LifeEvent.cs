using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LifeEvent : MonoBehaviour
{
    public string EventName { get; protected set; }
    public LifeStat PrimaryStat { get; protected set; }

    public abstract void TriggerEvent();
    public abstract bool CanTriggerEvent();
}
