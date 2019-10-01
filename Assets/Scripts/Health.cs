using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float health = 200;
    [SerializeField] private GameObject deathVfx;

    public void Hit(float damage) {
        health -= damage;
        if (health <= 0) {
            Die();
        }
    }

    private void Die() {
        Instantiate(deathVfx,
            gameObject.transform.position,
            Quaternion.identity);
        Destroy(gameObject);
    }
}
