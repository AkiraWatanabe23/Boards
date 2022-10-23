using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : MonoBehaviour
{
    [SerializeField] Material _movable;
    [SerializeField] Material _getable;
    GameManager _manager;
    PieceManager _piece;
    TestLoad _board;
    //前後左右方向のマスからの移動差
    int[] ZnumVer = new int[] { -1, 1 };
    int[] XnumVer = new int[] { -1, 1 };
    int[] ZnumHor = new int[] { -1, 1 };
    int[] XnumHor = new int[] { -1, 1, -1, 1 };

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
        //前後
        for (int i = 0; i < ZnumVer.Length; i++)
        {
            if ((i == 0 && _piece.TileNumZ != 0) || (i == 1 && _piece.TileNumZ != 7)) //IndexOutOfRange防止
            {
                GetableCheck(_piece.TileNumX, _piece.TileNumZ + ZnumVer[i], 0);

                //どっちのターンか
                if (_manager.Phase == GameManager.PlayerPhase.White)
                {
                    GetableCheck(_piece.TileNumX, _piece.TileNumZ + ZnumVer[i], 1);
                }
                else if (_manager.Phase == GameManager.PlayerPhase.Black)
                {
                    GetableCheck(_piece.TileNumX, _piece.TileNumZ + ZnumVer[i], 2);
                }
            }
        }
        //左右
        for (int i = 0; i < XnumVer.Length; i++)
        {
            if ((i == 0 && _piece.TileNumX != 0) || (i == 1 && _piece.TileNumX != 7))
            {
                GetableCheck(_piece.TileNumX + XnumVer[i], _piece.TileNumZ, 0);

                //どっちのターンか
                if (_manager.Phase == GameManager.PlayerPhase.White)
                {
                    GetableCheck(_piece.TileNumX + XnumVer[i], _piece.TileNumZ, 1);
                }
                else if (_manager.Phase == GameManager.PlayerPhase.Black)
                {
                    GetableCheck(_piece.TileNumX + XnumVer[i], _piece.TileNumZ, 2);
                }
            }
        }
        //斜め
        for (int i = 0; i < XnumHor.Length; i++)
        {
            if (i <= 1) //前
            {
                if ((i == 0 && _piece.TileNumX != 0 && _piece.TileNumZ != 0) ||
                    (i == 1 && _piece.TileNumX != 7 && _piece.TileNumZ != 0))
                {
                    GetableCheck(_piece.TileNumX + XnumHor[i], _piece.TileNumZ + ZnumHor[0], 0);

                    //どっちのターンか
                    if (_manager.Phase == GameManager.PlayerPhase.White)
                    {
                        GetableCheck(_piece.TileNumX + XnumHor[i], _piece.TileNumZ + ZnumHor[0], 1);
                    }
                    else if (_manager.Phase == GameManager.PlayerPhase.Black)
                    {
                        GetableCheck(_piece.TileNumX + XnumHor[i], _piece.TileNumZ + ZnumHor[0], 2);
                    }
                }
            }
            else //後ろ
            {
                if ((i == 2 && _piece.TileNumX != 0 && _piece.TileNumZ != 7) ||
                    (i == 3 && _piece.TileNumX != 7 && _piece.TileNumZ != 7))
                {
                    GetableCheck(_piece.TileNumX + XnumHor[i], _piece.TileNumZ + ZnumHor[1], 0);

                    //どっちのターンか
                    if (_manager.Phase == GameManager.PlayerPhase.White)
                    {
                        GetableCheck(_piece.TileNumX + XnumHor[i], _piece.TileNumZ + ZnumHor[1], 1);
                    }
                    else if (_manager.Phase == GameManager.PlayerPhase.Black)
                    {
                        GetableCheck(_piece.TileNumX + XnumHor[i], _piece.TileNumZ + ZnumHor[1], 2);
                    }
                }
            }
        }
    }

    void GetableCheck(int x, int z, int phase)
    {
        if (phase == 0) //マスの探索
        {
            if (_board.BoardInfo[z][x] == 0)
            {
                _piece.Movable[z, x] = true;
            }
        }
        else if (phase == 1) //獲れる駒があるか(白)
        {
            if (_board.BoardInfo[z][x] < 0)
            {
                GetableRay(x, z);
            }
        }
        else if (phase == 2) //獲れる駒があるか(黒)
        {
            if (_board.BoardInfo[z][x] > 0)
            {
                GetableRay(x, z);
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
