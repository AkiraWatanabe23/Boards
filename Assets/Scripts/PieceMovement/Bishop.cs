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
        //�O����
        int j = _piece.TileNumX; //���O�T���p
        int k = _piece.TileNumX; //�E�O�T���p
        for (int i = _piece.TileNumZ; i > 0; i--)
        {
            //���O
            if (_board.BoardInfo[i - 1][j - 1] == 0)
            {
                _piece.Movable[i - 1, j - 1] = true;
                if (j == 1) //IndexOutOfRange �h�~
                    break;
            }

            //�ǂ����̃^�[����
            if (_manager.Phase == GameManager.PlayerPhase.White)
            {
                //�����ΒT���I��
                //�G��
                if (_board.BoardInfo[i - 1][j - 1] < 0)
                {
                    //���̋���l����Ԃɂ��ĒT���I��
                    break;
                }
                //������(���̎��_�ŒT���I��)
                else if (_board.BoardInfo[i - 1][j - 1] > 0)
                    break;
            }
            else if (_manager.Phase == GameManager.PlayerPhase.Black)
            {
                //�����ΒT���I��
                //�G��
                if (_board.BoardInfo[i - 1][j - 1] > 0)
                {
                    //���̋���l����Ԃɂ��ĒT���I��
                    break;
                }
                //������
                else if (_board.BoardInfo[i - 1][j - 1] < 0)
                    break;
            }
            j--;
        }
        for (int i = _piece.TileNumZ; i > 0; i--)
        {
            //�E�O
            if (_board.BoardInfo[i - 1][k + 1] == 0)
            {
                _piece.Movable[i - 1, k + 1] = true;
                if (k == 6)
                    break;
            }

            //�ǂ����̃^�[����
            if (_manager.Phase == GameManager.PlayerPhase.White)
            {
                //�����ΒT���I��
                //�G��
                if (_board.BoardInfo[i - 1][k + 1] < 0)
                {
                    //���̋���l����Ԃɂ��ĒT���I��
                    break;
                }
                //������(���̎��_�ŒT���I��)
                else if (_board.BoardInfo[i - 1][k + 1] > 0)
                    break;
            }
            else if (_manager.Phase == GameManager.PlayerPhase.Black)
            {
                //�����ΒT���I��
                //�G��
                if (_board.BoardInfo[i - 1][k + 1] > 0)
                {
                    //���̋���l����Ԃɂ��ĒT���I��
                    break;
                }
                //������
                else if (_board.BoardInfo[i - 1][k + 1] < 0)
                    break;
            }
            k++;
        }

        //������
        j = _piece.TileNumX; //�����
        k = _piece.TileNumX; //�E���
        for (int i = _piece.TileNumZ; i < 7; i++)
        {
            //�����
            if (_board.BoardInfo[i + 1][j - 1] == 0)
            {
                _piece.Movable[i + 1, j - 1] = true;
                if (j == 1)
                    break;
            }

            //�ǂ����̃^�[����
            if (_manager.Phase == GameManager.PlayerPhase.White)
            {
                //�����ΒT���I��
                //�G��
                if (_board.BoardInfo[i + 1][j - 1] < 0)
                {
                    //���̋���l����Ԃɂ��ĒT���I��
                    break;
                }
                //������(���̎��_�ŒT���I��)
                else if (_board.BoardInfo[i + 1][j - 1] > 0)
                    break;
            }
            else if (_manager.Phase == GameManager.PlayerPhase.Black)
            {
                //�����ΒT���I��
                //�G��
                if (_board.BoardInfo[i + 1][j - 1] > 0)
                {
                    //���̋���l����Ԃɂ��ĒT���I��
                    break;
                }
                //������
                else if (_board.BoardInfo[i + 1][j - 1] < 0)
                    break;
            }
            j--;
        }
        for (int i = _piece.TileNumZ; i < 7; i++)
        {
            //�E���
            if (_board.BoardInfo[i + 1][k + 1] == 0)
            {
                _piece.Movable[i + 1, k + 1] = true;
                if (k == 6)
                    break;
            }

            //�ǂ����̃^�[����
            if (_manager.Phase == GameManager.PlayerPhase.White)
            {
                //�����ΒT���I��
                //�G��
                if (_board.BoardInfo[i + 1][k + 1] < 0)
                {
                    //���̋���l����Ԃɂ��ĒT���I��
                    break;
                }
                //������(���̎��_�ŒT���I��)
                else if (_board.BoardInfo[i + 1][k + 1] > 0)
                    break;
            }
            else if (_manager.Phase == GameManager.PlayerPhase.Black)
            {
                //�����ΒT���I��
                //�G��
                if (_board.BoardInfo[i + 1][k + 1] > 0)
                {
                    //���̋���l����Ԃɂ��ĒT���I��
                    break;
                }
                //������
                else if (_board.BoardInfo[i + 1][k + 1] < 0)
                    break;
            }
            k++;
        }
    }
}
