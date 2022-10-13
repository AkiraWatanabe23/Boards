using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ƒ‹[ƒN‚ÌˆÚ“®’Tõ
/// </summary>
public class Rook : MonoBehaviour
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
                    _board.Tiles[i, j].gameObject.GetComponent<MeshRenderer>().enabled = true;
                }
                else
                {
                    _board.Tiles[i, j].gameObject.GetComponent<MeshRenderer>().enabled = false;
                }
            }
        }
    }

    /// <summary> 
    /// ‘OŒã¶‰E‚Ì’Tõ
    /// (‚â‚Á‚Ä‚¢‚é‚±‚Æ‚Í‘S•ûŒü‚Å“¯‚¶‚¾‚¯‚ÇA‚¢‚éˆÊ’u‚É‚æ‚Á‚Ä’Tõ”ÍˆÍ‚ªˆÙ‚È‚é‚½‚ßAŠe•ûŒü‚Å’Tõ‚ğ•ª‚¯‚é)
    /// </summary>
    public void Movement()
    {
        //‘OŒã•ûŒü
        for (int i = _piece.TileNumZ; i > 0; i--)
        {
            //ƒ}ƒX‚ª‹ó‚¢‚Ä‚¢‚½‚ç“®‚¯‚é
            if (_board.BoardInfo[i - 1][_piece.TileNumX] == 0)
            {
                _piece.Movable[i - 1, _piece.TileNumX] = true;
            }

            //‚Ç‚Á‚¿‚Ìƒ^[ƒ“‚©
            if (_manager.Phase == GameManager.PlayerPhase.White)
            {
                if (_board.BoardInfo[i - 1][_piece.TileNumX] < 0) //“G‹î(Šl‚ê‚éó‘Ô‚ÉØ‚è‘Ö‚¦‚Ä‚©‚ç’TõI—¹)
                {
                    GetableRay(_piece.TileNumX, i - 1);
                    break;
                }
                else //–¡•û‹î(‰½‚à‚¹‚¸‚É’TõI—¹)
                    break;
            }
            else if (_manager.Phase == GameManager.PlayerPhase.Black)
            {
                //“G‹î
                if (_board.BoardInfo[i - 1][_piece.TileNumX] > 0)
                {
                    GetableRay(_piece.TileNumX, i - 1);
                    break;
                }
                else
                    break;
            }
        }

        for (int i = _piece.TileNumZ; i < 7; i++)
        {
            if (_board.BoardInfo[i + 1][_piece.TileNumX] == 0)
            {
                _piece.Movable[i + 1, _piece.TileNumX] = true;
            }

            if (_manager.Phase == GameManager.PlayerPhase.White)
            {
                if (_board.BoardInfo[i + 1][_piece.TileNumX] < 0)
                {
                    GetableRay(_piece.TileNumX, i + 1);
                    break;
                }
                else
                    break;
            }
            else if (_manager.Phase == GameManager.PlayerPhase.Black)
            {
                if (_board.BoardInfo[i + 1][_piece.TileNumX] > 0)
                {
                    GetableRay(_piece.TileNumX, i + 1);
                    break;
                }
                else
                    break;
            }
        }
        //¶‰E•ûŒü
        for (int i = _piece.TileNumX; i < 7; i++)
        {
            if (_board.BoardInfo[_piece.TileNumZ][i + 1] == 0)
            {
                _piece.Movable[_piece.TileNumZ, i + 1] = true;
            }

            if (_manager.Phase == GameManager.PlayerPhase.White)
            {
                if (_board.BoardInfo[_piece.TileNumZ][i + 1] < 0)
                {
                    GetableRay(i + 1, _piece.TileNumZ);
                    break;
                }
                else
                    break;
            }
            else if (_manager.Phase == GameManager.PlayerPhase.Black)
            {
                if (_board.BoardInfo[_piece.TileNumZ][i + 1] > 0)
                {
                    GetableRay(i + 1, _piece.TileNumZ);
                    break;
                }
                else
                    break;
            }
        }

        for (int i = _piece.TileNumX; i > 0; i--)
        {
            if (_board.BoardInfo[_piece.TileNumZ][i - 1] == 0)
            {
                _piece.Movable[_piece.TileNumZ, i - 1] = true;
            }

            if (_manager.Phase == GameManager.PlayerPhase.White)
            {
                if (_board.BoardInfo[_piece.TileNumZ][i - 1] < 0)
                {
                    GetableRay(i - 1, _piece.TileNumZ);
                    break;
                }
                else
                    break;
            }
            else if (_manager.Phase == GameManager.PlayerPhase.Black)
            {
                if (_board.BoardInfo[_piece.TileNumZ][i - 1] > 0)
                {
                    GetableRay(i - 1, _piece.TileNumZ);
                    break;
                }
                else
                    break;
            }
        }
    }

    void GetableRay(int x, int z)
    {
        RaycastHit hit;

        //‚»‚Ì‹î‚ğŠl‚ê‚éó‘Ô‚ÉØ‚è‘Ö‚¦‚é
        if (Physics.Raycast(new Vector3(x, 5f, -z), Vector3.down, out hit, 20))
        {
            hit.collider.gameObject.GetComponent<MeshRenderer>().material = _getable;
        }
    }
}
