using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : MonoBehaviour
{
    [SerializeField] Material _movable;
    [SerializeField] Material _getable;
    GameManager _manager;
    PieceManager _piece;
    TestLoad _board;
    //�O�㍶�E�����̃}�X����̈ړ���
    int[] ZnumVer = new int[] { -1, 1 };
    int[] XnumVer = new int[] { 1, -1 };
    int[] ZnumHor = new int[] { -1, 1 };
    int[] XnumHor = new int[] { 1, -1, 1, -1 };

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
        //�O��
        for (int i = 0; i < ZnumVer.Length; i++)
        {
            if (_board.BoardInfo[_piece.TileNumZ + ZnumVer[i]][_piece.TileNumX] == 0)
            {
                _piece.Movable[_piece.TileNumZ + ZnumVer[i], _piece.TileNumX] = true;
            }

            //�ǂ����̃^�[����
            if (_manager.Phase == GameManager.PlayerPhase.White)
            {
                if (_board.BoardInfo[_piece.TileNumZ + ZnumVer[i]][_piece.TileNumX] < 0)
                {
                    GetableRay(_piece.TileNumX, _piece.TileNumZ + ZnumVer[i]); //�G��(�l����Ԃɐ؂�ւ���)
                }
            }
            else if (_manager.Phase == GameManager.PlayerPhase.Black)
            {
                if (_board.BoardInfo[_piece.TileNumZ + ZnumVer[i]][_piece.TileNumX] > 0)
                {
                    GetableRay(_piece.TileNumX, _piece.TileNumZ + ZnumVer[i]);
                }
            }
        }
        //���E
        for (int i = 0; i < XnumVer.Length; i++)
        {
            if (_board.BoardInfo[_piece.TileNumZ][_piece.TileNumX + XnumVer[i]] == 0)
            {
                _piece.Movable[_piece.TileNumZ, _piece.TileNumX + XnumVer[i]] = true;
            }

            //�ǂ����̃^�[����
            if (_manager.Phase == GameManager.PlayerPhase.White)
            {
                if (_board.BoardInfo[_piece.TileNumZ][_piece.TileNumX + XnumVer[i]] < 0)
                {
                    GetableRay(_piece.TileNumX + XnumVer[i], _piece.TileNumZ);
                }
            }
            else if (_manager.Phase == GameManager.PlayerPhase.Black)
            {
                if (_board.BoardInfo[_piece.TileNumZ][_piece.TileNumX + XnumVer[i]] > 0)
                {
                    GetableRay(_piece.TileNumX + XnumVer[i], _piece.TileNumZ);
                }
            }
        }
        //�΂�
        for (int i = 0; i < XnumHor.Length; i++)
        {
            if (i <= 1)
            {
                if (_board.BoardInfo[_piece.TileNumZ + ZnumHor[0]][_piece.TileNumX + XnumHor[i]] == 0)
                {
                    _piece.Movable[_piece.TileNumZ + ZnumHor[0], _piece.TileNumX + XnumHor[i]] = true;
                }

                //�ǂ����̃^�[����
                if (_manager.Phase == GameManager.PlayerPhase.White)
                {
                    if (_board.BoardInfo[_piece.TileNumZ + ZnumHor[0]][_piece.TileNumX + XnumHor[i]] < 0)
                    {
                        GetableRay(_piece.TileNumX + XnumHor[i], _piece.TileNumZ + ZnumHor[0]);
                    }
                }
                else if (_manager.Phase == GameManager.PlayerPhase.Black)
                {
                    if (_board.BoardInfo[_piece.TileNumZ + ZnumHor[0]][_piece.TileNumX + XnumHor[i]] > 0)
                    {
                        GetableRay(_piece.TileNumX + XnumHor[i], _piece.TileNumZ + ZnumHor[0]);
                    }
                }
            }
            else
            {
                if (_board.BoardInfo[_piece.TileNumZ + ZnumHor[1]][_piece.TileNumX + XnumHor[i]] == 0)
                {
                    _piece.Movable[_piece.TileNumZ + ZnumHor[1], _piece.TileNumX + XnumHor[i]] = true;
                }

                //�ǂ����̃^�[����
                if (_manager.Phase == GameManager.PlayerPhase.White)
                {
                    if (_board.BoardInfo[_piece.TileNumZ + ZnumHor[1]][_piece.TileNumX + XnumHor[i]] < 0)
                    {
                        GetableRay(_piece.TileNumX + XnumHor[i], _piece.TileNumZ + ZnumHor[1]);
                    }
                }
                else if (_manager.Phase == GameManager.PlayerPhase.Black)
                {
                    if (_board.BoardInfo[_piece.TileNumZ + ZnumHor[1]][_piece.TileNumX + XnumHor[i]] > 0)
                    {
                        GetableRay(_piece.TileNumX + XnumHor[i], _piece.TileNumZ + ZnumHor[1]);
                    }
                }
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
