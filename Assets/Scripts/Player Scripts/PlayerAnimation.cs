using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator anim;
    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void Walk(bool move)
    {
        anim.SetBool(AnimationTags.WALK_PARAMETER, move);
    }

    public void Charge(bool charge)
    {
        anim.SetBool(AnimationTags.CHARGE_PARAMETER, charge);
    }

    public void Jump()
    {
        anim.SetTrigger(AnimationTags.JUMP_PARAMETER);
    }

    public void DoubleJump()
    {
        anim.SetTrigger(AnimationTags.DOUBLE_JUMP_PARAMETER);
    }

    public void Attack1()
    {
        anim.SetTrigger(AnimationTags.ATTACK_1_PARAMETER);
    }

    public void Attack2()
    {
        anim.SetTrigger(AnimationTags.ATTACK_2_PARAMETER);
    }

    public void Attack3()
    {
        anim.SetTrigger(AnimationTags.ATTACK_3_PARAMETER);
    }

    public void SpecialAttack()
    {
        anim.SetTrigger(AnimationTags.SPECIAL_ATTACK_PARAMETER);
    }
}
