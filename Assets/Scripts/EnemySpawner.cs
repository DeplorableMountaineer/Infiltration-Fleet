using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<WaveConfig> waveConfigs;

    private int startingWave = 0;

    // Start is called before the first frame update
    void Start() {
        WaveConfig currentWave = waveConfigs[startingWave];
        StartCoroutine(SpawnAllEnemiesInWave(currentWave));
    }

    private IEnumerator SpawnAllEnemiesInWave(WaveConfig waveConfig) {
        for (int i = 0; i < waveConfig.GetNumberOfEnemies(); i++) {
            GameObject go = Instantiate(waveConfig.GetEnemyPrefab(),
                waveConfig.GetWaypoints()[0].position,
                Quaternion.identity);
            yield return new WaitForSeconds(waveConfig.GetSpawnInterval());
        }
    }

    // Update is called once per frame
    void Update() {

    }
}
