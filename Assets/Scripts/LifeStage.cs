using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeStage : MonoBehaviour
{
    public string StageName { get; private set; }
    public List<LifeEvent> LifeEvents = new List<LifeEvent>();

    PlayerStats player;

    private void Start()
    {
        player = FindObjectOfType<PlayerStats>();
    }

    private void SpawnEvents()
    {
        
    }
}
