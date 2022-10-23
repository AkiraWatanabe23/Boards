using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ルークの移動探索
/// </summary>
public class Rook : MonoBehaviour
{
    [SerializeField] Material _movable;
    [SerializeField] Material _getable;
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
    /// 探索範囲の描画
    /// </summary>
    void Update()
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (_piece.Movable[i, j] == true)
                {
                    _board.Tiles[i, j].GetComponent<MeshRenderer>().enabled = true;
                }
                else
                {
                    _board.Tiles[i, j].GetComponent<MeshRenderer>().enabled = false;
                }
            }
        }
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
                _piece.Movable[i - 1, _piece.TileNumX] = true;
            }

            //どっちのターンか
            if (_manager.Phase == GameManager.PlayerPhase.White)
            {
                if (_board.BoardInfo[i - 1][_piece.TileNumX] < 0) //敵駒(獲れる状態に切り替えてから探索終了)
                {
                    GetableRay(_piece.TileNumX, i - 1);
                    break;
                }
                else if (_board.BoardInfo[i - 1][_piece.TileNumX] > 0) //味方駒(何もせずに探索終了)
                    break;
            }
            else if (_manager.Phase == GameManager.PlayerPhase.Black)
            {
                if (_board.BoardInfo[i - 1][_piece.TileNumX] > 0)
                {
                    GetableRay(_piece.TileNumX, i - 1);
                    break;
                }
                else if (_board.BoardInfo[i - 1][_piece.TileNumX] < 0)
                    break;
            }
        }

        for (int i = _piece.TileNumZ; i < 7; i++)
        {
            if (_board.BoardInfo[i + 1][_piece.TileNumX] == 0)
            {
                _piece.Movable[i + 1, _piece.TileNumX] = true;
            }

            if (_manager.Phase == GameManager.PlayerPhase.White)
            {
                if (_board.BoardInfo[i + 1][_piece.TileNumX] < 0)
                {
                    GetableRay(_piece.TileNumX, i + 1);
                    break;
                }
                else if (_board.BoardInfo[i + 1][_piece.TileNumX] > 0)
                    break;
            }
            else if (_manager.Phase == GameManager.PlayerPhase.Black)
            {
                if (_board.BoardInfo[i + 1][_piece.TileNumX] > 0)
                {
                    GetableRay(_piece.TileNumX, i + 1);
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
                _piece.Movable[_piece.TileNumZ, i + 1] = true;
            }

            if (_manager.Phase == GameManager.PlayerPhase.White)
            {
                if (_board.BoardInfo[_piece.TileNumZ][i + 1] < 0)
                {
                    GetableRay(i + 1, _piece.TileNumZ);
                    break;
                }
                else if (_board.BoardInfo[_piece.TileNumZ][i + 1] > 0)
                    break;
            }
            else if (_manager.Phase == GameManager.PlayerPhase.Black)
            {
                if (_board.BoardInfo[_piece.TileNumZ][i + 1] > 0)
                {
                    GetableRay(i + 1, _piece.TileNumZ);
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
                _piece.Movable[_piece.TileNumZ, i - 1] = true;
            }

            if (_manager.Phase == GameManager.PlayerPhase.White)
            {
                if (_board.BoardInfo[_piece.TileNumZ][i - 1] < 0)
                {
                    GetableRay(i - 1, _piece.TileNumZ);
                    break;
                }
                else if (_board.BoardInfo[_piece.TileNumZ][i - 1] > 0)
                    break;
            }
            else if (_manager.Phase == GameManager.PlayerPhase.Black)
            {
                if (_board.BoardInfo[_piece.TileNumZ][i - 1] > 0)
                {
                    GetableRay(i - 1, _piece.TileNumZ);
                    break;
                }
                else if (_board.BoardInfo[_piece.TileNumZ][i - 1] < 0)
                    break;
            }
        }
    }

    void GetableRay(int x, int z)
    {
        //その駒を獲れる状態に切り替える
        if (Physics.Raycast(new Vector3(x, 5f, -z), Vector3.down, out RaycastHit hit, 20))
        {
            hit.collider.gameObject.GetComponent<MeshRenderer>().material = _getable;
        }
    }
}
