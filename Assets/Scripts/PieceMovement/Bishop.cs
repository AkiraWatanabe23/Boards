using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bishop : MonoBehaviour
{
    [SerializeField] Material _movable;
    GameManager _manager;
    PieceManager _piece;
    TestLoad _board;

    // Start is called before the first frame update
    void Start()
    {
        _manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _piece = GameObject.Find("Piece").GetComponent<PieceManager>();
        _board = GameObject.Find("Board").GetComponent<TestLoad>();
    }

    public void Movement()
    {
        //‘O•ûŒü
        for (int i = _piece.TileNumZ; i > 0; i--)
        {
            for (int j = 0; j < _piece.TileNumX; j++)
            {
                if (_board.BoardInfo[i - 1][j + 1] == 0)
                {
                    _board.Tiles[i - 1, j + 1].gameObject.GetComponent<MeshRenderer>().enabled = true;
                }

                //‚Ç‚Á‚¿‚Ìƒ^[ƒ“‚©
                if (_manager.Phase == GameManager.PlayerPhase.White)
                {
                    //‹î‚ª‚ ‚ê‚Î’TõI—¹
                    //“G‹î
                    if (_board.BoardInfo[i - 1][j + 1] < 0)
                    {
                        //‚»‚Ì‹î‚ğŠl‚ê‚éó‘Ô‚É‚µ‚Ä’TõI—¹
                        break;
                    }
                    //–¡•û‹î(‚»‚Ì“_‚Å’TõI—¹)
                    else if (_board.BoardInfo[i - 1][j + 1] > 0)
                        break;
                }
                else if (_manager.Phase == GameManager.PlayerPhase.Black)
                {
                    //‹î‚ª‚ ‚ê‚Î’TõI—¹
                    //“G‹î
                    if (_board.BoardInfo[i - 1][_piece.TileNumX] > 0)
                    {
                        //‚»‚Ì‹î‚ğŠl‚ê‚éó‘Ô‚É‚µ‚Ä’TõI—¹
                        break;
                    }
                    //–¡•û‹î
                    else if (_board.BoardInfo[i - 1][_piece.TileNumX] < 0)
                        break;
                }
            }

            for (int k = 0; k < _piece.TileNumX; k++)
            {

            }
        }
        //Œã‚ë•ûŒü
    }
}
