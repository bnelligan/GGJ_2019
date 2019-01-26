using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeStage : MonoBehaviour
{
    public string StageName { get; private set; }

    LifeEvent[] LifeEvents;

    [SerializeField]
    Age playerAge;
    [SerializeField]
    int eventCount = 3;

    PlayerStats player;

    private void Awake()
    {
        player = FindObjectOfType<PlayerStats>();
        LifeEvents = FindObjectsOfType<LifeEvent>();
        player.PlayerAge = playerAge;
    }
    private void Start()
    {
        SpawnEvents();
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

    
}
