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
    
    

    private SpriteRenderer spriteRenderer;
    public bool isTimer = false;
    public bool isCounter = false;
    private float timer = 0.0f;
    public int numberCount = 0;
    public int digit = 0;
    public int secdigit = 6;
    private int lastdigit = 0;
    private int lastsecdigit = 0;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {

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
            lastdigit = digit;
            digit = 0;
            lastsecdigit = secdigit;
            secdigit++;
            Debug.Log("Over9");
        }
        else if (digit != 9){ digit++; }
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
        else if (numbOfBombs <= 0){ numbOfBombs = 0; Debug.Log("NoMoreBombs"); }
    }


    private void Timer()
    {
        int minutes = Mathf.FloorToInt(timer / 60.0f);
        int seconds = Mathf.FloorToInt(timer - minutes * 60);


    }

}
