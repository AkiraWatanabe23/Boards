/// <summary>
/// ���[�N�̈ړ��T��
/// </summary>
public class Rook : MovementBase
{
    /// <summary> 
    /// �O�㍶�E�̒T��
    /// (����Ă��邱�Ƃ͑S�����œ��������ǁA����ʒu�ɂ���ĒT���͈͂��قȂ邽�߁A�e�����ŒT���𕪂���)
    /// </summary>
    public void Movement()
    {
        //�O�����
        for (int i = Piece.TileNumZ; i > 0; i--)
        {
            if (MovableCheck(Piece.TileNumX, i - 1)) //true �Ȃ珈���𑱍s
                continue;
            else                                     //false �Ȃ珈�����I��
                break;
        }

        for (int i = Piece.TileNumZ; i < 7; i++)
        {
            if (MovableCheck(Piece.TileNumX, i + 1))
                continue;
            else
                break;
        }
        //���E����
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
        //�}�X���󂢂Ă����瓮����
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
}
