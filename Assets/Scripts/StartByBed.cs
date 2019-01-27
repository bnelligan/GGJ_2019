using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartByBed : MonoBehaviour
{
    public GameObject player;

    public GameObject occupiedBed;

    public GameObject alarmAnim;

    public Vector3 startOffset = Vector3.zero;

    public Sprite alarmIdle;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerStats>().gameObject;
        player.SetActive(false);
        player.transform.position = transform.position + startOffset;
        StartCoroutine("WakeyWakey");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator WakeyWakey()
    {
        yield return new WaitForSeconds(2.5f);
        alarmAnim.GetComponent<Animator>().enabled = true;
        yield return new WaitForSeconds(4f);
        alarmAnim.GetComponent<Animator>().enabled = false;
        alarmAnim.GetComponentInChildren<SpriteRenderer>().sprite = alarmIdle;
        yield return new WaitForSeconds(2f);
        Destroy(occupiedBed);
        player.SetActive(true);
    }
}
