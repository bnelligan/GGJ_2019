using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Office : LifeEvent
{
    int workCount = 5;
    private LevelChanger levelChanger;
    public bool CanPress = false;

    // Start is called before the first frame update
    protected override void Start()
    {
        stats = FindObjectOfType<PlayerStats>();
        levelChanger = FindObjectOfType<LevelChanger>();
        base.Start();
    }
    protected override void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            TriggerEvent();
        }
        base.Update();
    }
    public override void TriggerEvent()
    {
        if(CanTriggerEvent())
        {
            workCount--;
            Debug.Log("Work done! Remaining: " + workCount);
            CanPress = false;
            GetComponentInChildren<Animator>().SetTrigger("Pressed");
            if(workCount <= 0)
            {
                base.TriggerEvent();
                stats.IncreaseStat(LifeStat.WEALTH);
                stats.GetComponent<SpriteRenderer>().enabled = true;
                levelChanger.FadeToNextLevel();
            }
        }
    }
    public override bool CanTriggerEvent()
    {
       return base.CanTriggerEvent() && CanPress;
    }
}
