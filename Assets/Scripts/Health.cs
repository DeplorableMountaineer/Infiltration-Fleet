using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Health : MonoBehaviour
{
    [SerializeField] private float health = 200;
    [FormerlySerializedAs("deathVfx")] [SerializeField] private GameObject deathVFX;
    [FormerlySerializedAs("deathAudio")] [SerializeField] private AudioClip deathSFX;

    public void Hit(float damage) {
        health -= damage;
        if (health <= 0) {
            Die();
        }
    }

    private void Die() {
        Instantiate(deathVFX,
            gameObject.transform.position,
            Quaternion.identity);
        AudioSource.PlayClipAtPoint(deathSFX, transform.position);
        Destroy(gameObject);
    }
}
