using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum LifeStat
{
    ROMANCE,
    WEALTH,
    WELLNESS,
    INTELLIGENCE
}
public enum Age
{
    CHILD,
    TEEN,
    ADULT,
    ELDERLY
}
    
public class PlayerStats : MonoBehaviour
{
    public const int MAX_STAT_LEVEL = 5;
    Dictionary<LifeStat, int> statLookup = new Dictionary<LifeStat, int>
    {
        [LifeStat.ROMANCE] = 2,
        [LifeStat.WEALTH] = 2,
        [LifeStat.WELLNESS] = 2,
        [LifeStat.INTELLIGENCE] = 2
    };

    public Slider scoreSlider;
    public int Romance { get { return statLookup[LifeStat.ROMANCE]; } }
    public int Wealth{ get { return statLookup[LifeStat.WEALTH]; } }
    public int Wellness { get { return statLookup[LifeStat.WELLNESS]; } }
    public int Intelligence { get { return statLookup[LifeStat.INTELLIGENCE]; } }
    public Age PlayerAge;

    private void Awake()
    {
        SetInitialStats();
    }
    private void SetInitialStats()
    {
        GameObject.FindWithTag(LifeStat.ROMANCE.ToString()).GetComponent<Slider>().value = (float)statLookup[LifeStat.ROMANCE];
        GameObject.FindWithTag(LifeStat.WEALTH.ToString()).GetComponent<Slider>().value = (float)statLookup[LifeStat.WEALTH];
        GameObject.FindWithTag(LifeStat.WELLNESS.ToString()).GetComponent<Slider>().value = (float)statLookup[LifeStat.WELLNESS];
        GameObject.FindWithTag(LifeStat.INTELLIGENCE.ToString()).GetComponent<Slider>().value = (float)statLookup[LifeStat.INTELLIGENCE];
    }
    public void IncreaseStat(LifeStat stat)
    {
        statLookup[stat]++;
        scoreSlider = GameObject.FindWithTag(stat.ToString()).GetComponent<Slider>();
        scoreSlider.value += 1;
        if (statLookup[stat] > MAX_STAT_LEVEL)
        {
            Debug.LogWarning("Stat is at max: " + stat.ToString());
            statLookup[stat] = MAX_STAT_LEVEL;
        }
        else
        {
            Debug.Log($"{stat.ToString()} stat increased to {statLookup[stat]}");
        }
    }
    public void DecreaseStat(LifeStat stat)
    {
        statLookup[stat]--;
        scoreSlider = GameObject.FindWithTag(stat.ToString()).GetComponent<Slider>();
        scoreSlider.value -= 1;
        if(statLookup[stat] < 0)
        {
            Debug.LogWarning("Stat is at minimum: " + stat.ToString());
            statLookup[stat] = 0;
        }
        else
        {
            Debug.Log($"{stat.ToString()} stat decreased to {statLookup[stat]}");
        }
    }
    
}
