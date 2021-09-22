using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyHealth : MonoBehaviour
{
    public float health = 100f;

    public TextMeshProUGUI deathName;

    public void TakeDamage(float amount)
    {
        health -= amount;

        if(health <= 0f)
        {
            deathName.text = "Death";
            Debug.Log("It's death");
        }
    }
}
