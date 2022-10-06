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

    public void Movement()
    {
        //前後方向
        for (int i = _piece.TileNumZ; i > 0; i--)
        {
            if (_manager.Phase == GameManager.PlayerPhase.White)
            {
                if (_board.BoardInfo[i-1][_piece.TileNumX] <= 0)
                {
                    if (_board.BoardInfo[i-1][_piece.TileNumX] == 0)
                    {
                        _board.Tiles[i-1, _piece.TileNumX].gameObject.GetComponent<MeshRenderer>().enabled = true;
                    }
                    else if (_board.BoardInfo[i-1][_piece.TileNumX] < 0)
                        break;
                }
                else
                    break;
            }
            else if (_manager.Phase == GameManager.PlayerPhase.Black)
            {
                if (_board.BoardInfo[i-1][_piece.TileNumX] >= 0)
                {
                    if (_board.BoardInfo[i-1][_piece.TileNumX] == 0)
                    {
                        _board.Tiles[i-1, _piece.TileNumX].gameObject.GetComponent<MeshRenderer>().enabled = true;
                    }
                    else if (_board.BoardInfo[i-1][_piece.TileNumX] > 0)
                        break;
                }
                else
                    break;
            }
        }

        for (int i = _piece.TileNumZ; i < 7; i++)
        {
            if (_manager.Phase == GameManager.PlayerPhase.White)
            {
                if (_board.BoardInfo[i+1][_piece.TileNumX] <= 0)
                {
                    if (_board.BoardInfo[i+1][_piece.TileNumX] == 0)
                    {
                        _board.Tiles[i+1, _piece.TileNumX].gameObject.GetComponent<MeshRenderer>().enabled = true;
                    }
                    else if (_board.BoardInfo[i+1][_piece.TileNumX] < 0)
                        break;
                }
                else
                    break;
            }
            else if (_manager.Phase == GameManager.PlayerPhase.Black)
            {
                if (_board.BoardInfo[i+1][_piece.TileNumX] >= 0)
                {
                    if (_board.BoardInfo[i+1][_piece.TileNumX] == 0)
                    {
                        _board.Tiles[i+1, _piece.TileNumX].gameObject.GetComponent<MeshRenderer>().enabled = true;
                    }
                    else if (_board.BoardInfo[i+1][_piece.TileNumX] > 0)
                        break;
                }
                else
                    break;
            }
        }
        //左右方向
        for (int i = _piece.TileNumX; i < 7; i++)
        {
            if (_manager.Phase == GameManager.PlayerPhase.White)
            {
                if (_board.BoardInfo[_piece.TileNumZ][i+1] <= 0)
                {
                    if (_board.BoardInfo[_piece.TileNumZ][i+1] == 0)
                    {
                        _board.Tiles[_piece.TileNumZ, i+1].gameObject.GetComponent<MeshRenderer>().enabled = true;
                    }
                    else if (_board.BoardInfo[_piece.TileNumZ][i+1] < 0)
                        break;
                }
                else
                    break;
            }
            else if (_manager.Phase == GameManager.PlayerPhase.Black)
            {
                if (_board.BoardInfo[_piece.TileNumZ][i+1] >= 0)
                {
                    if (_board.BoardInfo[_piece.TileNumZ][i+1] == 0)
                    {
                        _board.Tiles[_piece.TileNumZ, i+1].gameObject.GetComponent<MeshRenderer>().enabled = true;
                    }
                    else if (_board.BoardInfo[_piece.TileNumZ][i+1] > 0)
                        break;
                }
                else
                    break;
            }
        }

        for (int i = _piece.TileNumX; i > 0; i--)
        {
            if (_manager.Phase == GameManager.PlayerPhase.White)
            {
                if (_board.BoardInfo[_piece.TileNumZ][i-1] <= 0)
                {
                    if (_board.BoardInfo[_piece.TileNumZ][i-1] == 0)
                    {
                        _board.Tiles[_piece.TileNumZ, i-1].gameObject.GetComponent<MeshRenderer>().enabled = true;
                    }
                    else if (_board.BoardInfo[_piece.TileNumZ][i-1] < 0)
                        break;
                }
                else
                    break;
            }
            else if (_manager.Phase == GameManager.PlayerPhase.Black)
            {
                if (_board.BoardInfo[_piece.TileNumZ][i-1] >= 0)
                {
                    if (_board.BoardInfo[_piece.TileNumZ][i-1] == 0)
                    {
                        _board.Tiles[_piece.TileNumZ, i-1].gameObject.GetComponent<MeshRenderer>().enabled = true;
                    }
                    else if (_board.BoardInfo[_piece.TileNumZ][i-1] > 0)
                        break;
                }
                else
                    break;
            }
        }
    }
}
