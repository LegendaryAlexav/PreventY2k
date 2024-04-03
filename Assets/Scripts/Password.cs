using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PasswordHandler : MonoBehaviour
{
    public TMP_InputField messageInput;

    [SerializeField]
    private string password = "PASSWORD";
    public void checkPassword(AudioClip clip) {
        if (messageInput.text == password) {
            PlayAudio(clip);
        } else {
            messageInput.text = "Wrong Password";
        }
    }

    public void checkPassword(GameObject blocker) {
        if (messageInput.text == password) {
            blocker.SetActive(false);
        } else {
            messageInput.text = "Wrong Password";
        }
    }

    private void PlayAudio(AudioClip clip)
    {
        AudioSource audio = FindObjectOfType<AudioSource>();
        audio.clip = clip;
        audio.Play();
    }
}
