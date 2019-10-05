using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour {
    private float score = 0;
    private TextMeshProUGUI scoreText = null;

    public void UpdateScore(float increment = 0) {
        score += increment;
        if(!scoreText) {
            foreach(TextMeshProUGUI st in FindObjectsOfType<TextMeshProUGUI>()) {
                if(st.tag == "Score Text") {
                    scoreText = st;
                    break;
                }
            }
        }

        if(scoreText) {
            scoreText.text = Mathf.RoundToInt(score).ToString();
        }
    }

    public void ResetScore(float value = 0) {
        score = 0;
        UpdateScore();
    }

}
