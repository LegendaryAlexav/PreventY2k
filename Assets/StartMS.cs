using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMS : MonoBehaviour
{
    public GameManager gameManager;
    private void Awake()
    {
        gameManager.FirstReset();
    }
}
