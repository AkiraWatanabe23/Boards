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
        //前方向
        for (int i = _piece.TileNumZ; i > 0; i--)
        {
            for (int j = 0; j < _piece.TileNumX; j++)
            {
                if (_board.BoardInfo[i - 1][j + 1] == 0)
                {
                    _board.Tiles[i - 1, j + 1].gameObject.GetComponent<MeshRenderer>().enabled = true;
                }

                //どっちのターンか
                if (_manager.Phase == GameManager.PlayerPhase.White)
                {
                    //駒があれば探索終了
                    //敵駒
                    if (_board.BoardInfo[i - 1][j + 1] < 0)
                    {
                        //その駒を獲れる状態にして探索終了
                        break;
                    }
                    //味方駒(その時点で探索終了)
                    else if (_board.BoardInfo[i - 1][j + 1] > 0)
                        break;
                }
                else if (_manager.Phase == GameManager.PlayerPhase.Black)
                {
                    //駒があれば探索終了
                    //敵駒
                    if (_board.BoardInfo[i - 1][_piece.TileNumX] > 0)
                    {
                        //その駒を獲れる状態にして探索終了
                        break;
                    }
                    //味方駒
                    else if (_board.BoardInfo[i - 1][_piece.TileNumX] < 0)
                        break;
                }
            }

            for (int k = 0; k < _piece.TileNumX; k++)
            {

            }
        }
        //後ろ方向
    }
}
