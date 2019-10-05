using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour {

    public void LoadGameOver() {
        Invoke("GameOver", 1f);
    }

    public void LoadGameScene() {
        SceneManager.LoadScene("Game");
    }

    public void LoadStartMenu() {
        SceneManager.LoadScene("Start Menu");
        Score sc = FindObjectOfType<Score>();
        if(sc) {
            sc.ResetScore();
        }
    }

    public void QuitGame() {
        Application.Quit();
    }

    private void GameOver() {
        SceneManager.LoadScene("Game Over");
    }


    private void OnEnable() {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable() {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        Score sc = FindObjectOfType<Score>();
        if(sc) {
            sc.UpdateScore();
        }
    }
}
