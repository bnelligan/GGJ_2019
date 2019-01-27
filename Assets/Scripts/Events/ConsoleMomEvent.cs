using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsoleMomEvent : LifeEvent
{
    public GameObject player;
    public LevelChanger levelChanger;
    protected override void Awake()
    {
        EventName = "dfgasdg";
        EventDescription = "Psdgasdr";
        PrimaryStat = LifeStat.ROMANCE;
       
        base.Awake();
    }

    public override void TriggerEvent()
    {
        if(CanTriggerEvent())
        {
            // Play animation of playing with the blocks
            stats.DecreaseStat(PrimaryStat);
            player = FindObjectOfType<PlayerStats>().gameObject;
            player.GetComponent<PlayerController>().enabled = false;
            player.GetComponent<Animator>().SetBool("console", true);
            StartCoroutine(changeScenes());
            base.TriggerEvent();
        }
        else
        {
            Debug.LogWarning($"Already triggered event {EventName}");
        }
    }

    IEnumerator changeScenes()
    {
        yield return new WaitForSeconds(2f);
        levelChanger.FadeToNextLevel();
    }

}
