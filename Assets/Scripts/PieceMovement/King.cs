/// <summary>
/// キングの移動探索
/// </summary>
public class King : MovementBase
{
    //前後左右方向のマスからの移動差
    readonly int[] ZnumVer = new int[] { -1, 1 };
    readonly int[] XnumVer = new int[] { -1, 1 };
    readonly int[] ZnumHor = new int[] { -1, 1 };
    readonly int[] XnumHor = new int[] { -1, 1, -1, 1 };

    public void Movement()
    {
        //前後
        for (int i = 0; i < ZnumVer.Length; i++)
        {
            if ((i == 0 && Piece.TileNumZ != 0) || (i == 1 && Piece.TileNumZ != 7)) //IndexOutOfRange防止
            {
                GetableCheck(Piece.TileNumX, Piece.TileNumZ + ZnumVer[i], 0);

                //どっちのターンか
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
        //左右
        for (int i = 0; i < XnumVer.Length; i++)
        {
            if ((i == 0 && Piece.TileNumX != 0) || (i == 1 && Piece.TileNumX != 7))
            {
                GetableCheck(Piece.TileNumX + XnumVer[i], Piece.TileNumZ, 0);

                //どっちのターンか
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
        //斜め
        for (int i = 0; i < XnumHor.Length; i++)
        {
            if (i <= 1) //前
            {
                if ((i == 0 && Piece.TileNumX != 0 && Piece.TileNumZ != 0) ||
                    (i == 1 && Piece.TileNumX != 7 && Piece.TileNumZ != 0))
                {
                    GetableCheck(Piece.TileNumX + XnumHor[i], Piece.TileNumZ + ZnumHor[0], 0);

                    //どっちのターンか
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
            else //後ろ
            {
                if ((i == 2 && Piece.TileNumX != 0 && Piece.TileNumZ != 7) ||
                    (i == 3 && Piece.TileNumX != 7 && Piece.TileNumZ != 7))
                {
                    GetableCheck(Piece.TileNumX + XnumHor[i], Piece.TileNumZ + ZnumHor[1], 0);

                    //どっちのターンか
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
        if (phase == 0) //マスの探索
        {
            if (Board.BoardInfo[z][x] == 0)
            {
                Piece.Movable[z, x] = true;
            }
        }
        else if (phase == 1) //獲れる駒があるか(白)
        {
            if (Board.BoardInfo[z][x] < 0)
            {
                GetableRay(x, z);
            }
        }
        else if (phase == 2) //獲れる駒があるか(黒)
        {
            if (Board.BoardInfo[z][x] > 0)
            {
                GetableRay(x, z);
            }
        }
    }
}
