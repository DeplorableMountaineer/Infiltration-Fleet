using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    private WaveConfig waveConfig;
    private int targetWaypoint = 0;
    private float delta = .1f;
    private List<Transform> waypoints;

    // Start is called before the first frame update
    void Start() {
        waypoints = waveConfig.GetWaypoints();
    }

    // Update is called once per frame
    void Update() {
        Move();
    }

    public void SetWaveConfig(WaveConfig waveConfig) {
        this.waveConfig = waveConfig;
    }

    private void Move() {
        if (waveConfig) {
            if (targetWaypoint < waypoints.Count) {
                float moveSpeed = waveConfig.GetMoveSpeed();
                transform.position = Vector2.MoveTowards(transform.position, waypoints[targetWaypoint].position,
                    Time.deltaTime * moveSpeed);
                if (Vector2.Distance(waypoints[targetWaypoint].position, transform.position) < delta) {
                    targetWaypoint++;
                }
            } else {
                Destroy(gameObject);
            }
        }
    }
}
