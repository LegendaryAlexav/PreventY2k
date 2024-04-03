using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class MusicManager : MonoBehaviour
{

    private AudioSource audioSource;

    public AudioClip[] musicList = new AudioClip[4];

    public TMP_Text musicTitle;

    private int trackCount = 0;

    private int PauseState = 0;

    public void nextSong() {

        trackCount++;

        if (trackCount > 3) {
            trackCount = 0;
        }

        musicTitle.text =  audioSource.clip.name;

        audioSource.Pause();
        audioSource.clip = musicList[trackCount];
        audioSource.Play();

    }

    public void previousSong() {

        trackCount--;

        if (trackCount < 0) {
            trackCount = 3;
        }

        musicTitle.text = audioSource.clip.ToString();

        audioSource.Pause();
        audioSource.clip = musicList[trackCount];
        audioSource.Play();
    }

    public void pauseSong() {
        
        if (PauseState == 0) {

            audioSource.Pause();
            PauseState++;

        } else if (PauseState == 1) {

            audioSource.Play();
            PauseState--;

        }
    }


    void Start() {

        audioSource = FindObjectOfType<AudioSource>();
        audioSource.loop = false;

        if (!audioSource.isPlaying) {
            audioSource.clip = musicList[trackCount];
            musicTitle.text = audioSource.clip.name;
            audioSource.Play();
        }

    }

}
