using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���[�N�̈ړ��T��
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
    /// �T���͈͂̕`��
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
    /// �O�㍶�E�̒T��
    /// (����Ă��邱�Ƃ͑S�����œ��������ǁA����ʒu�ɂ���ĒT���͈͂��قȂ邽�߁A�e�����ŒT���𕪂���)
    /// </summary>
    public void Movement()
    {
        //�O�����
        for (int i = _piece.TileNumZ; i > 0; i--)
        {
            if (MovableCheck(_piece.TileNumX, i - 1)) //true ���Ԃ��Ă����珈���𑱍s
                continue;
            else                                      //false ���Ԃ��Ă����珈�����I��
                break;
        }

        for (int i = _piece.TileNumZ; i < 7; i++)
        {
            if (MovableCheck(_piece.TileNumX, i + 1))
                continue;
            else
                break;
        }
        //���E����
        for (int i = _piece.TileNumX; i < 7; i++)
        {
            if (MovableCheck(i + 1, _piece.TileNumZ))
                continue;
            else
                break;
        }

        for (int i = _piece.TileNumX; i > 0; i--)
        {
            if (MovableCheck(i - 1, _piece.TileNumZ))
                continue;
            else
                break;
        }
    }

    bool MovableCheck(int x, int z)
    {
        //�}�X���󂢂Ă����瓮����
        if (_board.BoardInfo[z][x] == 0)
        {
            _piece.Movable[z, x] = true;
            return true;
        }

        //�ǂ����̃^�[����
        if (_manager.Phase == GameManager.PlayerPhase.White)
        {
            if (_board.BoardInfo[z][x] < 0) //�G��(�l����Ԃɐ؂�ւ��Ă���T���I��)
            {
                GetableRay(x, z);
                return false;
            }
            else if (_board.BoardInfo[z][x] > 0) //������(���������ɒT���I��)
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
        //���̋���l����Ԃɐ؂�ւ���
        if (Physics.Raycast(new Vector3(x, 5f, -z), Vector3.down, out RaycastHit hit, 20))
        {
            hit.collider.gameObject.GetComponent<MeshRenderer>().material = _getable;
        }
    }
}
