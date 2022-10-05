using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rook : MonoBehaviour
{
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
        //前方向
        for (int i = _piece.TileNumZ; i > 0; i--)
        {
            if (_manager.Phase == GameManager.PlayerPhase.White)
            {
                if (_board.BoardInfo[i-1][_piece.TileNumX] <= 0)
                {
                    Debug.Log("このマスには進めます White 前");
                }
                else
                    break;
            }
            else if (_manager.Phase == GameManager.PlayerPhase.Black)
            {
                if (_board.BoardInfo[i-1][_piece.TileNumX] >= 0)
                {
                    Debug.Log("このマスには進めます Black 後ろ");
                }
                else
                    break;
            }
        }
        //後ろ方向
        for (int i = _piece.TileNumZ; i < 7; i++)
        {
            if (_manager.Phase == GameManager.PlayerPhase.White)
            {
                if (_board.BoardInfo[i+1][_piece.TileNumX] <= 0)
                {
                    Debug.Log("このマスには進めます White　後ろ");
                }
                else
                    break;
            }
            else if (_manager.Phase == GameManager.PlayerPhase.Black)
            {
                if (_board.BoardInfo[i+1][_piece.TileNumX] >= 0)
                {
                    Debug.Log("このマスには進めます Black 後ろ");
                }
                else
                    break;
            }
        }
        //右方向
        for (int i = 0; i < 7 - _piece.TileNumX; i++)
        {

        }
        //左方向
        for (int i = 0; i < _piece.TileNumX; i++)
        {

        }
    }
}
