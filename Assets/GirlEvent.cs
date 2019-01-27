using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirlEvent : LifeEvent
{
    float minDistance = .3f;
    float speed = 0.5f;
    bool isFollowing = false;
    SpriteRenderer spriteRenderer;

    protected override void Awake()
    {
        EventName = "Girlfriend";
        EventDescription = "Pretty cute, but she never pays any attention...";
        PrimaryStat = LifeStat.ROMANCE;
        spriteRenderer = GetComponent<SpriteRenderer>();
        base.Awake();
    }
    protected override void Update()
    {
        base.Update();
        if (isFollowing)
        {
            float sqDist = (stats.transform.position - transform.position).sqrMagnitude;
            if (sqDist > minDistance * minDistance)
            {
                bool IsLeft = stats.transform.position.x < transform.position.x;
                Vector3 moveVec = Vector3.right * speed * Time.deltaTime;
                if (IsLeft)
                {
                    moveVec *= -1;
                    spriteRenderer.flipX = false;
                }
                else
                {
                    spriteRenderer.flipX = true;
                }
                transform.Translate(moveVec);
                GetComponent<Animator>().SetBool("Moving", true);
            }
            else
            {
                GetComponent<Animator>().SetBool("Moving", false);
            }
        }
    }

    public override void TriggerEvent()
    {
        if(CanTriggerEvent() && HasRequiredStats())
        {
            FollowPlayer();
            stats.IncreaseStat(PrimaryStat);
            base.TriggerEvent();
        }
        
    }
    public override bool CanTriggerEvent()
    {
        bool canTrigger = base.CanTriggerEvent();
        if(canTrigger)
        {
            if(HasRequiredStats())
            {
                canTrigger = true;
            }
            else
            {
                if (stats?.transform.position.x < transform.position.x)
                {
                    GetComponent<SpriteRenderer>().flipX = true;
                }
                else if (stats?.transform.position.x > transform.position.x)
                {
                    GetComponent<SpriteRenderer>().flipX = false;
                }
            }
        }
        return canTrigger;
    }
    public void FollowPlayer()
    {
        isFollowing = true;
        stats.HasGirlfriend = true;
        Debug.Log("Following player!");
    }
    public bool HasRequiredStats()
    {
        if(stats)
        {
            return stats.Romance >= 3 && stats.Wellness >= 3 && stats.Wealth >= 2 && stats.Intelligence >= 2;
        }
        else
        {
            return false;
        }
    }
    
}
