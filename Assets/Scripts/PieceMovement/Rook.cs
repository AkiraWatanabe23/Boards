using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        //�O����
        for (int i = _piece.TileNumZ; i > 0; i--)
        {
            if (_manager.Phase == GameManager.PlayerPhase.White)
            {
                if (_board.BoardInfo[i-1][_piece.TileNumX] <= 0)
                {
                    if (_board.BoardInfo[i - 1][_piece.TileNumX] == 0)
                    {
                        _board.Tiles[i - 1, _piece.TileNumX].gameObject.GetComponent<MeshRenderer>().enabled = true;
                        Debug.Log($"���̃}�X�ɂ͐i�߂܂� White �O _board.BoardInfo[{i - 1}][{_piece.TileNumX}]");
                    }
                    else if (_board.BoardInfo[i - 1][_piece.TileNumX] < 0)
                    {
                        Debug.Log($"���̋�l��܂� White �O _board.BoardInfo[{i - 1}][{_piece.TileNumX}]");
                        break;
                    }
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
                        _board.Tiles[i - 1, _piece.TileNumX].gameObject.GetComponent<MeshRenderer>().enabled = true;
                        Debug.Log($"���̃}�X�ɂ͐i�߂܂� Black ��� _board.BoardInfo[{i - 1}][{_piece.TileNumX}]");
                    }
                    else if (_board.BoardInfo[i - 1][_piece.TileNumX] > 0)
                    {
                        Debug.Log($"���̋�l��܂� Black ��� _board.BoardInfo[{i - 1}][{_piece.TileNumX}]");
                        break;
                    }
                }
                else
                    break;
            }
        }
        //������
        for (int i = _piece.TileNumZ; i < 7; i++)
        {
            if (_manager.Phase == GameManager.PlayerPhase.White)
            {
                if (_board.BoardInfo[i+1][_piece.TileNumX] <= 0)
                {
                    Debug.Log("���̃}�X�ɂ͐i�߂܂� White�@���");
                }
                else
                    break;
            }
            else if (_manager.Phase == GameManager.PlayerPhase.Black)
            {
                if (_board.BoardInfo[i+1][_piece.TileNumX] >= 0)
                {
                    Debug.Log("���̃}�X�ɂ͐i�߂܂� Black ���");
                }
                else
                    break;
            }
        }
        //�E����
        for (int i = 0; i < 7 - _piece.TileNumX; i++)
        {

        }
        //������
        for (int i = 0; i < _piece.TileNumX; i++)
        {

        }
    }
}
