using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Stat
{
    ROMANCE,
    WEALTH,
    WELLNESS,
    INTELLIGENCE
}
    
public class PlayerStats : MonoBehaviour
{
    public const int MAX_STAT_LEVEL = 5;
    Dictionary<Stat, int> statLookup = new Dictionary<Stat, int>
    {
        [Stat.ROMANCE] = 0,
        [Stat.WEALTH] = 0,
        [Stat.WELLNESS] = 0,
        [Stat.INTELLIGENCE] = 0
    };

    public void IncreaseStat(Stat stat)
    {
        statLookup[stat]++;
        if (statLookup[stat] > MAX_STAT_LEVEL)
        {
            Debug.LogWarning("Stat is at max: " + stat.ToString());
            statLookup[stat] = MAX_STAT_LEVEL;
        }
    }
    public void DecreaseStat(Stat stat)
    {
        statLookup[stat]--;
        if(statLookup[stat] < 0)
        {
            Debug.LogWarning("Stat is at minimum: " + stat.ToString());
            statLookup[stat] = 0;
        }
    }

    
}
