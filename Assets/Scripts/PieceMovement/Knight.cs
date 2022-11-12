/// <summary>
/// ナイトの移動探索
/// </summary>
public class Knight : MovementBase
{
    //前後方向のマスからの移動差
    readonly int[] ZnumVer = new int[] { -2, -2, 2, 2 };
    readonly int[] XnumVer = new int[] { -1, 1, -1, 1 };
    //左右方向のマスからの移動差
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

    /// <summary> 動けるマスか </summary>
    void MovableTile()
    {
        int x = Piece.TileNumX;
        int z = Piece.TileNumZ;

        for (int i = 0; i < ZnumVer.Length; i++) 
        {
            if ((i <= 1 && z >= 2) || (i > 1 && z <= 5)) //前後(IndexOutofRange防止)
            {
                GetableCheck(x + XnumVer[i], z + ZnumVer[i], 0);
            }
        } 
        for (int i = 0; i < ZnumHor.Length; i++)
        {
            if ((i <= 1 && x >= 2) || (i > 1 && x <= 5)) //左右
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
            if ((i <= 1 && z >= 2) || (i > 1 && z <= 5)) //前
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
            case 0: //マスの探索
                if (Board.BoardInfo[z][x] == 0)
                {
                    Piece.Movable[z, x] = true;
                }
                break;
            case 1: //獲れる駒があるか(白)
                if (Board.BoardInfo[z][x] < 0)
                {
                    GetableRay(x, z);
                }
                break;
            case 2: //獲れる駒があるか(黒)
                if (Board.BoardInfo[z][x] > 0)
                {
                    GetableRay(x, z);
                }
                break;
        }
    }
}
