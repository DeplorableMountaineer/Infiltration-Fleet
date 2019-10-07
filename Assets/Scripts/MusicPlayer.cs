using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {

    [SerializeField] private AudioClip[] playList;

    private double nextClipTime = 0;
    private AudioSource[] audioSources;
    private int currentAudioSource = 0;
    private int currentClip = 0;
    private double clipDuration = 0.5;

    void Awake() {
        if(FindObjectsOfType<MusicPlayer>().Length > 1) {
            gameObject.SetActive(false);
            Destroy(gameObject);
        } else {
            DontDestroyOnLoad(gameObject);
            audioSources = GetComponents<AudioSource>();
        }
    }

    private IEnumerator Start() {
        float delay;
        while(true) {
            delay = 0;
            while(delay < 1) {
                delay += PlayNextClip();
            }
            yield return new WaitForSeconds(delay - 1);
        }
    }

    private float PlayNextClip() {
        if(nextClipTime <= 0) {
            nextClipTime = AudioSettings.dspTime;
        }
        nextClipTime += clipDuration;
        clipDuration = (double)(playList[currentClip].samples) / playList[currentClip].frequency;
        audioSources[currentAudioSource].clip = playList[currentClip];
        audioSources[currentAudioSource].PlayScheduled(nextClipTime);
        currentClip = (currentClip + 1) % playList.Length;
        currentAudioSource = (currentAudioSource + 1) % audioSources.Length;
        return (float)(nextClipTime - AudioSettings.dspTime + clipDuration);
    }
}

