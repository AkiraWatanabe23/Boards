using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bishop : MonoBehaviour
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

    public void Movement()
    {
        //前方向
        int j = _piece.TileNumX; //左前探索用
        int k = _piece.TileNumX; //右前探索用

        for (int i = _piece.TileNumZ; i > 0; i--)
        {
            //左前
            if (MovableLeft(j - 1, i - 1))
            {
                j--;
                continue;
            }
            else
                break;
        }
        for (int i = _piece.TileNumZ; i > 0; i--)
        {
            //右前
            if (MovableRight(k + 1, i - 1))
            {
                k++;
                continue;
            }
            else
                break;
        }

        //後ろ方向
        j = _piece.TileNumX; //左後ろ
        k = _piece.TileNumX; //右後ろ

        for (int i = _piece.TileNumZ; i < 7; i++)
        {
            //左後ろ
            if (MovableLeft(j - 1, i + 1))
            {
                j--;
                continue;
            }
            else
                break;
        }
        for (int i = _piece.TileNumZ; i < 7; i++)
        {
            //右後ろ
            if (MovableRight(k + 1, i + 1))
            {
                k++;
                continue;
            }
            else
                break;
        }
    }

    bool MovableLeft(int x, int z)
    {
        if (x < 0) //IndexOutOfRange 防止
            return false;

        if (_board.BoardInfo[z][x] == 0)
        {
            _piece.Movable[z, x] = true;
            return true;
        }

        //どっちのターンか
        if (_manager.Phase == GameManager.PlayerPhase.White)
        {
            if (_board.BoardInfo[z][x] < 0) //敵駒(獲れる状態に切り替えてから探索終了)
            {
                GetableRay(x, z);
                return false;
            }
            else if (_board.BoardInfo[z][x] > 0) //味方駒(何もせずに探索終了)
                return false;
        }
        else if (_manager.Phase == GameManager.PlayerPhase.Black)
        {
            if (_board.BoardInfo[z][x] > 0)
            {
                GetableRay(x, z);
                return false;
            }
            else if (_board.BoardInfo[z][x] < 0)
                return false;
        }
        return false;
    }
    bool MovableRight(int x, int z)
    {
        if (x > 7)
            return false;

        if (_board.BoardInfo[z][x] == 0)
        {
            _piece.Movable[z, x] = true;
            return true;
        }

        //どっちのターンか
        if (_manager.Phase == GameManager.PlayerPhase.White)
        {
            if (_board.BoardInfo[z][x] < 0)
            {
                GetableRay(x, z);
                return false;
            }
            else if (_board.BoardInfo[z][x] > 0)
                return false;
        }
        else if (_manager.Phase == GameManager.PlayerPhase.Black)
        {
            if (_board.BoardInfo[z][x] > 0)
            {
                GetableRay(x, z);
                return false;
            }
            else if (_board.BoardInfo[z][x] < 0)
                return false;
        }
        return false;
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
