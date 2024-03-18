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

    private SpriteRenderer spriteRenderer;
    public bool flagged = false;
    public bool active = false;
    public bool isMine = false;
    public int mineCount = 0;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnMouseOver()
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
            }
            else
            {
                spriteRenderer.sprite = unclickedTile;
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
            }
            else
            {
                spriteRenderer.sprite = clickedTiles[mineCount];
            }
        }
    }
}
