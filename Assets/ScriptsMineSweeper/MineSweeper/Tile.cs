using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(SpriteRenderer))]
public class Tile : MonoBehaviour
{
    [Header("Tile Sprites")]
    [SerializeField] private Sprite unclickedTile;
    [SerializeField] private Sprite flaggedTile;
    [SerializeField] private List<Sprite> clickedTiles;
    [SerializeField] private Sprite mineTile;
    [SerializeField] private Sprite mineWrongTile;
    [SerializeField] private Sprite mineHitTile;
    [SerializeField] private Sprite WinFlagged;

    public GameObject WinnerFace;
    public GameObject LoserFace;

    

    [Header("GM set via code")]
    public GameManager gameManager;

    private SpriteRenderer spriteRenderer;
    public bool flagged = false;
    public bool active = true;
    public bool isMine;
    public int mineCount = 0;

    public bool Loser = false;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnMouseOver()
    {
        if (Loser != true)
        {
            
            if (active)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    ClickedTile();
                }
                else if (Input.GetMouseButtonDown(1))
                {
                    flagged = !flagged;
                    if (flagged)
                    {
                        spriteRenderer.sprite = flaggedTile;
                        gameManager.Flagged();
                        if (isMine)
                        {
                            Debug.Log("FLGood");
                            gameManager.GOCounter();
                        }
                        gameManager.CheckGameOver();
                    }

                    else if (!flagged)
                    {
                        spriteRenderer.sprite = unclickedTile;
                        gameManager.UnFlagged();
                        if (isMine)
                        {
                            Debug.Log("FLGood");
                            gameManager.GODown();
                        }
                        gameManager.CheckGameOver();
                    }

                    else
                    {
                        spriteRenderer.sprite = unclickedTile;
                        gameManager.UnFlagged();
                    }
                }

            }
        }
        else
        {
            if (Input.GetMouseButton(0))
            {
                //gameManager.ExpandIfFlagged(this);
            }
        }
        
    }

    public void ClickedTile()
    {
        if(active & !flagged)
        {
            active = false;
            
            if (isMine)
            {
                spriteRenderer.sprite = mineHitTile;
                Debug.Log("Hit!");
                gameManager.LostGame();
                
            }
            else
            {
                spriteRenderer.sprite = clickedTiles[mineCount];
                Debug.Log("Meh");
            }
            if (mineCount == 0)
            {
                //gameManager.ClickNeighbours(this);
            }
            
            //gameManager.CheckGameOver();
        }
    }

    public void ShowGameOverState()
    {
        if (active)
        {
            active = false;
            if (isMine & !flagged)
            {
                spriteRenderer.sprite = mineTile;
            }
            else if (flagged & !isMine)
            {
                spriteRenderer.sprite = mineWrongTile;
            }
        }
    }

    public void SetFlaggedIfMine()
    {
        if (isMine)
        {
            flagged = true;
            spriteRenderer.sprite = flaggedTile;
        }
    }
    
    private void Update()
    {
        if (WinnerFace.activeSelf == true)
        {
            if (flagged & isMine)
            {
                spriteRenderer.sprite = WinFlagged;
            }
            else
            {
                spriteRenderer.sprite = clickedTiles[mineCount];
            }
            
        }
        
        else if (LoserFace.activeSelf == true)
        {
            active = false;
        }
        
        
    }


}
