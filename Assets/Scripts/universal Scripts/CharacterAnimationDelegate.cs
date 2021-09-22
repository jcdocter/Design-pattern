using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationDelegate : MonoBehaviour
{
    public GameObject leftArmAttackPoint, rightArmAttackPoint;

    void LeftArmAttackOn()
    {
        leftArmAttackPoint.SetActive(true);
    }

    void LeftArmAttackOff()
    {
        if (leftArmAttackPoint.activeInHierarchy)
        {
            leftArmAttackPoint.SetActive(false);
        }
    }

    void RightArmAttackOn()
    {
        rightArmAttackPoint.SetActive(true);
    }

    void RightArmAttackOff()
    {
        if (rightArmAttackPoint.activeInHierarchy)
        {
            rightArmAttackPoint.SetActive(false);
        }
    }
}
