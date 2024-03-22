using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
[RequireComponent(typeof(SpriteRenderer))]
public class TimerNBombs : MonoBehaviour
{
    int numbOfBombs = 57;
    [SerializeField] private List<Sprite> numbers;
    public GameObject Number1;
    public GameObject Number2;
    public GameObject Number3;
    public GameManager GameManager;


    private SpriteRenderer spriteRenderer;
    public bool isTimer = false;
    public bool isCounter = false;
    private float timer = 0.0f;
    public int numberCount = 0;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (isCounter == true)
        {
            Counter();
        }
        if (isTimer == true)
        {
            Timer();
        }
    }
    
    public static int digits(int value, int digit)
    {
        float val = (float)value;
        float v = val /= Mathf.Pow(10, digit-1);
        int i = (int)v;
        digit= i%10;
        return digit;
    }

    private void Counter()
    {
        if (this.gameObject == Number2)
        {
            int digit = 0;
            digits(numbOfBombs, digit);
            spriteRenderer.sprite = numbers[digit];
        }
        else if (this.gameObject == Number3)
        {
            int digit = 2;
            spriteRenderer.sprite = numbers[digit];
        }

    }

    private void Timer()
    {
        int minutes = Mathf.FloorToInt(timer / 60.0f);
        int seconds = Mathf.FloorToInt(timer - minutes * 60);


    }

}
