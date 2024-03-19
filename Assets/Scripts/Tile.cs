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

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //ClickedTiles(); Error, Method does not exist
        }
    }

}
