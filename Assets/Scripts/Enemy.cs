using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float health = 100;
    [SerializeField] private float shotCounter;
    [SerializeField] private float minTimeBetweenShots = 0.2f;
    [SerializeField] private float maxTimeBetweenShots = 3f;
    [SerializeField] private GameObject missilePrefab;
    [SerializeField] private float missileSpeedMultiplier = 1f;
    [SerializeField] private float missileOffset = 0.8f;

    [Header("Death Effects")]
    [SerializeField] private GameObject explosionPrefab;
    [SerializeField] private float explosionDuration = 1f;


    private GameObject explosionInstance;
    private Gun gun;

    // Start is called before the first frame update
    void Start() {
        shotCounter = UnityEngine.Random.Range(minTimeBetweenShots * .75f, minTimeBetweenShots * 2);
        gun = GetComponent<Gun>();
    }

    // Update is called once per frame
    void Update() {
        CountDownAndShoot();
    }

    private void CountDownAndShoot() {
        shotCounter -= Time.deltaTime;
        if (shotCounter <= 0f) {
            Fire();
        }
    }

    private void Fire() {
        shotCounter = UnityEngine.Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        gun.Fire(Vector2.down);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        ProcessHit(other.gameObject.GetComponent<DamageDealer>());
    }

    private void ProcessHit(DamageDealer damageDealer) {
        if (damageDealer) {
            health -= damageDealer.GetDamage();
            damageDealer.Hit();
            if (health <= 0) {
                Die();
            }
        }
    }

    private void Die() {
        explosionInstance = Instantiate(explosionPrefab,
                            gameObject.transform.position,
                            Quaternion.identity);
        Invoke("destroyExplosion", explosionDuration);
        Destroy(gameObject);
    }


    private void destroyExplosion() {
        if (explosionInstance) {
            Destroy(explosionInstance);
        }
    }
}
