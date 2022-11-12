/// <summary>
/// ビショップの移動探索
/// </summary>
public class Bishop : MovementBase
{
    public void Movement()
    {
        //前方向
        int j = Piece.TileNumX; //左前探索用
        int k = Piece.TileNumX; //右前探索用

        for (int i = Piece.TileNumZ; i > 0; i--)
        {
            //左前
            if (MovableLeft(j - 1, i - 1))
            {
                j--;
                continue;
            }
            else
                break;
        }
        for (int i = Piece.TileNumZ; i > 0; i--)
        {
            //右前
            if (MovableRight(k + 1, i - 1))
            {
                k++;
                continue;
            }
            else
                break;
        }

        //後ろ方向
        j = Piece.TileNumX; //左後ろ
        k = Piece.TileNumX; //右後ろ

        for (int i = Piece.TileNumZ; i < 7; i++)
        {
            //左後ろ
            if (MovableLeft(j - 1, i + 1))
            {
                j--;
                continue;
            }
            else
                break;
        }
        for (int i = Piece.TileNumZ; i < 7; i++)
        {
            //右後ろ
            if (MovableRight(k + 1, i + 1))
            {
                k++;
                continue;
            }
            else
                break;
        }
    }

    bool MovableLeft(int x, int z)
    {
        if (x < 0) //IndexOutOfRange 防止
            return false;

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
    bool MovableRight(int x, int z)
    {
        if (x > 7)
            return false;

        if (Board.BoardInfo[z][x] == 0)
        {
            Piece.Movable[z, x] = true;
            return true;
        }

        //どっちのターンか
        if (Manager.Phase == GameManager.PlayerPhase.White)
        {
            if (Board.BoardInfo[z][x] < 0)
            {
                GetableRay(x, z);
                return false;
            }
            else if (Board.BoardInfo[z][x] > 0)
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
