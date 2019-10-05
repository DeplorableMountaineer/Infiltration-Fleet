using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Health : MonoBehaviour {
    [SerializeField] private float health = 200;
    [FormerlySerializedAs("deathVfx")] [SerializeField] private GameObject deathVFX;
    [FormerlySerializedAs("deathAudio")] [SerializeField] private AudioClip deathSFX;
    [SerializeField] float deathPointValue = 0;

    public void Hit(float damage) {
        health -= damage;
        if(health <= 0) {
            Die();
        }
    }

    private void Die() {
        if(deathPointValue > 0) {
            FindObjectOfType<Score>().UpdateScore(deathPointValue);
        }
        Instantiate(deathVFX,
            gameObject.transform.position,
            Quaternion.identity);
        AudioSource.PlayClipAtPoint(deathSFX, transform.position);
        Destroy(gameObject);
    }
}
