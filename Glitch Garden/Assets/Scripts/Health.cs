using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 100;

    [Header("FX")]
    [SerializeField] GameObject deathVFX;
    [SerializeField] float durationOfDeath;

    public void DealDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);

        if (!deathVFX) { return; }
        GameObject explosion = Instantiate(deathVFX, 
            transform.position, 
            Quaternion.identity);
        Destroy(explosion, durationOfDeath);
    }
}
