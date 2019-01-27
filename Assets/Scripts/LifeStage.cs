using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeStage : MonoBehaviour
{
    public string StageName { get; private set; }

    LifeEvent[] LifeEvents;

    [SerializeField]
    Age playerAge;
    public bool UseCustomScale = false;
    [SerializeField]
    Vector3 playerScale = Vector3.one;
    //[SerializeField]
    int eventCount = 20;

    PlayerStats player;

    private void Awake()
    {
        player = FindObjectOfType<PlayerStats>();
        LifeEvents = FindObjectsOfType<LifeEvent>();
        if(player)
        {
            player.PlayerAge = playerAge;

        }
        else
        {
            Debug.LogError("Player not found!!");
        }
        if(UseCustomScale)
        {
            player.transform.localScale = playerScale;
        }
    }
    private void Start()
    {
        //SpawnEvents();
        SetPlayerAnimatorController();
        if (player.HasGirlfriend)
        {
            Instantiate(player.girlPrefab, transform.position, transform.rotation);
        }
    }

    private void SpawnEvents()
    {
        List<LifeEvent> eventsToSpawn = new List<LifeEvent>();
        List<LifeEvent> eventsToDisable = new List<LifeEvent>(LifeEvents);

        for(int i = 0; i < eventCount && eventsToDisable.Count > 0; i++)
        {
            LifeEvent randEvent = eventsToDisable[Random.Range(0, eventsToDisable.Count)];
            eventsToSpawn.Add(randEvent);
            eventsToDisable.Remove(randEvent);
        }
        eventsToSpawn.ForEach(e => e.gameObject.SetActive(true));
        eventsToDisable.ForEach(e => e.gameObject.SetActive(false));
    }

    private void SetPlayerAnimatorController()
    {
        string animName = "Child";

        if(player.PlayerAge == Age.CHILD)
        {
            animName = "Child";
        }
        else if(player.PlayerAge == Age.TEEN)
        {
            animName = "Teen";
        }
        else if(player.PlayerAge == Age.ADULT)
        {
            animName = "Adult";
        }
        else if(player.PlayerAge == Age.ELDERLY)
        {
            animName = "Elderly";
        }
        RuntimeAnimatorController rtAnimator = Resources.Load($"Animators/{animName}") as RuntimeAnimatorController;
        player.GetComponent<Animator>().runtimeAnimatorController = rtAnimator;
    }
}
