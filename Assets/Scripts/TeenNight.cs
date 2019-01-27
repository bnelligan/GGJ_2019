using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeenNight : MonoBehaviour
{
    public GameObject player;
    public Animator carAnim;

    public Sprite normalCar;

    public SpriteRenderer carSprite;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerStats>().gameObject;
        player.SetActive(false);
        carAnim.SetBool("ToHome", true);
        StartCoroutine("GetOut");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator GetOut()
    {
        yield return new WaitForSeconds(1.65f);
        player.SetActive(true);

    }
}
