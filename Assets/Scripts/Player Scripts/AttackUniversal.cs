using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackUniversal : MonoBehaviour
{
    public LayerMask collisionLayer;
    public float radius = 1f;
    public float damage = 100f;

    public bool isPlayer;

    void Update()
    {
        DetectCollision();
    }

    void DetectCollision()
    {
        Collider[] hit = Physics.OverlapSphere(transform.position, radius, collisionLayer);

        if(hit.Length > 0)
        {
            hit[0].GetComponent<EnemyHealth>().TakeDamage(damage);

            Debug.Log(hit[0].gameObject.name);

            gameObject.SetActive(false);
        }
    }
}
