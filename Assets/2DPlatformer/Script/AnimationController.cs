using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StateAnim
{
    Idle,
    Run,
    Jump
}

public class AnimationController : MonoBehaviour
{
    private Animator anim;
    private PlayerController player;
    private PlayerMotor motor;
    private StateAnim state;

    void Start()
    {
        anim = GetComponent<Animator>();
        player = GetComponent<PlayerController>();
        motor = GetComponent<PlayerMotor>();
    }

    void Update()
    {
        bool run = player._x == 1 || player._x == -1;
        if (run && motor._Grounded)
        {
            state = StateAnim.Run;
        }

        else if(!run && motor._Grounded)
        {
            state = StateAnim.Idle;
        }

        else if (!motor._Grounded)
        {
            state = StateAnim.Jump;
        }

        Animation();
    }

    private void Animation()
    {
        switch(state)
        {
            case StateAnim.Idle:
                anim.SetBool("Idle", true);
                anim.SetBool("Run", false);
                anim.SetBool("Ground", true);
                break;

            case StateAnim.Run:
                anim.SetBool("Idle", false);
                anim.SetBool("Run", true);
                anim.SetBool("Ground", true);
                break;

            case StateAnim.Jump:
                anim.SetBool("Idle", false);
                anim.SetBool("Run", false);
                anim.SetBool("Ground", false);
                break;
        }
    }
}
