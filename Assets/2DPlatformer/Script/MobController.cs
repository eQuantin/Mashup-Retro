using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobController : MonoBehaviour
{
    [SerializeField]
    float xMin, xMax;

    float dirX;
    float moveSpeed = 3f;
    bool moveRight = true;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < xMin) 
        {
            moveRight = true;
        }

        if (transform.position.x > xMax)
        {
            moveRight = false;
        }

        if (moveRight)
        {
            transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
            GetComponent<SpriteRenderer>().flipX = true;
        }

        else
        {
            transform.position = new Vector2(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }
}
