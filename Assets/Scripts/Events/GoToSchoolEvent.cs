using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToSchoolEvent : LifeEvent
{
    public Animator carAnim;
    public GameObject player;
    public LevelChanger levelChanger;
    protected override void Awake()
    {
        player = FindObjectOfType<PlayerStats>().gameObject;
        EventName = "schoool";
        EventDescription = "go to school";
    }

    public override void TriggerEvent()
    {
        if(CanTriggerEvent())
        {
            carAnim.enabled = true;
            StartCoroutine("driveToSchool");
            base.TriggerEvent();
        }
        else
        {
            Debug.LogWarning($"Already triggered event {EventName}");
        }
    }

    IEnumerator driveToSchool()
    {
        player.SetActive(false);
        carAnim.SetBool("ToSchool",true);
        yield return new WaitForSeconds(2f);
        levelChanger.FadeToNextLevel();
        yield return new WaitForSeconds(.75f);
        player.SetActive(true);
    }


}
