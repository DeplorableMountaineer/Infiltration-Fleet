using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Way Configuration")]
public class WaveConfig : ScriptableObject
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject pathPrefab;
    [SerializeField] private float spawnInterval = 0.5f;
    [SerializeField] private float spawnRandomness = 0.3f;
    [SerializeField] private int numberOfEnemies = 5;
    [SerializeField] private float moveSpeed = 2f;

    public GameObject GetEnemyPrefab() { return enemyPrefab; }

    public GameObject GetPathPrefab() { return pathPrefab; }

    public float GetSpawnInterval() { return spawnInterval; }

    public float GetSpawnRandomness() { return spawnRandomness; }

    public int GetNumberOfEnemies() { return numberOfEnemies; }

    public float GetMoveSpeed() { return moveSpeed; }

    public List<Transform> GetWaypoints() {
        List<Transform> waypoints = new List<Transform>();
        foreach (Transform wp in pathPrefab.transform) {
            waypoints.Add(wp);
        }
        return waypoints;
    }
}
