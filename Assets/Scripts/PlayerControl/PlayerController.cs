using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed;

    public SpriteRenderer sprite;

    private bool moving;

    public Animator anim;

    private Rigidbody2D body;

    private float xInput;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        var moveVector = new Vector2(xInput,transform.position.y);
        if (Input.GetKey(KeyCode.RightArrow))
        {
            moving = true;
            anim.SetBool("Moving", moving);
            //anim.SetBool("Flip", true);

            if (!sprite.flipX)
            {
                sprite.flipX = true;
            }
           // transform.Translate(Vector3.right * speed * Time.deltaTime, Space.World);
           body.MovePosition(new Vector2((transform.position.x+moveVector.x*speed*Time.deltaTime),transform.position.y));
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            moving = true;
            anim.SetBool("Moving", moving);
            //anim.SetBool("Flip", false);

            if (sprite.flipX)
            {
                sprite.flipX = false;
            }
            body.MovePosition(new Vector2((transform.position.x+moveVector.x*speed*Time.deltaTime),transform.position.y));        }
        else
        {
            moving = false;
            anim.SetBool("Moving", moving);
        }
    }
}