using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : MonoBehaviour
{
    [SerializeField] Material _movable;
    [SerializeField] Material _getable;
    GameManager _manager;
    PieceManager _piece;
    TestLoad _board;
    //前後方向のマスからの移動差
    readonly int[] ZnumVer = new int[] { -2, -2, 2, 2 };
    readonly int[] XnumVer = new int[] { -1, 1, -1, 1 };
    //左右方向のマスからの移動差
    readonly int[] ZnumHor = new int[] { -1, 1, -1, 1 };
    readonly int[] XnumHor = new int[] { -2, -2, 2, 2 };

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
        MovableTile();
        if (_manager.Phase == GameManager.PlayerPhase.White)
        {
            WhiteTurn();
        }
        else if (_manager.Phase == GameManager.PlayerPhase.Black)
        {
            BlackTurn();
        }
    }

    /// <summary> 動けるマスか </summary>
    void MovableTile()
    {
        int x = _piece.TileNumX;
        int z = _piece.TileNumZ;

        for (int i = 0; i < ZnumVer.Length; i++) 
        {
            if ((i <= 1 && z >= 2) || (i > 1 && z <= 5)) //前後(IndexOutofRange防止)
            {
                GetableCheck(x + XnumVer[i], z + ZnumVer[i], 0);
            }
        } 
        for (int i = 0; i < ZnumHor.Length; i++)
        {
            if ((i <= 1 && x >= 2) || (i > 1 && x <= 5)) //左右
            {
                GetableCheck(x + XnumHor[i], z + ZnumHor[i], 0);
            }
        }
    }

    void WhiteTurn()
    {
        int x = _piece.TileNumX;
        int z = _piece.TileNumZ;

        for (int i = 0; i < ZnumVer.Length; i++)
        {
            if ((i <= 1 && z >= 2) || (i > 1 && z <= 5)) //前
            {
                GetableCheck(x - XnumVer[i], z - ZnumVer[i], 1);
            }
        }
        for (int i = 0; i < ZnumHor.Length; i++)
        {
            if ((i <= 1 && x >= 2) || (i > 1 && x <= 5))
            {
                GetableCheck(x - XnumHor[i], z - ZnumHor[i], 1);
            }
        }
    }

    void BlackTurn()
    {
        int x = _piece.TileNumX;
        int z = _piece.TileNumZ;

        for (int i = 0; i < ZnumVer.Length; i++)
        {
            if ((i <= 1 && z >= 2) || (i > 1 && z <= 5))
            {
                GetableCheck(x - XnumVer[i], z - ZnumVer[i], 2);
            }
        }
        for (int i = 0; i < ZnumHor.Length; i++)
        {
            if ((i <= 1 && x >= 2) || (i > 1 && x <= 5))
            {
                GetableCheck(x - XnumHor[i], z - ZnumHor[i], 2);
            }
        }
    }

    void GetableCheck(int x, int z, int phase)
    {
        switch (phase)
        {
            case 0: //マスの探索
                if (_board.BoardInfo[z][x] == 0)
                {
                    _piece.Movable[z, x] = true;
                }
                break;
            case 1: //獲れる駒があるか(白)
                if (_board.BoardInfo[z][x] < 0)
                {
                    GetableRay(x, z);
                }
                break;
            case 2: //獲れる駒があるか(黒)
                if (_board.BoardInfo[z][x] > 0)
                {
                    GetableRay(x, z);
                }
                break;
        }
    }

    void GetableRay(int x, int z)
    {
        //その駒を獲れる状態に切り替える(現時点は色変えるだけ)
        if (Physics.Raycast(new Vector3(x, 5f, -z), Vector3.down, out RaycastHit hit, 20))
        {
            hit.collider.gameObject.GetComponent<MeshRenderer>().material = _getable;
        }
    }
}
