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
    //�O������̃}�X����̈ړ���
    int[] ZnumVer = new int[] { -2, -2, 2, 2 };
    int[] XnumVer = new int[] { -1, 1, -1, 1 };
    //���E�����̃}�X����̈ړ���
    int[] ZnumHor = new int[] { -1, -1, 1, 1 };
    int[] XnumHor = new int[] { -2, 2, -2, 2 };

    // Start is called before the first frame update
    void Start()
    {
        _manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _piece = GameObject.Find("Piece").GetComponent<PieceManager>();
        _board = GameObject.Find("Board").GetComponent<TestLoad>();
    }

    public void Movement()
    {
        MovableTile();
        //�ǂ����̃^�[����
        if (_manager.Phase == GameManager.PlayerPhase.White)
        {
            WhiteTurn();
        }
        else if (_manager.Phase == GameManager.PlayerPhase.Black)
        {
            BlackTurn();
        }
    }

    /// <summary> ������}�X�� </summary>
    void MovableTile()
    {
        int x = _piece.TileNumX;
        int z = _piece.TileNumZ;

        //�O��
        for (int i = 0; i < ZnumVer.Length; i++) 
        {
            if (_board.BoardInfo[z + ZnumVer[i]][x + XnumVer[i]] == 0)
            {
                _board.Tiles[z + ZnumVer[i], x + XnumVer[i]].gameObject.GetComponent<MeshRenderer>().enabled = true;
            }
        } 
        //���E
        for (int i = 0; i < ZnumHor.Length; i++)
        {
            if (_board.BoardInfo[z + ZnumHor[i]][x + XnumHor[i]] == 0)
            {
                _board.Tiles[z + ZnumHor[i], x + XnumHor[i]].gameObject.GetComponent<MeshRenderer>().enabled = true;
            }
        }
    }

    void WhiteTurn()
    {
        RaycastHit hit;
        int x = _piece.TileNumX;
        int z = _piece.TileNumZ;

        //�����ΒT���I��
        for (int i = 0; i < ZnumVer.Length; i++)
        {
            if (_board.BoardInfo[z - ZnumVer[i]][x - XnumVer[i]] < 0)
            {
                //�G��
                //���̃}�X��Ray��΂��ċ�̐F�ς���?
                if (Physics.Raycast(new Vector3(x - XnumVer[i], 5f, -(z - ZnumVer[i])), Vector3.down, out hit, 20))
                {
                    hit.collider.gameObject.GetComponent<MeshRenderer>().material = _getable;
                }
            }
            else if (_board.BoardInfo[z - ZnumVer[i]][x - XnumVer[i]] > 0)
            {
                //������
            }
        }
        //���E
        for (int i = 0; i < ZnumHor.Length; i++)
        {
            if (_board.BoardInfo[z - ZnumHor[i]][x - XnumHor[i]] < 0)
            {
                //�G��
                //���̃}�X��Ray��΂��ċ�̐F�ς���?
                if (Physics.Raycast(new Vector3(x - XnumHor[i], 5f, -(z - ZnumHor[i])), Vector3.down, out hit, 20))
                {
                    hit.collider.gameObject.GetComponent<MeshRenderer>().material = _getable;
                }
            }
            else if (_board.BoardInfo[z - ZnumHor[i]][x - XnumHor[i]] > 0)
            {
                //������
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
                //�G��
                //���̃}�X��Ray��΂��ċ�̐F�ς���?
                if (Physics.Raycast(new Vector3(x - XnumVer[i], 5f, -(z - ZnumVer[i])), Vector3.down, out hit, 20))
                {
                    hit.collider.gameObject.GetComponent<MeshRenderer>().material = _getable;
                }
            }
            else if (_board.BoardInfo[z - ZnumVer[i]][x - XnumVer[i]] < 0)
            {
                //������
            }
        }
        for (int i = 0; i < ZnumHor.Length; i++)
        {
            if (_board.BoardInfo[z - ZnumHor[i]][x - XnumHor[i]] > 0)
            {
                //�G��
                //���̃}�X��Ray��΂��ċ�̐F�ς���?
                if (Physics.Raycast(new Vector3(x - XnumHor[i], 5f, -(z - ZnumHor[i])), Vector3.down, out hit, 20))
                {
                    hit.collider.gameObject.GetComponent<MeshRenderer>().material = _getable;
                }
            }
            else if (_board.BoardInfo[z - ZnumHor[i]][x - XnumHor[i]] < 0)
            {
                //������
            }
        }
    }
}
