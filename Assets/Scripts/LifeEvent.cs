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
    public bool IsTriggered { get; set; }
    public bool IsPromptVisible { get { return prompt.activeInHierarchy; } }
    public bool AutoTriggerEvent = false;
    GameObject prompt;
    public KeyCode ActivateKey = KeyCode.E;

    private void Start()
    {
        stats = FindObjectOfType<PlayerStats>();
        prompt = Resources.Load("Prefabs/Prompt") as GameObject;
        prompt = Instantiate(prompt, transform);
        prompt.SetActive(false);
        IsTriggered = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(ActivateKey) && IsPromptVisible)
        {
            TriggerEvent();
        }
        else if(!CanTriggerEvent() && IsPromptVisible)
        {
            HidePrompt();
        }
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
            canTrigger = false;
        }
        else
        {
            canTrigger = true;
        }
        return canTrigger;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("TRIGGERED");
        stats = collision.GetComponent<PlayerStats>();
        if(stats && CanTriggerEvent())
        {
            // Show popup to activate the event
            if(AutoTriggerEvent)
            {
                TriggerEvent();
            }
            else
            {
                ShowPrompt();
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        stats = collision.GetComponent<PlayerStats>();
        if(stats && IsPromptVisible)
        {
            HidePrompt();
        }
    }

    private void ShowPrompt()
    {
        prompt.SetActive(true);
    }
    private void HidePrompt()
    {
        prompt.SetActive(false);
    }
}
