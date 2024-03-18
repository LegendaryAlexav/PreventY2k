using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenApp : MonoBehaviour
{
    public GameObject App;
    public void OnClickIcon()
    {
        App.SetActive(true);

    }

    public void OnClickExitApp()
    {
        App.SetActive(false);
    }
}
