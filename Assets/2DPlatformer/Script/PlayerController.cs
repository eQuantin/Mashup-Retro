using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]

public class PlayerController : MonoBehaviour
{
    // Attributs :  /////////////
    private float _x;          //
    private float _y;          //
    private Vector2 _velocity; //
    private PlayerMotor motor; //
    /////////////////////////////

    // constructor : /////////////////////////
    PlayerController(float x, float y)      //
    {                                       //
        _y = y;                             //
        _x = x;                             //
        _velocity = new Vector2(x, y);      //
        motor = new PlayerMotor(200f, 800f);//
    }                                       //
    //////////////////////////////////////////

    // Public Methods : ///////////////////////
    public void Start()                      //
    {                                        //
        motor = GetComponent<PlayerMotor>(); //
    }                                        //
                                             //
    public void Update()                     //
    {                                        //
        _x = Input.GetAxisRaw("Horizontal"); //
        _y = Input.GetAxisRaw("Jump");       //
        _velocity.Set(_x, _y);               //
        motor.RunAndJump(_velocity);         //
    }                                        //
    ///////////////////////////////////////////
}


