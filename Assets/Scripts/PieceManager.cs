using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceManager : MonoBehaviour
{
    bool[,] _movable = new bool[8, 8];
    public int PieceNum { get; set; }
    //‘I‘ğ‚µ‚½‹î‚Ìƒ}ƒX”Ô†‚ğæ“¾‚·‚é(X,Z)
    public int TileNumX { get; set; }
    public int TileNumZ { get; set; }
    public bool[,] Movable { get => _movable; set => _movable = value; }

    // Start is called before the first frame update
    void Start()
    {
        PieceNum = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    //‹î‚ÌŒÂ•ÊˆÚ“®ˆ—‚Ö‚Ì‘JˆÚ
    public void PieceMovement()
    {
        switch (Mathf.Abs(PieceNum))
        {
            case 1:
                Debug.Log("Pawn");
                break;
            case 2:
                Debug.Log("Knight");
                break;
            case 3:
                Debug.Log("Bishop");
                break;
            case 4:
                Debug.Log("Rook");
                GameObject.Find("Board").GetComponent<Rook>().Movement();
                break;
            case 5:
                Debug.Log("Queen");
                break;
            case 6:
                Debug.Log("King");
                break;
        }
    }
}
