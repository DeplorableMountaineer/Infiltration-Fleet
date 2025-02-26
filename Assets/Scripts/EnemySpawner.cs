﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<WaveConfig> waveConfigs;
    [SerializeField] private int startingWave = 0;
    [SerializeField] private bool looping = false;

    // Start is called before the first frame update
    IEnumerator Start() {
        do {
            yield return StartCoroutine(SpawnAllWaves());
        } while (looping);
    }

    private IEnumerator SpawnAllWaves() {
        for (int waveIndex = startingWave; waveIndex < waveConfigs.Count; waveIndex++) {
            WaveConfig currentWave = waveConfigs[waveIndex];
            yield return StartCoroutine(SpawnAllEnemiesInWave(currentWave));
        }
    }

    private IEnumerator SpawnAllEnemiesInWave(WaveConfig waveConfig) {
        for (int i = 0; i < waveConfig.GetNumberOfEnemies(); i++) {
            GameObject go = Instantiate(waveConfig.GetEnemyPrefab(),
                waveConfig.GetWaypoints()[0].position,
                Quaternion.identity);
            go.GetComponent<Path>().SetWaveConfig(waveConfig);
            yield return new WaitForSeconds(waveConfig.GetSpawnInterval());
        }
    }
}
