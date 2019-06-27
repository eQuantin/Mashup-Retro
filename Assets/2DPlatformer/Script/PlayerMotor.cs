using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]

public class PlayerMotor : MonoBehaviour
{
    // Attributs :  //////////////////////////////
    private Vector2     _horizontalVector;      //
    private Vector2     _jumpVector;            //
    private Rigidbody2D _rb;

    [SerializeField]
    private GameObject  _groundCheck;
    
    [SerializeField]
    private LayerMask   _layer;                    //
    
    [SerializeField]                                            //
    private float _jumpSpeed, _maxSpeed, _radiusCircle;
    
    private bool doubleJump;                   //
    //////////////////////////////////////////////

    // Public Methods : //////////////////////////////////////////////////////////////////////////////////
    public void Start()                                                                                 //
    {    
        _jumpVector = new Vector2(0f, _horizontalVector.y);
        doubleJump = true;                                                                                               //
        _horizontalVector = Vector2.zero;                                                               //
        _rb = GetComponent<Rigidbody2D>();                                                              //
    }                                                                                                   //
                                                                                                        //
    public void FixedUpdate()                                                                           //
    {                                                                                                   //
        PerformRunAndJump();                                                                            //
    }                                                                                                   //
                                                                                                        //
    public void RunAndJump(Vector2 horizontalVector)                                                    //
    {                                                                                                   //
        _horizontalVector = horizontalVector;                                                           //
    }                                                                                                   //
                                                                                                        //
    private void PerformRunAndJump()                                                                    //
    {     
        bool grounded = Physics2D.OverlapCircle(_groundCheck.transform.position, _radiusCircle, _layer);
        

        if (doubleJump && !grounded && _horizontalVector.y > 0) {
            Jump();
            doubleJump = false;
        }

        if (grounded && _horizontalVector.y > 0)
        {
            Jump();
            doubleJump = true;
        }
                                                                                                        //                                                      //
        _rb.velocity = new Vector2(_horizontalVector.x * _maxSpeed * Time.deltaTime, _rb.velocity.y);   //
                                                                                                        //
    }
    
    private void Jump()
    {
        _jumpVector.Set(0f, _horizontalVector.y);
        _rb.AddForce(_jumpVector * Time.deltaTime * _jumpSpeed, ForceMode2D.Impulse);
        Debug.Log("Jump !");
    }                                                                                                   //
    //////////////////////////////////////////////////////////////////////////////////////////////////////
}
