using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Vector2 screenPos;

    public GameObject player;

    public float speed;

    public bool movingRight;

    public bool movingLeft;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerStats>().gameObject;
        transform.position = new Vector3(player.transform.position.x, transform.position.y,transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        screenPos = Camera.main.WorldToViewportPoint(player.transform.position);

        if (screenPos.x < .1f)
        {
            movingLeft = true;
        }
        else if(screenPos.x > .9f)
        {
            movingRight = true;
        }

        if (movingLeft)
        {
            transform.Translate(-Vector3.right * speed * Time.deltaTime, Space.World);
        }
        else if (movingRight)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime, Space.World);
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            movingLeft = false;
        }
        if(Input.GetKeyUp(KeyCode.RightArrow))
        {
            movingRight = false;
        }
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            movingLeft= false;
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            movingRight= false;
        }

    }
}
