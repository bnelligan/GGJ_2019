using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LifeStat
{
    ROMANCE,
    WEALTH,
    WELLNESS,
    INTELLIGENCE
}
    
public class PlayerStats : MonoBehaviour
{
    public const int MAX_STAT_LEVEL = 5;
    Dictionary<LifeStat, int> statLookup = new Dictionary<LifeStat, int>
    {
        [LifeStat.ROMANCE] = 0,
        [LifeStat.WEALTH] = 0,
        [LifeStat.WELLNESS] = 0,
        [LifeStat.INTELLIGENCE] = 0
    };

    public void IncreaseStat(LifeStat stat)
    {
        statLookup[stat]++;
        if (statLookup[stat] > MAX_STAT_LEVEL)
        {
            Debug.LogWarning("Stat is at max: " + stat.ToString());
            statLookup[stat] = MAX_STAT_LEVEL;
        }
    }
    public void DecreaseStat(LifeStat stat)
    {
        statLookup[stat]--;
        if(statLookup[stat] < 0)
        {
            Debug.LogWarning("Stat is at minimum: " + stat.ToString());
            statLookup[stat] = 0;
        }
    }
}
