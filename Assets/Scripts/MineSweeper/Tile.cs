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
                    Debug.Log("Womp");
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
            Debug.Log("A & NF");
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

}
