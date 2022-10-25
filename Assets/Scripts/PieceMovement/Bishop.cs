using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bishop : MonoBehaviour
{
    [SerializeField] Material _movable;
    [SerializeField] Material _getable;
    GameManager _manager;
    PieceManager _piece;
    TestLoad _board;

    // Start is called before the first frame update
    void Start()
    {
        _manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _piece = GameObject.Find("Piece").GetComponent<PieceManager>();
        _board = GameObject.Find("Board").GetComponent<TestLoad>();
    }

    /// <summary>
    /// ’Tõ”ÍˆÍ‚Ì•`‰æ
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
        //‘O•ûŒü
        int j = _piece.TileNumX; //¶‘O’Tõ—p
        int k = _piece.TileNumX; //‰E‘O’Tõ—p

        for (int i = _piece.TileNumZ; i > 0; i--)
        {
            //¶‘O
            if (MovableLeft(j - 1, i - 1))
            {
                j--;
                continue;
            }
            else
                break;
        }
        for (int i = _piece.TileNumZ; i > 0; i--)
        {
            //‰E‘O
            if (MovableRight(k + 1, i - 1))
            {
                k++;
                continue;
            }
            else
                break;
        }

        //Œã‚ë•ûŒü
        j = _piece.TileNumX; //¶Œã‚ë
        k = _piece.TileNumX; //‰EŒã‚ë

        for (int i = _piece.TileNumZ; i < 7; i++)
        {
            //¶Œã‚ë
            if (MovableLeft(j - 1, i + 1))
            {
                j--;
                continue;
            }
            else
                break;
        }
        for (int i = _piece.TileNumZ; i < 7; i++)
        {
            //‰EŒã‚ë
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
        if (x < 0) //IndexOutOfRange –h~
            return false;

        if (_board.BoardInfo[z][x] == 0)
        {
            _piece.Movable[z, x] = true;
            return true;
        }

        //‚Ç‚Á‚¿‚Ìƒ^[ƒ“‚©
        if (_manager.Phase == GameManager.PlayerPhase.White)
        {
            if (_board.BoardInfo[z][x] < 0) //“G‹î(Šl‚ê‚éó‘Ô‚ÉØ‚è‘Ö‚¦‚Ä‚©‚ç’TõI—¹)
            {
                GetableRay(x, z);
                return false;
            }
            else if (_board.BoardInfo[z][x] > 0) //–¡•û‹î(‰½‚à‚¹‚¸‚É’TõI—¹)
                return false;
        }
        else if (_manager.Phase == GameManager.PlayerPhase.Black)
        {
            if (_board.BoardInfo[z][x] > 0)
            {
                GetableRay(x, z);
                return false;
            }
            else if (_board.BoardInfo[z][x] < 0)
                return false;
        }
        return false;
    }
    bool MovableRight(int x, int z)
    {
        if (x > 7)
            return false;

        if (_board.BoardInfo[z][x] == 0)
        {
            _piece.Movable[z, x] = true;
            return true;
        }

        //‚Ç‚Á‚¿‚Ìƒ^[ƒ“‚©
        if (_manager.Phase == GameManager.PlayerPhase.White)
        {
            if (_board.BoardInfo[z][x] < 0)
            {
                GetableRay(x, z);
                return false;
            }
            else if (_board.BoardInfo[z][x] > 0)
                return false;
        }
        else if (_manager.Phase == GameManager.PlayerPhase.Black)
        {
            if (_board.BoardInfo[z][x] > 0)
            {
                GetableRay(x, z);
                return false;
            }
            else if (_board.BoardInfo[z][x] < 0)
                return false;
        }
        return false;
    }

    void GetableRay(int x, int z)
    {
        //‚»‚Ì‹î‚ğŠl‚ê‚éó‘Ô‚ÉØ‚è‘Ö‚¦‚é
        if (Physics.Raycast(new Vector3(x, 5f, -z), Vector3.down, out RaycastHit hit, 20))
        {
            hit.collider.gameObject.GetComponent<MeshRenderer>().material = _getable;
        }
    }
}
