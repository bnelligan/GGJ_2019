using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class TeenSetup : MonoBehaviour
{
    public GameObject player;

    private SpriteRenderer playerSprite;

    public AnimatorController teenAnim;

    public Sprite teenSprite;

    private void Awake()
    {
        player = FindObjectOfType<PlayerStats>().gameObject;
    }

    // Start is called before the first frame update
    void Start()
    {
       
        player.GetComponent<Animator>().runtimeAnimatorController = teenAnim;
        playerSprite = player.GetComponentInChildren<SpriteRenderer>();
        playerSprite.sprite = teenSprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
