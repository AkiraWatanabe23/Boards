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
    int[] ZnumHor = new int[] { -1, 1, -1, 1 };
    int[] XnumHor = new int[] { -2, -2, 2, 2 };

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
            if (i <= 1 && z >= 2) //�O(IndexOutofRange�h�~)
            {
                if (_board.BoardInfo[z + ZnumVer[i]][x + XnumVer[i]] == 0)
                {
                    _piece.Movable[z + ZnumVer[i], x + XnumVer[i]] = true;
                }
            }
            else if (i > 1 && z <= 5) //���
            {
                if (_board.BoardInfo[z + ZnumVer[i]][x + XnumVer[i]] == 0)
                {
                    _piece.Movable[z + ZnumVer[i], x + XnumVer[i]] = true;
                }
            }
        } 
        //���E
        for (int i = 0; i < ZnumHor.Length; i++)
        {
            //��
            if (i <= 1 && x >= 2)
            {
                if (_board.BoardInfo[z + ZnumHor[i]][x + XnumHor[i]] == 0)
                {
                    _piece.Movable[z + ZnumHor[i], x + XnumHor[i]] = true;
                }
            }
            //�E
            else if (i > 1 && x <= 5)
            {
                if (_board.BoardInfo[z + ZnumHor[i]][x + XnumHor[i]] == 0)
                {
                    _piece.Movable[z + ZnumHor[i], x + XnumHor[i]] = true;
                }
            }
        }
    }

    void WhiteTurn()
    {
        int x = _piece.TileNumX;
        int z = _piece.TileNumZ;

        //�����ΒT���I��
        for (int i = 0; i < ZnumVer.Length; i++)
        {
            if (_board.BoardInfo[z - ZnumVer[i]][x - XnumVer[i]] < 0)
            {
                GetableRay(x - XnumVer[i], z - ZnumVer[i]); //�G��(�l����Ԃɐ؂�ւ���)
            }
        }
        //���E
        for (int i = 0; i < ZnumHor.Length; i++)
        {
            if (_board.BoardInfo[z - ZnumHor[i]][x - XnumHor[i]] < 0)
            {
                GetableRay(x - XnumHor[i], z - ZnumHor[i]);
            }
        }
    }

    void BlackTurn()
    {
        int x = _piece.TileNumX;
        int z = _piece.TileNumZ;

        for (int i = 0; i < ZnumVer.Length; i++)
        {
            if (_board.BoardInfo[z - ZnumVer[i]][x - XnumVer[i]] > 0)
            {
                GetableRay(x - XnumVer[i], z - ZnumVer[i]);
            }
        }
        for (int i = 0; i < ZnumHor.Length; i++)
        {
            if (_board.BoardInfo[z - ZnumHor[i]][x - XnumHor[i]] > 0)
            {
                GetableRay(x - XnumHor[i], z - ZnumHor[i]);
            }
        }
    }

    void GetableRay(int x, int z)
    {
        RaycastHit hit;

        //���̋���l����Ԃɐ؂�ւ���
        if (Physics.Raycast(new Vector3(x, 5f, -z), Vector3.down, out hit, 20))
        {
            hit.collider.gameObject.GetComponent<MeshRenderer>().material = _getable;
        }
    }
}
