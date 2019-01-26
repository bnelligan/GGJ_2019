﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed;

    public SpriteRenderer rightSprite;

    public SpriteRenderer leftSprite;

    private SpriteRenderer defaultSprite;
    // Start is called before the first frame update
    void Start()
    {
        defaultSprite = leftSprite;
        defaultSprite.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime, Space.World);
            if (!rightSprite.enabled)
            {
                rightSprite.enabled = true;
            }

            if (leftSprite.enabled)
            {
                leftSprite.enabled = false;
            }
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-Vector3.right * speed * Time.deltaTime, Space.World);
            if (rightSprite.enabled)
            {
                rightSprite.enabled = false;
            }

            if (!leftSprite.enabled)
            {
                leftSprite.enabled = true;
            }
        }
    }
}