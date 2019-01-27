using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatchTVEvent : LifeEvent
{
    public GameObject player;
    public LevelChanger levelChanger;
    public GameObject sitSprite;
    private void Awake()
    {
        EventName = "tv";
        EventDescription = "tv";
        player = FindObjectOfType<PlayerStats>().gameObject;
        levelChanger = FindObjectOfType<LevelChanger>();
        PrimaryStat = LifeStat.ROMANCE;

    }

    public override void TriggerEvent()
    {
        if(CanTriggerEvent())
        {
            // Play animation of playing with the blocks
            
            stats.IncreaseStat(PrimaryStat);
            player.SetActive(false);
            sitSprite.SetActive(true);
            StartCoroutine(endNight());
            base.TriggerEvent();
        }
        else
        {
            Debug.LogWarning($"Already triggered event {EventName}");
        }
    }

    IEnumerator endNight()
    {
        yield return new WaitForSeconds(4f);
        levelChanger.FadeToNextLevel();
        yield return new WaitForSeconds(.75f);
        player.SetActive(true);
    }

}
