using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MailHandler : MonoBehaviour
{
    private GameObject openMail;

    public void OpenNewMail(GameObject newMail) {
        if(openMail != null) {
            openMail.SetActive(false);
        }
        openMail = newMail;
        openMail.SetActive(true);
    }
}
