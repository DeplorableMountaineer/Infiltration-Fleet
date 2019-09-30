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

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start() {
        shotCounter = UnityEngine.Random.Range(minTimeBetweenShots * .75f, minTimeBetweenShots * 2);
        rb = GetComponent<Rigidbody2D>();
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
        GameObject missile = Instantiate(missilePrefab, transform.position + missileOffset * Vector3.down,
            Quaternion.Euler(0, 0, 180));
        missile.GetComponent<Rigidbody2D>().velocity = new Vector2(0, missileSpeedMultiplier * -5f);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        ProcessHit(other.gameObject.GetComponent<DamageDealer>());
    }

    private void ProcessHit(DamageDealer damageDealer) {
        if (damageDealer) {
            health -= damageDealer.GetDamage();
            damageDealer.Hit();
            if (health <= 0) {
                Destroy(gameObject);
            }
        }
    }
}
