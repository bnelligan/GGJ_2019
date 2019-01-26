using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed;

    public SpriteRenderer fatherSprite;

    private bool moving;

    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            moving = true;
            anim.SetBool("Moving", moving);
            if (fatherSprite.flipX)
            {
                fatherSprite.flipX = false;
            }
            transform.Translate(Vector3.right * speed * Time.deltaTime, Space.World);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            moving = true;
            anim.SetBool("Moving", moving);
            if (!fatherSprite.flipX)
            {
                fatherSprite.flipX = true;
            }
            transform.Translate(-Vector3.right * speed * Time.deltaTime, Space.World);
         
        }
        else
        {
            moving = false;
            anim.SetBool("Moving", moving);
        }
    }
}