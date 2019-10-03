using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{

    public void LoadGameOver() {
        Invoke("GameOver", 1f);
    }

    public void LoadGameScene() {
        SceneManager.LoadScene("Game");
    }

    public void LoadStartMenu() {
        SceneManager.LoadScene("Start Menu");
    }

    public void QuitGame() {
        Application.Quit();
    }

    private void GameOver() {
        SceneManager.LoadScene("Game Over");
    }
}
