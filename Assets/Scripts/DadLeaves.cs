using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DadLeaves : MonoBehaviour
{
    public float timer;

    private bool called;

    public GameObject dad;

    public SpriteRenderer dadSprite;

    public Sprite idleSprite;

    public GameObject leaveEvent;

    public GameObject tear;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >  10 && !called)
        {
            StartCoroutine("dadLeave");
            called = true;
        }
    }

    IEnumerator dadLeave()
    {
        dadSprite.flipX = false;
        dad.GetComponent<Animator>().SetBool("dadLeave", true);
        yield return new WaitForSeconds(2f);
        leaveEvent.SetActive(true);
        tear.SetActive(true);
    }

    
}
