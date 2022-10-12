using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : MonoBehaviour
{
    [SerializeField] Material _movable;
    [SerializeField] Material _getable;
    GameManager _manager;
    PieceManager _piece;
    TestLoad _board;
    //‘OŒã¶‰E•ûŒü‚Ìƒ}ƒX‚©‚ç‚ÌˆÚ“®·
    int[] ZnumVer = new int[] { -1, 1 };
    int[] XnumVer = new int[] { 1, -1 };
    int[] ZnumHor = new int[] { -1, 1 };
    int[] XnumHor = new int[] { 1, -1, 1, -1 };

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

    public void Movement()
    {
        //‘OŒã
        for (int i = 0; i < ZnumVer.Length; i++)
        {
            if (_board.BoardInfo[_piece.TileNumZ + ZnumVer[i]][_piece.TileNumX] == 0)
            {
                _piece.Movable[_piece.TileNumZ + ZnumVer[i], _piece.TileNumX] = true;
            }

            //‚Ç‚Á‚¿‚Ìƒ^[ƒ“‚©
            if (_manager.Phase == GameManager.PlayerPhase.White)
            {
                //“G‹î
                if (_board.BoardInfo[_piece.TileNumZ + ZnumVer[i]][_piece.TileNumX] < 0)
                {
                    //‚»‚Ì‹î‚ğŠl‚ê‚éó‘Ô‚ÉØ‚è‘Ö‚¦‚é
                }
            }
            else if (_manager.Phase == GameManager.PlayerPhase.Black)
            {
                //“G‹î
                if (_board.BoardInfo[_piece.TileNumZ + ZnumVer[i]][_piece.TileNumX] > 0)
                {
                    //‚»‚Ì‹î‚ğŠl‚ê‚éó‘Ô‚ÉØ‚è‘Ö‚¦‚é
                }
            }
        }
        //¶‰E
        for (int i = 0; i < XnumVer.Length; i++)
        {
            if (_board.BoardInfo[_piece.TileNumZ][_piece.TileNumX + XnumVer[i]] == 0)
            {
                _piece.Movable[_piece.TileNumZ, _piece.TileNumX + XnumVer[i]] = true;
            }

            //‚Ç‚Á‚¿‚Ìƒ^[ƒ“‚©
            if (_manager.Phase == GameManager.PlayerPhase.White)
            {
                //“G‹î
                if (_board.BoardInfo[_piece.TileNumZ][_piece.TileNumX + XnumVer[i]] < 0)
                {
                    //‚»‚Ì‹î‚ğŠl‚ê‚éó‘Ô‚ÉØ‚è‘Ö‚¦‚é
                }
            }
            else if (_manager.Phase == GameManager.PlayerPhase.Black)
            {
                //“G‹î
                if (_board.BoardInfo[_piece.TileNumZ][_piece.TileNumX + XnumVer[i]] > 0)
                {
                    //‚»‚Ì‹î‚ğŠl‚ê‚éó‘Ô‚ÉØ‚è‘Ö‚¦‚é
                }
            }
        }
        //Î‚ß
        for (int i = 0; i < XnumHor.Length; i++)
        {
            if (i <= 1)
            {
                if (_board.BoardInfo[_piece.TileNumZ + ZnumHor[0]][_piece.TileNumX + XnumHor[i]] == 0)
                {
                    _piece.Movable[_piece.TileNumZ + ZnumHor[0], _piece.TileNumX + XnumHor[i]] = true;
                }

                //‚Ç‚Á‚¿‚Ìƒ^[ƒ“‚©
                if (_manager.Phase == GameManager.PlayerPhase.White)
                {
                    //“G‹î
                    if (_board.BoardInfo[_piece.TileNumZ + ZnumHor[0]][_piece.TileNumX + XnumHor[i]] < 0)
                    {
                        //‚»‚Ì‹î‚ğŠl‚ê‚éó‘Ô‚ÉØ‚è‘Ö‚¦‚é
                    }
                }
                else if (_manager.Phase == GameManager.PlayerPhase.Black)
                {
                    //“G‹î
                    if (_board.BoardInfo[_piece.TileNumZ + ZnumHor[0]][_piece.TileNumX + XnumHor[i]] > 0)
                    {
                        //‚»‚Ì‹î‚ğŠl‚ê‚éó‘Ô‚ÉØ‚è‘Ö‚¦‚é
                    }
                }
            }
            else
            {
                if (_board.BoardInfo[_piece.TileNumZ + ZnumHor[1]][_piece.TileNumX + XnumHor[i]] == 0)
                {
                    _piece.Movable[_piece.TileNumZ + ZnumHor[1], _piece.TileNumX + XnumHor[i]] = true;
                }

                //‚Ç‚Á‚¿‚Ìƒ^[ƒ“‚©
                if (_manager.Phase == GameManager.PlayerPhase.White)
                {
                    //“G‹î
                    if (_board.BoardInfo[_piece.TileNumZ + ZnumHor[1]][_piece.TileNumX + XnumHor[i]] < 0)
                    {
                        //‚»‚Ì‹î‚ğŠl‚ê‚éó‘Ô‚ÉØ‚è‘Ö‚¦‚é
                    }
                }
                else if (_manager.Phase == GameManager.PlayerPhase.Black)
                {
                    //“G‹î
                    if (_board.BoardInfo[_piece.TileNumZ + ZnumHor[1]][_piece.TileNumX + XnumHor[i]] > 0)
                    {
                        //‚»‚Ì‹î‚ğŠl‚ê‚éó‘Ô‚ÉØ‚è‘Ö‚¦‚é
                    }
                }
            }
        }
    }
}
