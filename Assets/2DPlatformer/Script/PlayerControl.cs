using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 0.18f;
    public float jumph = 1.0f;

    void Start() { print("Start"); }

    void Update()
    {

        Vector3 dp = new Vector3();

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.Q)) 
        {
            dp.x -= speed;
        }

        if (Input.GetKey(KeyCode.D))
        {
            dp.x += speed;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            dp.y += jumph;
        }

        transform.position += dp;
    }
}
