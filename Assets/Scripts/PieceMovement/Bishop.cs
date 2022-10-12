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
        //前方向
        int j = _piece.TileNumX; //左前探索用
        int k = _piece.TileNumX; //右前探索用
        for (int i = _piece.TileNumZ; i > 0; i--)
        {
            //左前
            if (_board.BoardInfo[i - 1][j - 1] == 0)
            {
                _piece.Movable[i - 1, j - 1] = true;
                if (j == 1) //IndexOutOfRange 防止
                    break;
            }

            //どっちのターンか
            if (_manager.Phase == GameManager.PlayerPhase.White)
            {
                //駒があれば探索終了
                //敵駒
                if (_board.BoardInfo[i - 1][j - 1] < 0)
                {
                    //その駒を獲れる状態にして探索終了
                    break;
                }
                //味方駒(その時点で探索終了)
                else if (_board.BoardInfo[i - 1][j - 1] > 0)
                    break;
            }
            else if (_manager.Phase == GameManager.PlayerPhase.Black)
            {
                //駒があれば探索終了
                //敵駒
                if (_board.BoardInfo[i - 1][j - 1] > 0)
                {
                    //その駒を獲れる状態にして探索終了
                    break;
                }
                //味方駒
                else if (_board.BoardInfo[i - 1][j - 1] < 0)
                    break;
            }
            j--;
        }
        for (int i = _piece.TileNumZ; i > 0; i--)
        {
            //右前
            if (_board.BoardInfo[i - 1][k + 1] == 0)
            {
                _piece.Movable[i - 1, k + 1] = true;
                if (k == 6)
                    break;
            }

            //どっちのターンか
            if (_manager.Phase == GameManager.PlayerPhase.White)
            {
                //駒があれば探索終了
                //敵駒
                if (_board.BoardInfo[i - 1][k + 1] < 0)
                {
                    //その駒を獲れる状態にして探索終了
                    break;
                }
                //味方駒(その時点で探索終了)
                else if (_board.BoardInfo[i - 1][k + 1] > 0)
                    break;
            }
            else if (_manager.Phase == GameManager.PlayerPhase.Black)
            {
                //駒があれば探索終了
                //敵駒
                if (_board.BoardInfo[i - 1][k + 1] > 0)
                {
                    //その駒を獲れる状態にして探索終了
                    break;
                }
                //味方駒
                else if (_board.BoardInfo[i - 1][k + 1] < 0)
                    break;
            }
            k++;
        }

        //後ろ方向
        j = _piece.TileNumX; //左後ろ
        k = _piece.TileNumX; //右後ろ
        for (int i = _piece.TileNumZ; i < 7; i++)
        {
            //左後ろ
            if (_board.BoardInfo[i + 1][j - 1] == 0)
            {
                _piece.Movable[i + 1, j - 1] = true;
                if (j == 1)
                    break;
            }

            //どっちのターンか
            if (_manager.Phase == GameManager.PlayerPhase.White)
            {
                //駒があれば探索終了
                //敵駒
                if (_board.BoardInfo[i + 1][j - 1] < 0)
                {
                    //その駒を獲れる状態にして探索終了
                    break;
                }
                //味方駒(その時点で探索終了)
                else if (_board.BoardInfo[i + 1][j - 1] > 0)
                    break;
            }
            else if (_manager.Phase == GameManager.PlayerPhase.Black)
            {
                //駒があれば探索終了
                //敵駒
                if (_board.BoardInfo[i + 1][j - 1] > 0)
                {
                    //その駒を獲れる状態にして探索終了
                    break;
                }
                //味方駒
                else if (_board.BoardInfo[i + 1][j - 1] < 0)
                    break;
            }
            j--;
        }
        for (int i = _piece.TileNumZ; i < 7; i++)
        {
            //右後ろ
            if (_board.BoardInfo[i + 1][k + 1] == 0)
            {
                _piece.Movable[i + 1, k + 1] = true;
                if (k == 6)
                    break;
            }

            //どっちのターンか
            if (_manager.Phase == GameManager.PlayerPhase.White)
            {
                //駒があれば探索終了
                //敵駒
                if (_board.BoardInfo[i + 1][k + 1] < 0)
                {
                    //その駒を獲れる状態にして探索終了
                    break;
                }
                //味方駒(その時点で探索終了)
                else if (_board.BoardInfo[i + 1][k + 1] > 0)
                    break;
            }
            else if (_manager.Phase == GameManager.PlayerPhase.Black)
            {
                //駒があれば探索終了
                //敵駒
                if (_board.BoardInfo[i + 1][k + 1] > 0)
                {
                    //その駒を獲れる状態にして探索終了
                    break;
                }
                //味方駒
                else if (_board.BoardInfo[i + 1][k + 1] < 0)
                    break;
            }
            k++;
        }
    }
}
