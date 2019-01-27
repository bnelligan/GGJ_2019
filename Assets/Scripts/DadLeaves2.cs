﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DadLeaves2 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public GameObject dad;
    public GameObject mom;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        player = FindObjectOfType<PlayerStats>().gameObject;
        player.GetComponent<Animator>().SetBool("Moving", false);
        player.GetComponent<PlayerController>().enabled = false;
        StartCoroutine("Dad");
    }

    IEnumerator Dad()
    {
        yield return new WaitForSeconds(1.5f);
        dad.GetComponentInChildren<SpriteRenderer>().flipX = true;
       
    }
}
