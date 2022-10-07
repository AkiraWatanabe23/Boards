using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ルークの移動探索
/// </summary>
public class Rook : MonoBehaviour
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

    /// <summary> 
    /// 前後左右の探索
    /// (やっていることは全方向で同じだけど、いる位置によって探索範囲が異なるため、各方向で探索を分ける)
    /// </summary>
    public void Movement()
    {
        //前後方向
        for (int i = _piece.TileNumZ; i > 0; i--)
        {
            //マスが空いていたら動ける
            if (_board.BoardInfo[i - 1][_piece.TileNumX] == 0)
            {
                _board.Tiles[i - 1, _piece.TileNumX].gameObject.GetComponent<MeshRenderer>().enabled = true;
            }

            //どっちのターンか
            if (_manager.Phase == GameManager.PlayerPhase.White)
            {
                //駒があれば探索終了
                //敵駒
                if (_board.BoardInfo[i - 1][_piece.TileNumX] < 0)
                {
                    //その駒を獲れる状態にして探索終了
                    break;
                }
                //味方駒(その時点で探索終了)
                else if (_board.BoardInfo[i - 1][_piece.TileNumX] > 0)
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

        for (int i = _piece.TileNumZ; i < 7; i++)
        {
            if (_board.BoardInfo[i + 1][_piece.TileNumX] == 0)
            {
                _board.Tiles[i + 1, _piece.TileNumX].gameObject.GetComponent<MeshRenderer>().enabled = true;
            }

            if (_manager.Phase == GameManager.PlayerPhase.White)
            {
                //駒があれば探索終了
                if (_board.BoardInfo[i + 1][_piece.TileNumX] < 0)
                {
                    break;
                }
                else if (_board.BoardInfo[i + 1][_piece.TileNumX] > 0)
                    break;
            }
            else if (_manager.Phase == GameManager.PlayerPhase.Black)
            {
                if (_board.BoardInfo[i + 1][_piece.TileNumX] > 0)
                {
                    break;
                }
                else if (_board.BoardInfo[i + 1][_piece.TileNumX] < 0)
                    break;
            }
        }
        //左右方向
        for (int i = _piece.TileNumX; i < 7; i++)
        {
            if (_board.BoardInfo[_piece.TileNumZ][i + 1] == 0)
            {
                _board.Tiles[_piece.TileNumZ, i + 1].gameObject.GetComponent<MeshRenderer>().enabled = true;
            }

            if (_manager.Phase == GameManager.PlayerPhase.White)
            {
                if (_board.BoardInfo[_piece.TileNumZ][i + 1] < 0)
                {
                    break;
                }
                else if (_board.BoardInfo[_piece.TileNumZ][i + 1] > 0)
                    break;
            }
            else if (_manager.Phase == GameManager.PlayerPhase.Black)
            {
                if (_board.BoardInfo[_piece.TileNumZ][i + 1] > 0)
                {
                    break;
                }
                else if (_board.BoardInfo[_piece.TileNumZ][i + 1] < 0)
                    break;
            }
        }

        for (int i = _piece.TileNumX; i > 0; i--)
        {
            if (_board.BoardInfo[_piece.TileNumZ][i - 1] == 0)
            {
                _board.Tiles[_piece.TileNumZ, i - 1].gameObject.GetComponent<MeshRenderer>().enabled = true;
            }

            if (_manager.Phase == GameManager.PlayerPhase.White)
            {
                if (_board.BoardInfo[_piece.TileNumZ][i-1] < 0)
                {
                    break;
                }
                else if (_board.BoardInfo[_piece.TileNumZ][i - 1] > 0)
                    break;
            }
            else if (_manager.Phase == GameManager.PlayerPhase.Black)
            {
                if (_board.BoardInfo[_piece.TileNumZ][i-1] > 0)
                {
                    break;
                }
                else if (_board.BoardInfo[_piece.TileNumZ][i - 1] < 0)
                    break;
            }
        }
    }
}
