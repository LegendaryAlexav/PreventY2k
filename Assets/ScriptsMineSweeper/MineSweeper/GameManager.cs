using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
[RequireComponent(typeof(SpriteRenderer))]
public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform tilePrefab;
    [SerializeField] private Transform gameHolder;

    private List<Tile> tiles = new();

    private SpriteRenderer spriteRenderer;

    public TimerNBombs Num1;
    public TimerNBombs Num2;
    public TimerNBombs Num3;

    public GameObject Face;
    public GameObject LoserFace;
    public GameObject WinnerFace;

    public GameObject MSGameHolder;
    private GameObject newInstance;
    public GameObject StarterHolder;

    private int numMines = 60;
    private int correctlyFlagged = 0;

    //private readonly float tileSize = 0.8f;

    private GameObject[] TileParent;
     
    public void ResetGame()
    {

        Destroy(newInstance);
        newInstance = Instantiate(MSGameHolder);
        newInstance.gameObject.SetActive(true);
        StarterHolder.gameObject.SetActive(false);
        Num1 = Num2;
        numMines = 60;
        LoserFace.gameObject.SetActive(false);
        Face.gameObject.SetActive(true);
        WinnerFace.gameObject.SetActive(false);

    }
    public void CloseApp()
    {
        if (newInstance != null)
        {
            newInstance.SetActive(false);
        }
    }
    public void OpenApp()
    {
        Destroy(newInstance);
        newInstance = Instantiate(MSGameHolder);
        newInstance.gameObject.SetActive(true);
        StarterHolder.SetActive(false);
        LoserFace.gameObject.SetActive(false);
        Face.gameObject.SetActive(true);
        WinnerFace.gameObject.SetActive(false);
    }
    public void Flagged()
    {
        numMines--;
        Num1.BombDown();
        
    }
    public void UnFlagged()
    {
        numMines++;
        Num1.BombUp();
        
    }
    public void LostGame()
    {
        Debug.Log("Lost");
        LoserFace.gameObject.SetActive(true);
        Face.gameObject.SetActive(false);
        WinnerFace.gameObject.SetActive(false);
    }
    public void GOCounter()
    {
        correctlyFlagged++;
        Debug.Log("GoodFlagged" + correctlyFlagged);
    }
    public void GODown()
    {
            correctlyFlagged--;
        Debug.Log("ByeByeGoodFlagged" + correctlyFlagged);
    }

    public void CheckGameOver()
    {
        if (correctlyFlagged == 60)
        {
            Debug.Log("Winner!");
            WinnerFace.gameObject.SetActive(true);
            Face.gameObject.SetActive(false);
            LoserFace.gameObject.SetActive(false);

        }
    }
    

}
