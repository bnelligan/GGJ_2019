using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSpawn : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update

    private void Awake()
    {
        player = FindObjectOfType<PlayerStats>().gameObject;
    }

    void Start()
    {

        player.transform.position = transform.position;
        //Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
