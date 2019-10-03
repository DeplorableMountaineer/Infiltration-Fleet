using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Configuration Parameters
    [Header("Player")]
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float xPad = 0.3f;
    [SerializeField] private float yPad = 0.15f;
    [SerializeField] private float rotateWithMotionFactor = 4f;

    [Header("Projectile")]
    [SerializeField] private float missileFiringInterval = 0.2f;

    private float xMin;
    private float xMax;
    private float yMin;
    private float yMax;
    private Gun gun;
    private Health health;

    private readonly HashSet<Coroutine> firingCoroutines = new HashSet<Coroutine>();

    // Start is called before the first frame update
    void Start() {
        SetUpMoveBoundaries();
        gun = GetComponent<Gun>();
        health = GetComponent<Health>();
    }

    // Update is called once per frame
    void Update() {
        Move();
        Fire();
    }

    private void Move() {
        float deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        float deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        Transform t = transform;
        Vector2 pos = t.position;
        float newXPos = Mathf.Clamp(pos.x + deltaX, xMin, xMax);
        float newYPos = Mathf.Clamp(pos.y + deltaY, yMin, yMax);

        t.position = new Vector2(newXPos, newYPos);
        t.eulerAngles = new Vector3(0, 0, -deltaX / 0.2f * rotateWithMotionFactor);
    }

    private void Fire() {
        if (Input.GetButtonDown("Fire1") && firingCoroutines.Count == 0) {
            firingCoroutines.Add(StartCoroutine(FireContinuously()));
        }

        if (Input.GetButtonUp("Fire1")) {
            foreach (Coroutine r in firingCoroutines) {
                StopCoroutine(r);
            }
            firingCoroutines.Clear();
        }
    }

    private IEnumerator FireContinuously() {
        while (true) {
            gun.Fire(Vector2.up);
            yield return new WaitForSeconds(missileFiringInterval);
        }
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

    private void SetUpMoveBoundaries() {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + xPad;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - xPad;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + yPad;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 0.5f, 0)).y;
    }

    private void OnDestroy() {
        GameOver();
    }


    private void GameOver() {
        FindObjectOfType<Level>().LoadGameOver();
    }
}
