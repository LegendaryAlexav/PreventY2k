using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMS : MonoBehaviour
{
    public GameManager GameManager;

    private void Awake()
    {
        GameManager.FirstReset();
    }
}
