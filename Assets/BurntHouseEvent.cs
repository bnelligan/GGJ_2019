using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurntHouseEvent : LifeEvent
{
    public override void TriggerEvent()
    {
        if(CanTriggerEvent())
        {
            StartCoroutine(MournHouse());
            base.TriggerEvent();
        }
    }
    IEnumerator MournHouse()
    {
        stats.GetComponent<Animator>().SetTrigger("Cry");
        yield return new WaitForSeconds(6);
        FindObjectOfType<LevelChanger>().FadeToNextLevel();
    }
}
