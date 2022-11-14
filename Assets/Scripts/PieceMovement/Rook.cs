/// <summary>
/// ルークの移動探索
/// </summary>
public class Rook : MovementBase
{
    /// <summary> 
    /// 前後左右の探索
    /// (やっていることは全方向で同じだけど、いる位置によって探索範囲が異なるため、各方向で探索を分ける)
    /// </summary>
    public void Movement()
    {
        //前後方向
        for (int i = Piece.TileNumZ; i > 0; i--)
        {
            if (MovableCheck(Piece.TileNumX, i - 1)) //true なら処理を続行
                continue;
            else                                     //false なら処理を終了
                break;
        }

        for (int i = Piece.TileNumZ; i < 7; i++)
        {
            if (MovableCheck(Piece.TileNumX, i + 1))
                continue;
            else
                break;
        }
        //左右方向
        for (int i = Piece.TileNumX; i < 7; i++)
        {
            if (MovableCheck(i + 1, Piece.TileNumZ))
                continue;
            else
                break;
        }

        for (int i = Piece.TileNumX; i > 0; i--)
        {
            if (MovableCheck(i - 1, Piece.TileNumZ))
                continue;
            else
                break;
        }
    }

    bool MovableCheck(int x, int z)
    {
        //マスが空いていたら動ける
        if (Board.BoardInfo[z][x] == 0)
        {
            Piece.Movable[z, x] = true;
            return true;
        }

        //どっちのターンか
        if (Manager.Phase == GameManager.PlayerPhase.White)
        {
            if (Board.BoardInfo[z][x] < 0) //敵駒(獲れる状態に切り替えてから探索終了)
            {
                GetableRay(x, z);
                return false;
            }
            else if (Board.BoardInfo[z][x] > 0) //味方駒(何もせずに探索終了)
                return false;
        }
        else if (Manager.Phase == GameManager.PlayerPhase.Black)
        {
            if (Board.BoardInfo[z][x] > 0)
            {
                GetableRay(x, z);
                return false;
            }
            else if (Board.BoardInfo[z][x] < 0)
                return false;
        }
        return false;
    }
}
