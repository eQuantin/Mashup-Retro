using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]

public class PlayerController : MonoBehaviour
{
    // Attributs :  //////////////
    public float _x;            //
    public float _y;            //
    private float _jump;        //
    private Vector2 _velocity;  //
    private PlayerMotor motor;  //
    //////////////////////////////

    // constructor : /////////////////////////
    PlayerController(float x, float y)      //
    {                                       //
        _y = y;                             //
        _x = x;                             //
        _velocity = new Vector2(x, y);      //
        motor = new PlayerMotor();          //
    }                                       //
    //////////////////////////////////////////

    // Public Methods : //////////////////////////////////////
    public void Start()                                     //
    {                                                       //
        motor = GetComponent<PlayerMotor>();                //
    }                                                       //
                                                            //
    public void Update()                                    //
    {                                                       //
        _x = Input.GetAxisRaw("Horizontal");                //
                                                            //
        if (_x == -1)                                       //
        {                                                   //
            GetComponent<SpriteRenderer>().flipX = true;    //
        }                                                   //
                                                            //
        else if (_x == 1)                                   //
        {                                                   //
            GetComponent<SpriteRenderer>().flipX = false;   //
        }                                                   //
        _y = GetJump();                                     //
        _velocity.Set(_x, _y);                              //
        motor.RunAndJump(_velocity);                        //
    }                                                       //
                                                            //
    private float GetJump()                                 //
    {                                                       //
        bool jump = Input.GetKeyDown("space");              //
                                                            //
        if (jump)                                           //
        {                                                   //
            _jump = 1;                                      //
        }                                                   //
                                                            //
        else                                                //
        {                                                   //
            _jump = 0;                                      //
        }                                                   //
                                                            //
        return _jump;                                       //
    }                                                       //
    //////////////////////////////////////////////////////////
}


