using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���[�N�̈ړ��T��
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
    /// �O�㍶�E�̒T��
    /// (����Ă��邱�Ƃ͑S�����œ��������ǁA����ʒu�ɂ���ĒT���͈͂��قȂ邽�߁A�e�����ŒT���𕪂���)
    /// </summary>
    public void Movement()
    {
        //�O�����
        for (int i = _piece.TileNumZ; i > 0; i--)
        {
            //�}�X���󂢂Ă����瓮����
            if (_board.BoardInfo[i - 1][_piece.TileNumX] == 0)
            {
                _board.Tiles[i - 1, _piece.TileNumX].gameObject.GetComponent<MeshRenderer>().enabled = true;
            }

            //�ǂ����̃^�[����
            if (_manager.Phase == GameManager.PlayerPhase.White)
            {
                //�����ΒT���I��
                //�G��
                if (_board.BoardInfo[i - 1][_piece.TileNumX] < 0)
                {
                    //���̋���l����Ԃɂ��ĒT���I��
                    break;
                }
                //������(���̎��_�ŒT���I��)
                else if (_board.BoardInfo[i - 1][_piece.TileNumX] > 0)
                    break;
            }
            else if (_manager.Phase == GameManager.PlayerPhase.Black)
            {
                //�����ΒT���I��
                //�G��
                if (_board.BoardInfo[i - 1][_piece.TileNumX] > 0)
                {
                    //���̋���l����Ԃɂ��ĒT���I��
                    break;
                }
                //������
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
                //�����ΒT���I��
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
        //���E����
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
