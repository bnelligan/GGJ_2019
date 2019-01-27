using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartByBed : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
      
        player.transform.position = new Vector3(.808f,.0275f,0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
