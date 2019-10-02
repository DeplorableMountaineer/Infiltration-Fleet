using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Missile : MonoBehaviour
{
    [SerializeField] private float baseMissileSpeed = 20f;
    [FormerlySerializedAs("audioClip")] [SerializeField] private AudioClip FireSFX;

    public void Launch(float speedMultiplier, Vector2 direction) {
        GetComponent<Rigidbody2D>().velocity = direction.normalized * speedMultiplier * baseMissileSpeed;
        AudioSource.PlayClipAtPoint(FireSFX, transform.position);
    }
}
