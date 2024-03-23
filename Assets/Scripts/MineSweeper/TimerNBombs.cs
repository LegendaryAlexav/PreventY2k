using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
[RequireComponent(typeof(SpriteRenderer))]
public class TimerNBombs : MonoBehaviour
{
    public int numbOfBombs = 60;
    [SerializeField] private List<Sprite> numbers;
    public GameObject Number1;
    public GameObject Number2;
    public GameObject Number3;
    public GameManager GameManager;

    private bool timerActivate = false;
    private float currentTime = 0;

    private SpriteRenderer spriteRenderer;
    public bool isTimer = false;
    public bool isCounter = false;

    public int numberCount = 0;
    public int digit = 0;
    public int secdigit = 6;
    private int second = 0;
    private int tensecond = 0;
    private int hundredsecond = 0;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (timerActivate == true)
        {
            currentTime = currentTime + Time.deltaTime;
            second = (int)currentTime;
            if (second > 9)
            {
                second = 0;
                currentTime = 0;
                tensecond++;
            }
            
            
            if (tensecond > 9)
            {
                tensecond = 0;
                hundredsecond++;
            }
            TimerToDig();
        }

    }

    private void Start()
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

    private void Counter()
    {
        if (numbOfBombs >= 0)
        {
            spriteRenderer = Number2.gameObject.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = numbers[secdigit];

            spriteRenderer = Number3.gameObject.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = numbers[digit];

        }

    }



    public void BombUp()
    {
        numbOfBombs++;
        if (digit == 9)
        {
            digit = 0;
            secdigit++;
            Debug.Log("Over9");
        }
        else if (digit != 9) { digit++; }
        Counter();
        Debug.Log(numbOfBombs);


    }

    public void BombDown()
    {
        numbOfBombs--;
        if (numbOfBombs >= 0)
        {
            if (digit == 0)
            {
                digit = 9;
                secdigit--;
                Debug.Log("Under0");
            }
            else if (digit != 0) { digit--; }

            Counter();
            Debug.Log(numbOfBombs);
        }
        else if (numbOfBombs <= 0) { numbOfBombs = 0; Debug.Log("NoMoreBombs"); }
    }


    private void Timer()
    {


        timerActivate = true;


    }
    private void TimerToDig()
    {
        spriteRenderer = Number1.gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = numbers[hundredsecond];

        spriteRenderer = Number2.gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = numbers[tensecond];

        spriteRenderer = Number3.gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = numbers[second];

    }
}
