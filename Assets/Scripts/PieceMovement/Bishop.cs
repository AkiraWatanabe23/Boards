/// <summary>
/// �r�V���b�v�̈ړ��T��
/// </summary>
public class Bishop : MovementBase
{
    public void Movement()
    {
        //�O����
        int j = Piece.TileNumX; //���O�T���p
        int k = Piece.TileNumX; //�E�O�T���p

        for (int i = Piece.TileNumZ; i > 0; i--)
        {
            //���O
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
            //�E�O
            if (MovableRight(k + 1, i - 1))
            {
                k++;
                continue;
            }
            else
                break;
        }

        //������
        j = Piece.TileNumX; //�����
        k = Piece.TileNumX; //�E���

        for (int i = Piece.TileNumZ; i < 7; i++)
        {
            //�����
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
            //�E���
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
        if (x < 0) //IndexOutOfRange �h�~
            return false;

        if (Board.BoardInfo[z][x] == 0)
        {
            Piece.Movable[z, x] = true;
            return true;
        }

        //�ǂ����̃^�[����
        if (Manager.Phase == GameManager.PlayerPhase.White)
        {
            if (Board.BoardInfo[z][x] < 0) //�G��(�l����Ԃɐ؂�ւ��Ă���T���I��)
            {
                GetableRay(x, z);
                return false;
            }
            else if (Board.BoardInfo[z][x] > 0) //������(���������ɒT���I��)
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

        //�ǂ����̃^�[����
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
