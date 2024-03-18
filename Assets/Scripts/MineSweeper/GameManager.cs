using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform tilePrefab;
    [SerializeField] private Transform gameHolder;

    private List<Tile> tiles = new();

    private int width;
    private int height;
    private int numMines;

    private readonly float tileSize = 0.8f;

    void Start()
    {
        CreateGameBoard(9,9,10); //Easy
        //CreateGameBoard(16, 16, 40); //Intermediate
        //CreateGameBoard(30, 16, 99); //Expert

        ResetGameState();
    }

    public void CreateGameBoard(int width, int height, int numMines)
    {
        this.width = width;
        this.height = height;
        this.numMines = numMines;

        for (int row = 0; row < height; row++)
        {
            for (int col = 0; col < width; col++)
            {
                Transform tileTransform = Instantiate(tilePrefab);
                tileTransform.parent = gameHolder;
                float xIndex = col - ((width - 1) / 2.0f);
                float yIndex = row - ((height - 1) / 2.0f);
                tileTransform.localPosition = new Vector2(xIndex * tileSize, yIndex * tileSize);

                Tile tile = tileTransform.GetComponent<Tile>();
                tiles.Add(tile);
                tile.gameManager = this;
            }
        }
    }

    private void ResetGameState()
    {
        int[] minePositions = Enumerable.Range(0, tiles.Count).OrderBy(x => Random.Range(0.0f, 1.0f)).ToArray();

        for (int i=0; i < numMines; i++)
        {
            int pos = minePositions[i];
            tiles[pos].isMine = true;
        }

        for (int i=0;i < tiles.Count; i++)
        {
            tiles[i].mineCount = HowManyMines(i);
        }
}
    private int HowManyMines(int location)
    {
        int count = 0;
        foreach (int pos in GetNeighbours(location))
        {
            if (tiles[pos].isMine)
            {
                count++;
            }
        }
        return count;
    }

    private List<int> GetNeighbours(int pos) 
    {
        List<int> neighbours = new();
        int row = pos / width;
        int col = pos % width;

        if (row < (height - 1))
        {
            neighbours.Add(pos + width); // North
            if(col > 0)
            {
                neighbours.Add(pos + width - 1); // North-West
            }
            if(col < (width - 1))
            {
                neighbours.Add(pos + width + 1); // North-East
            }
        }
        if (col > 0)
        {
            neighbours.Add(pos - 1); // West
        }
        if (col < (width - 1))
        {
            neighbours.Add(pos + 1); //East
        }
        if (row > 0)
        {
            neighbours.Add(pos - width); // South
            if(col > 0)
            {
                neighbours.Add(pos - width - 1); // South-West
            }
            if (col < (width - 1))
            {
                neighbours.Add(pos - width + 1); // South-East
            }
        }
        return neighbours; 
    }

    public void ClickNeighbours(Tile tile)
    {
        int location = tiles.IndexOf(tile);
        foreach (int pos in GetNeighbours(location))
        {
            tiles[pos].ClickedTile();
        }
    }
    public void GameOver()
    {
        foreach (Tile tile in tiles) 
        {
            tile.ShowGameOverState();
        }
    }

    public void CheckGameOver()
    {
        int count = 0;
        foreach (Tile tile in tiles)
        {

            if (tile.active)
            {
                count++;
            }
        }
        if (count == numMines)
        {
            Debug.Log("Winner!");
            foreach (Tile tile in tiles)
            {
                tile.active = false;
                tile.SetFlaggedIfMine();
            }
        }
    }

    public void ExpandIfFlagged(Tile tile)
    {
        int location = tiles.IndexOf(tile);
        int flag_count = 0;
        foreach (int pos in GetNeighbours(location))
        {
            if (tiles[pos].flagged)
            {
                flag_count++;
            }
        }
        if (flag_count == tile.mineCount)
        {
            ClickNeighbours(tile);
        }
    }

}
