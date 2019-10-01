using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float shotCounter;
    [SerializeField] private float minTimeBetweenShots = 0.2f;
    [SerializeField] private float maxTimeBetweenShots = 3f;

    private Gun gun;
    private Health health;

    // Start is called before the first frame update
    void Start() {
        shotCounter = UnityEngine.Random.Range(minTimeBetweenShots * .75f, minTimeBetweenShots * 2);
        gun = GetComponent<Gun>();
        health = GetComponent<Health>();
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
            health.Hit(damageDealer.GetDamage());
            damageDealer.Hit();
        }
    }
}
