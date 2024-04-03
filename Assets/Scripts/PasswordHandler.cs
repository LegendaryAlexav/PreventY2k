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
    public void checkPassword(int sceneId) {
        if (messageInput.text == password) {
            SceneManager.LoadScene(sceneId);
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
}
