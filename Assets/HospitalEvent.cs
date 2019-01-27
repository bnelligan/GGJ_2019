using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HospitalEvent : LifeEvent
{
    [SerializeField]
    GameObject DivineIntervention;
    [SerializeField]
    GameObject LifeSupport;

    protected override void Start()
    {
        base.Start();
        int totalScore = stats.CalcTotalScore();
        int avgScore = totalScore / 4;
        int fCount = avgScore - 1;
        
        
        Debug.Log($"You have {fCount} friends at your deathbed...");
        GameObject[] friends = GameObject.FindGameObjectsWithTag("HospitalWitness");
        foreach(GameObject f in friends)
        {
            if(fCount <= 0)
            {
                f.SetActive(false);
            }
            else
            {
                f.SetActive(true);
                fCount--;
            }
        }
        TriggerEvent();
    }
    public override void TriggerEvent()
    {
        StartCoroutine(Die());
        base.TriggerEvent();
    }
    IEnumerator Die()
    {
        GetComponent<Animator>().enabled = true;
        yield return new WaitForSeconds(10);
        DivineIntervention.GetComponent<Animator>().enabled = true;
        LifeSupport.GetComponent<Animator>().SetTrigger("Dead");
        yield return new WaitForSeconds(10);
        FindObjectOfType<LevelChanger>().FadeOut();
    }
    
}
