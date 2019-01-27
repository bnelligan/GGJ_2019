using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToWorkEvent : LifeEvent 
{
    private LevelChanger levelChanger;
    public Animator carAnim;
    protected override void Awake()
    {
        EventName = "Work";
        EventDescription = "The bills won't pay themselves...";
        levelChanger = FindObjectOfType<LevelChanger>();
        base.Awake();
    }
    public override void TriggerEvent()
    {
        if(CanTriggerEvent())
        {
            Debug.Log("Off to work!");
            StartCoroutine("DriveToWork");
            base.TriggerEvent();
        }
    }

    IEnumerator DriveToWork()
    {
        stats.gameObject.SetActive(false);
        carAnim.SetBool("ToWork", true);
        yield return new WaitForSeconds(2f);
        levelChanger.FadeToNextLevel();
        yield return new WaitForSeconds(.75f);
        stats.gameObject.SetActive(true);
    }
}
