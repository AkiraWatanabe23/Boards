/// <summary>
/// �i�C�g�̈ړ��T��
/// </summary>
public class Knight : MovementBase
{
    //�O������̃}�X����̈ړ���
    readonly int[] ZnumVer = new int[] { -2, -2, 2, 2 };
    readonly int[] XnumVer = new int[] { -1, 1, -1, 1 };
    //���E�����̃}�X����̈ړ���
    readonly int[] ZnumHor = new int[] { -1, 1, -1, 1 };
    readonly int[] XnumHor = new int[] { -2, -2, 2, 2 };

    public void Movement()
    {
        MovableTile();
        if (Manager.Phase == GameManager.PlayerPhase.White)
        {
            WhiteTurn();
        }
        else if (Manager.Phase == GameManager.PlayerPhase.Black)
        {
            BlackTurn();
        }
    }

    /// <summary> ������}�X�� </summary>
    void MovableTile()
    {
        int x = Piece.TileNumX;
        int z = Piece.TileNumZ;

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
        int x = Piece.TileNumX;
        int z = Piece.TileNumZ;

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
        int x = Piece.TileNumX;
        int z = Piece.TileNumZ;

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
                if (Board.BoardInfo[z][x] == 0)
                {
                    Piece.Movable[z, x] = true;
                }
                break;
            case 1: //�l������邩(��)
                if (Board.BoardInfo[z][x] < 0)
                {
                    GetableRay(x, z);
                }
                break;
            case 2: //�l������邩(��)
                if (Board.BoardInfo[z][x] > 0)
                {
                    GetableRay(x, z);
                }
                break;
        }
    }
}
