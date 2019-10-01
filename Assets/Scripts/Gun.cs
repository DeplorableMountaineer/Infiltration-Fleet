using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject missilePrefab;
    [SerializeField] private float missileSpeedMultiplier = 1f;
    [SerializeField] private float missileOffset = 0.2f;
    [SerializeField] private float rapidFireInterval = 0.2f;

    public void Fire(Vector2 direction) {
        GameObject missile = Instantiate(missilePrefab, transform.position + missileOffset * Vector3.up,
            Quaternion.identity);
        missile.GetComponent<Missile>().Launch(missileSpeedMultiplier, direction);
    }
}
