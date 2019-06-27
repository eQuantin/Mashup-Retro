using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienMovement : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody2D _rb;
    public Vector2 _velocity;

    public void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        moveSpeed = 15f;
        _velocity = new Vector2(moveSpeed, _rb.velocity.y);
    }

    // Update is called once per frame
    void Update()
    {
        _rb.velocity = _velocity;
        if (_rb.position.x > 30) {
            _rb.transform.position = new Vector2(Random.Range(-20f, -30f), Random.Range(-3f, 8f));
        }
    }
}