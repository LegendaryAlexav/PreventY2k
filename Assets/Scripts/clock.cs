using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(AudioSource))]
public class clock : MonoBehaviour
{   
    //time is set to 1800 for 30 minutes
    public float timeValue = 1800;
    public Text timerText;

    //both are temp debug bools
    public bool gameOver; 
    public bool lossStart;

    public AudioClip clip;

    void Update()
    {
        //ads time based from the frame rate (incase game or computer framerate is diffrent)
        timeValue += Time.deltaTime; 
        
        //verify if time is above limit
        if(timeValue<3600)
        {
            DisplayTime(timeValue);
            
            if (timeValue > 3504)
            {
                if (timeValue < 3505) {
                    Debug.Log("AudioGonnaStart");
                PlayAudio();
                    lossStart = true;
                    Debug.Log("AudioWorks");
                }
                

            }
            

        }
        else
        {
        timerText.text = string.Format("00:00:00 AM");
        //change gameover to start losing game loop
        
        //debug line
        gameOver = true;

        //add crash effects here
        Debug.Log("So Long Gay Bowser");
        Application.Quit();
            
        }

    }

    private void PlayAudio()
    {
        
         AudioSource audio = FindObjectOfType<AudioSource>();
                audio.clip = clip;
                audio.Play();
                Debug.Log("EndingAudioStarts");
    }


    void DisplayTime(float timeToDisplay)
    {
        //calculates seconds and minutes
        //float hours = Mathf.FloorToInt(timeToDisplay / 3600);
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        //will dissplay time 
        timerText.text = string.Format("11:{0:00}:{1:00} PM", minutes, seconds);



    }
}