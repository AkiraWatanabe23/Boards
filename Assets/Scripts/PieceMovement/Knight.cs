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
    readonly int[] ZnumVer = new int[] { -2, -2, 2, 2 };
    readonly int[] XnumVer = new int[] { -1, 1, -1, 1 };
    //���E�����̃}�X����̈ړ���
    readonly int[] ZnumHor = new int[] { -1, 1, -1, 1 };
    readonly int[] XnumHor = new int[] { -2, -2, 2, 2 };

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

    public void Movement()
    {
        MovableTile();
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

        for (int i = 0; i < ZnumVer.Length; i++) 
        {
            if ((i <= 1 && z >= 2) || (i > 1 && z <= 5)) //�O��(IndexOutofRange�h�~)
            {
                GetableCheck(x + XnumVer[i], z + ZnumVer[i], 0);
            }
        } 
        for (int i = 0; i < ZnumHor.Length; i++)
        {
            if ((i <= 1 && x >= 2) || (i > 1 && x <= 5)) //���E
            {
                GetableCheck(x + XnumHor[i], z + ZnumHor[i], 0);
            }
        }
    }

    void WhiteTurn()
    {
        int x = _piece.TileNumX;
        int z = _piece.TileNumZ;

        for (int i = 0; i < ZnumVer.Length; i++)
        {
            if ((i <= 1 && z >= 2) || (i > 1 && z <= 5)) //�O
            {
                GetableCheck(x - XnumVer[i], z - ZnumVer[i], 1);
            }
        }
        for (int i = 0; i < ZnumHor.Length; i++)
        {
            if ((i <= 1 && x >= 2) || (i > 1 && x <= 5))
            {
                GetableCheck(x - XnumHor[i], z - ZnumHor[i], 1);
            }
        }
    }

    void BlackTurn()
    {
        int x = _piece.TileNumX;
        int z = _piece.TileNumZ;

        for (int i = 0; i < ZnumVer.Length; i++)
        {
            if ((i <= 1 && z >= 2) || (i > 1 && z <= 5))
            {
                GetableCheck(x - XnumVer[i], z - ZnumVer[i], 2);
            }
        }
        for (int i = 0; i < ZnumHor.Length; i++)
        {
            if ((i <= 1 && x >= 2) || (i > 1 && x <= 5))
            {
                GetableCheck(x - XnumHor[i], z - ZnumHor[i], 2);
            }
        }
    }

    void GetableCheck(int x, int z, int phase)
    {
        switch (phase)
        {
            case 0: //�}�X�̒T��
                if (_board.BoardInfo[z][x] == 0)
                {
                    _piece.Movable[z, x] = true;
                }
                break;
            case 1: //�l������邩(��)
                if (_board.BoardInfo[z][x] < 0)
                {
                    GetableRay(x, z);
                }
                break;
            case 2: //�l������邩(��)
                if (_board.BoardInfo[z][x] > 0)
                {
                    GetableRay(x, z);
                }
                break;
        }
    }

    void GetableRay(int x, int z)
    {
        //���̋���l����Ԃɐ؂�ւ���(�����_�͐F�ς��邾��)
        if (Physics.Raycast(new Vector3(x, 5f, -z), Vector3.down, out RaycastHit hit, 20))
        {
            hit.collider.gameObject.GetComponent<MeshRenderer>().material = _getable;
        }
    }
}
