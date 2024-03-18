using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenApp : MonoBehaviour
{
    public GameObject MineSweeper;
    public void OnClickMineSweeper()
    {
        MineSweeper.SetActive(true);

    }

    public void OnClickExitMS()
    {
        MineSweeper.SetActive(false);
    }
}
