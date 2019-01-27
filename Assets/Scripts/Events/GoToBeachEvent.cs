using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToBeachEvent : LifeEvent
{
    public GameObject player;
    public GameObject mom;
    public GameObject dad;
    private LevelChanger levelChanger;
    public Animator carAnim;
    private void Awake()
    {
        EventName = "Go To Beach";
        EventDescription = "Go to beach bruh";
        player = FindObjectOfType<PlayerStats>().gameObject;
        levelChanger = FindObjectOfType<LevelChanger>();
    }

    public override void TriggerEvent()
    {
        if (CanTriggerEvent())
        {
            Debug.Log("Go To Beach");
            StartCoroutine("DriveAway");
            base.TriggerEvent();
        }
        else
        {
            Debug.LogWarning($"Already triggered event {EventName}");
        }
    }

    IEnumerator DriveAway()
    {   
        player.SetActive(false);
        mom.SetActive(false);
        dad.SetActive(false);
        carAnim.SetBool("ToBeach",true);
        yield return new WaitForSeconds(2f);
        levelChanger.FadeToNextLevel();
        yield return new WaitForSeconds(.75f);
        player.SetActive(true);
    }
}
