using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]

public class PlayerMotor : MonoBehaviour
{
    // Attributs :  //////////////////////////////
    private Vector2     _horizontalVector;      //
    private Vector2     _jumpVector;            //
    private Rigidbody2D _rb;                    //
                                                //
    public float _jumpSpeed;                    //
    public float _maxSpeed;                     //
    //////////////////////////////////////////////

    // Constructor : /////////////////////////////////////////
    public PlayerMotor(float jumpSpeed, float maxSpeed)     //
    {                                                       //
        _rb.useAutoMass = true;                             //
        _jumpSpeed = jumpSpeed;                             //
        _maxSpeed = maxSpeed;                               //
        _jumpVector = new Vector2(0f, _horizontalVector.y); //
    }                                                       //
    //////////////////////////////////////////////////////////

    // Public Methods : //////////////////////////////////////////////////////////////////////////////////
    public void Start()                                                                                 //
    {                                                                                                   //
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
    {                                                                                                   //
        _jumpVector.Set(0f, _horizontalVector.y);                                                       //
        _rb.velocity = new Vector2(_horizontalVector.x * _maxSpeed * Time.deltaTime, _rb.velocity.y);   //
        if (_rb.position.y < 0)
            _rb.AddForce(_jumpVector * Time.deltaTime * _jumpSpeed, ForceMode2D.Impulse);               //
    }                                                                                                   //
    //////////////////////////////////////////////////////////////////////////////////////////////////////
}
