using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy")]
    [SerializeField] float health = 100f;
    [SerializeField] float shotCounter;
    [SerializeField] int scoreValue = 150;

    [Header("Projectile")]
    [SerializeField] float minTimeBetweenShots = 0.2f;
    [SerializeField] float maxTimeBetweenShots = 3f;
    [SerializeField] GameObject laserPrefab;
    [SerializeField] float projectileSpeed = 4f;

    [Header("FX")]
    [SerializeField] GameObject deathVFX;
    [SerializeField] float durationOfDeath = .1f;
    [SerializeField] AudioClip deathSFX;
    [SerializeField] AudioClip fireSFX;
    [Range(0, 1)] [SerializeField] float deathVolume = .5f;
    [Range(0, 1)] [SerializeField] float fireVolume = .5f;

    // Start is called before the first frame update
    void Start()
    {
        shotCounter = UnityEngine.Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }

    // Update is called once per frame
    void Update()
    {
        CountDownAndShoot();
    }

    private void CountDownAndShoot()
    {
        shotCounter -= Time.deltaTime;
        if (shotCounter <= 0f)
        {
            Fire();
            shotCounter = UnityEngine.Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
    }

    private void Fire()
    {
        GameObject enemyLaser = Instantiate(
            laserPrefab,
            transform.position,
            Quaternion.identity) as GameObject;

        AudioSource.PlayClipAtPoint(fireSFX, Camera.main.transform.position, fireVolume);

        enemyLaser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer) { return; }
        ProcessHit(damageDealer);
    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();
        damageDealer.Hit();

        if (health == 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
        FindObjectOfType<GameSession>().AddToScore(scoreValue);

        if (!deathVFX) { return; }
        GameObject explosion = Instantiate(deathVFX, 
            transform.position, 
            Quaternion.identity) as GameObject;
        Destroy(explosion, durationOfDeath);

        AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position, deathVolume);
    }
}
