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
    int[] ZnumVer = new int[] { -2, -2, 2, 2 };
    int[] XnumVer = new int[] { -1, 1, -1, 1 };
    //左右方向のマスからの移動差
    int[] ZnumHor = new int[] { -1, -1, 1, 1 };
    int[] XnumHor = new int[] { -2, 2, -2, 2 };

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
                    _board.Tiles[i, j].gameObject.GetComponent<MeshRenderer>().enabled = true;
                }
                else
                {
                    _board.Tiles[i, j].gameObject.GetComponent<MeshRenderer>().enabled = false;
                }
            }
        }
    }

    public void Movement()
    {
        MovableTile();
        //どっちのターンか
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

        //前後
        for (int i = 0; i < ZnumVer.Length; i++) 
        {
            if (_board.BoardInfo[z + ZnumVer[i]][x + XnumVer[i]] == 0)
            {
                _piece.Movable[z + ZnumVer[i], x + XnumVer[i]] = true;
            }
        } 
        //左右
        for (int i = 0; i < ZnumHor.Length; i++)
        {
            if (_board.BoardInfo[z + ZnumHor[i]][x + XnumHor[i]] == 0)
            {
                _piece.Movable[z + ZnumHor[i], x + XnumHor[i]] = true;
            }
        }
    }

    void WhiteTurn()
    {
        RaycastHit hit;
        int x = _piece.TileNumX;
        int z = _piece.TileNumZ;

        //駒があれば探索終了
        for (int i = 0; i < ZnumVer.Length; i++)
        {
            if (_board.BoardInfo[z - ZnumVer[i]][x - XnumVer[i]] < 0)
            {
                //敵駒
                //そのマスにRay飛ばして駒の色変える?
                if (Physics.Raycast(new Vector3(x - XnumVer[i], 5f, -(z - ZnumVer[i])), Vector3.down, out hit, 20))
                {
                    hit.collider.gameObject.GetComponent<MeshRenderer>().material = _getable;
                }
            }
            else if (_board.BoardInfo[z - ZnumVer[i]][x - XnumVer[i]] > 0)
            {
                //味方駒
            }
        }
        //左右
        for (int i = 0; i < ZnumHor.Length; i++)
        {
            if (_board.BoardInfo[z - ZnumHor[i]][x - XnumHor[i]] < 0)
            {
                //敵駒
                //そのマスにRay飛ばして駒の色変える?
                if (Physics.Raycast(new Vector3(x - XnumHor[i], 5f, -(z - ZnumHor[i])), Vector3.down, out hit, 20))
                {
                    hit.collider.gameObject.GetComponent<MeshRenderer>().material = _getable;
                }
            }
            else if (_board.BoardInfo[z - ZnumHor[i]][x - XnumHor[i]] > 0)
            {
                //味方駒
            }
        }
    }

    void BlackTurn()
    {
        RaycastHit hit;
        int x = _piece.TileNumX;
        int z = _piece.TileNumZ;

        for (int i = 0; i < ZnumVer.Length; i++)
        {
            if (_board.BoardInfo[z - ZnumVer[i]][x - XnumVer[i]] > 0)
            {
                //敵駒
                //そのマスにRay飛ばして駒の色変える?
                if (Physics.Raycast(new Vector3(x - XnumVer[i], 5f, -(z - ZnumVer[i])), Vector3.down, out hit, 20))
                {
                    hit.collider.gameObject.GetComponent<MeshRenderer>().material = _getable;
                }
            }
            else if (_board.BoardInfo[z - ZnumVer[i]][x - XnumVer[i]] < 0)
            {
                //味方駒
            }
        }
        for (int i = 0; i < ZnumHor.Length; i++)
        {
            if (_board.BoardInfo[z - ZnumHor[i]][x - XnumHor[i]] > 0)
            {
                //敵駒
                //そのマスにRay飛ばして駒の色変える?
                if (Physics.Raycast(new Vector3(x - XnumHor[i], 5f, -(z - ZnumHor[i])), Vector3.down, out hit, 20))
                {
                    hit.collider.gameObject.GetComponent<MeshRenderer>().material = _getable;
                }
            }
            else if (_board.BoardInfo[z - ZnumHor[i]][x - XnumHor[i]] < 0)
            {
                //味方駒
            }
        }
    }
}
