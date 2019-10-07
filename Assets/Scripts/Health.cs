using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class Health : MonoBehaviour {
    [SerializeField] private float health = 200;
    [FormerlySerializedAs("deathVfx")] [SerializeField] private GameObject deathVFX;
    [FormerlySerializedAs("deathAudio")] [SerializeField] private AudioClip deathSFX;
    [SerializeField] float deathPointValue = 0;
    [SerializeField] private TextMeshProUGUI healthText = null;

    private void Start() {
        if(healthText) {
            healthText.text = Mathf.RoundToInt(health).ToString();
        }
    }

    public void Hit(float damage) {
        health -= damage;
        if(healthText) {
            healthText.text = Mathf.RoundToInt(health).ToString();
        }
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
