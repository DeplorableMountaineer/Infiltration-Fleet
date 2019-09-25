using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    [SerializeField] private float baseMissileSpeed = 20f;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void Launch(float speedMultiplier) {
        GetComponent<Rigidbody2D>().velocity =
            new Vector2(0, speedMultiplier * baseMissileSpeed);
    }
}
