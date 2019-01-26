using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LifeEvent : MonoBehaviour
{
    public string EventName;
    public string EventDescription;
    public LifeStat PrimaryStat { get; protected set; }
    protected PlayerStats stats;
    public bool IsTriggered { get; private set; }

    private void Start()
    {
        stats = FindObjectOfType<PlayerStats>();
        IsTriggered = false;
    }
    /// <summary>
    /// Override this. Call the base function last since it sets the IsTriggered flag
    /// </summary>
    public virtual void TriggerEvent()
    {
        IsTriggered = true;
    }

    /// <summary>
    /// Call this with base first in any overrides
    /// </summary>
    /// <returns></returns>
    public virtual bool CanTriggerEvent()
    {
        bool canTrigger = false;
        if (IsTriggered)
        {
            Debug.LogWarning($"Already triggered event {EventName}");
            canTrigger = false;
        }
        else
        {
            canTrigger = true;
        }
        return canTrigger;
    }
}
