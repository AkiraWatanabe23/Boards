using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : MovementBase
{
    //�O�㍶�E�����̃}�X����̈ړ���
    readonly int[] ZnumVer = new int[] { -1, 1 };
    readonly int[] XnumVer = new int[] { -1, 1 };
    readonly int[] ZnumHor = new int[] { -1, 1 };
    readonly int[] XnumHor = new int[] { -1, 1, -1, 1 };

    /// <summary>
    /// �T���͈͂̕`��
    /// </summary>
    void Update()
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (Piece.Movable[i, j] == true)
                {
                    Board.Tiles[i, j].GetComponent<MeshRenderer>().enabled = true;
                }
                else
                {
                    Board.Tiles[i, j].GetComponent<MeshRenderer>().enabled = false;
                }
            }
        }
    }

    public void Movement()
    {
        //�O��
        for (int i = 0; i < ZnumVer.Length; i++)
        {
            if ((i == 0 && Piece.TileNumZ != 0) || (i == 1 && Piece.TileNumZ != 7)) //IndexOutOfRange�h�~
            {
                GetableCheck(Piece.TileNumX, Piece.TileNumZ + ZnumVer[i], 0);

                //�ǂ����̃^�[����
                if (Manager.Phase == GameManager.PlayerPhase.White)
                {
                    GetableCheck(Piece.TileNumX, Piece.TileNumZ + ZnumVer[i], 1);
                }
                else if (Manager.Phase == GameManager.PlayerPhase.Black)
                {
                    GetableCheck(Piece.TileNumX, Piece.TileNumZ + ZnumVer[i], 2);
                }
            }
        }
        //���E
        for (int i = 0; i < XnumVer.Length; i++)
        {
            if ((i == 0 && Piece.TileNumX != 0) || (i == 1 && Piece.TileNumX != 7))
            {
                GetableCheck(Piece.TileNumX + XnumVer[i], Piece.TileNumZ, 0);

                //�ǂ����̃^�[����
                if (Manager.Phase == GameManager.PlayerPhase.White)
                {
                    GetableCheck(Piece.TileNumX + XnumVer[i], Piece.TileNumZ, 1);
                }
                else if (Manager.Phase == GameManager.PlayerPhase.Black)
                {
                    GetableCheck(Piece.TileNumX + XnumVer[i], Piece.TileNumZ, 2);
                }
            }
        }
        //�΂�
        for (int i = 0; i < XnumHor.Length; i++)
        {
            if (i <= 1) //�O
            {
                if ((i == 0 && Piece.TileNumX != 0 && Piece.TileNumZ != 0) ||
                    (i == 1 && Piece.TileNumX != 7 && Piece.TileNumZ != 0))
                {
                    GetableCheck(Piece.TileNumX + XnumHor[i], Piece.TileNumZ + ZnumHor[0], 0);

                    //�ǂ����̃^�[����
                    if (Manager.Phase == GameManager.PlayerPhase.White)
                    {
                        GetableCheck(Piece.TileNumX + XnumHor[i], Piece.TileNumZ + ZnumHor[0], 1);
                    }
                    else if (Manager.Phase == GameManager.PlayerPhase.Black)
                    {
                        GetableCheck(Piece.TileNumX + XnumHor[i], Piece.TileNumZ + ZnumHor[0], 2);
                    }
                }
            }
            else //���
            {
                if ((i == 2 && Piece.TileNumX != 0 && Piece.TileNumZ != 7) ||
                    (i == 3 && Piece.TileNumX != 7 && Piece.TileNumZ != 7))
                {
                    GetableCheck(Piece.TileNumX + XnumHor[i], Piece.TileNumZ + ZnumHor[1], 0);

                    //�ǂ����̃^�[����
                    if (Manager.Phase == GameManager.PlayerPhase.White)
                    {
                        GetableCheck(Piece.TileNumX + XnumHor[i], Piece.TileNumZ + ZnumHor[1], 1);
                    }
                    else if (Manager.Phase == GameManager.PlayerPhase.Black)
                    {
                        GetableCheck(Piece.TileNumX + XnumHor[i], Piece.TileNumZ + ZnumHor[1], 2);
                    }
                }
            }
        }
    }

    void GetableCheck(int x, int z, int phase)
    {
        if (phase == 0) //�}�X�̒T��
        {
            if (Board.BoardInfo[z][x] == 0)
            {
                Piece.Movable[z, x] = true;
            }
        }
        else if (phase == 1) //�l������邩(��)
        {
            if (Board.BoardInfo[z][x] < 0)
            {
                GetableRay(x, z);
            }
        }
        else if (phase == 2) //�l������邩(��)
        {
            if (Board.BoardInfo[z][x] > 0)
            {
                GetableRay(x, z);
            }
        }
    }
}
