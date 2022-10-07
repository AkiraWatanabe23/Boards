using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bishop : MonoBehaviour
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
        int j = _piece.TileNumX; //���O�T���p
        int k = _piece.TileNumX; //�E�O�T���p
        for (int i = _piece.TileNumZ; i > 0; i--)
        {
            //���O
            if (_board.BoardInfo[i - 1][j - 1] == 0)
            {
                _board.Tiles[i - 1, j - 1].gameObject.GetComponent<MeshRenderer>().enabled = true;
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
                _board.Tiles[i - 1, k + 1].gameObject.GetComponent<MeshRenderer>().enabled = true;
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
                _board.Tiles[i + 1, j - 1].gameObject.GetComponent<MeshRenderer>().enabled = true;
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
                _board.Tiles[i + 1, k + 1].gameObject.GetComponent<MeshRenderer>().enabled = true;
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
