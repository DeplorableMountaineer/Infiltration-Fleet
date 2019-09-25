using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Configuration Parameters
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float xPad = 0.3f;
    [SerializeField] private float yPad = 0.15f;
    [SerializeField] private GameObject missilePrefab;
    [SerializeField] private float missileSpeed = 20f;
    [SerializeField] private float missileOffset = 0.2f;


    private float xMin;
    private float xMax;
    private float yMin;
    private float yMax;

    // Start is called before the first frame update
    void Start() {
        SetUpMoveBoundaries();
    }

    // Update is called once per frame
    void Update() {
        Move();
        Fire();
    }

    private void Move() {
        float deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        float deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        float newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
        float newYPos = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);

        transform.position = new Vector2(newXPos, newYPos);
    }

    private void Fire() {
        if (Input.GetButtonDown("Fire1")) {
            GameObject missile = Instantiate(missilePrefab, transform.position + missileOffset * Vector3.up, Quaternion.identity);
            missile.GetComponent<Rigidbody2D>().velocity = new Vector2(0, missileSpeed); //TODO move missileSpeed to missile prefab?
        }
    }

    private void SetUpMoveBoundaries() {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + xPad;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - xPad;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + yPad;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 0.5f, 0)).y;
    }
}
