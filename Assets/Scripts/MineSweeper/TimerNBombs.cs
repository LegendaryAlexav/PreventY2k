using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TimerNBombs : MonoBehaviour
{
    int numbOfBombs = 59;
    [SerializeField] private List<Sprite> numbers;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1)) 
        { 
            numbOfBombs--;
        }
    }


}
