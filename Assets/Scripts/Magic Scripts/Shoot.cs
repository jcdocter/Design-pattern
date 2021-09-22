using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public static bool fire = false;

    public float fireSpeed = 6f;
    public GameObject projectile;

    public Transform firePosition;

    public void ShootFireBall()
    {
        if (fire)
        {
            GameObject fireball = Instantiate(projectile, firePosition.position, Quaternion.identity) as GameObject;

            Rigidbody rb = fireball.GetComponent<Rigidbody>();
            rb.velocity = transform.forward * fireSpeed;

            fire = false;
        }
    }

}
