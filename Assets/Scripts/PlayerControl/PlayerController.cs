using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public float speed;

    public SpriteRenderer fatherSprite;

    private bool moving;

    public Animator anim;

    private Rigidbody2D body;

    private float xInput;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "School")
        {
            transform.localScale = new Vector3(1.4738f,1.4738f,1.4738f);
        }
        else
        {
            transform.localScale = new Vector3(1,1,1);
        }
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
            if (!fatherSprite.flipX)
            {
                fatherSprite.flipX = true;
            }
           // transform.Translate(Vector3.right * speed * Time.deltaTime, Space.World);
           body.MovePosition(new Vector2((transform.position.x+moveVector.x*speed*Time.deltaTime),transform.position.y));
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            moving = true;
            anim.SetBool("Moving", moving);
            if (fatherSprite.flipX)
            {
                fatherSprite.flipX = false;
            }
            body.MovePosition(new Vector2((transform.position.x+moveVector.x*speed*Time.deltaTime),transform.position.y));        }
        else
        {
            moving = false;
            anim.SetBool("Moving", moving);
        }
    }
}