using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float damage = 100f;

    private GameObject player;
   // private EnemyHealth enemyHealth;

    void Start()
    {
        player = FindObjectOfType<PlayerMovement>().gameObject;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject != player)
        {
            other.GetComponent<EnemyHealth>().TakeDamage(damage);
            Debug.Log("poof");
            Destroy(gameObject);
        }
    }
}
