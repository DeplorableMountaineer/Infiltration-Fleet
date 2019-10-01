using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    [SerializeField] private float baseMissileSpeed = 20f;

    public void Launch(float speedMultiplier, Vector2 direction) {
        GetComponent<Rigidbody2D>().velocity = direction.normalized * speedMultiplier * baseMissileSpeed;
    }
}
