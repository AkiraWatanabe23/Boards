using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bishop : MonoBehaviour
{
    [SerializeField] Material _movable;
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

    public void Movement()
    {
        //‘O•ûŒü
        int j = _piece.TileNumX; //¶‘O’Tõ—p
        int k = _piece.TileNumX; //‰E‘O’Tõ—p
        for (int i = _piece.TileNumZ; i > 0; i--)
        {
            //¶‘O
            if (_board.BoardInfo[i - 1][j - 1] == 0)
            {
                _board.Tiles[i - 1, j - 1].gameObject.GetComponent<MeshRenderer>().enabled = true;
                if (j == 1) //IndexOutOfRange –h~
                    break;
            }

            //‚Ç‚Á‚¿‚Ìƒ^[ƒ“‚©
            if (_manager.Phase == GameManager.PlayerPhase.White)
            {
                //‹î‚ª‚ ‚ê‚Î’TõI—¹
                //“G‹î
                if (_board.BoardInfo[i - 1][j - 1] < 0)
                {
                    //‚»‚Ì‹î‚ğŠl‚ê‚éó‘Ô‚É‚µ‚Ä’TõI—¹
                    break;
                }
                //–¡•û‹î(‚»‚Ì“_‚Å’TõI—¹)
                else if (_board.BoardInfo[i - 1][j - 1] > 0)
                    break;
            }
            else if (_manager.Phase == GameManager.PlayerPhase.Black)
            {
                //‹î‚ª‚ ‚ê‚Î’TõI—¹
                //“G‹î
                if (_board.BoardInfo[i - 1][j - 1] > 0)
                {
                    //‚»‚Ì‹î‚ğŠl‚ê‚éó‘Ô‚É‚µ‚Ä’TõI—¹
                    break;
                }
                //–¡•û‹î
                else if (_board.BoardInfo[i - 1][j - 1] < 0)
                    break;
            }
            j--;
        }
        for (int i = _piece.TileNumZ; i > 0; i--)
        {
            //‰E‘O
            if (_board.BoardInfo[i - 1][k + 1] == 0)
            {
                _board.Tiles[i - 1, k + 1].gameObject.GetComponent<MeshRenderer>().enabled = true;
                if (k == 6)
                    break;
            }

            //‚Ç‚Á‚¿‚Ìƒ^[ƒ“‚©
            if (_manager.Phase == GameManager.PlayerPhase.White)
            {
                //‹î‚ª‚ ‚ê‚Î’TõI—¹
                //“G‹î
                if (_board.BoardInfo[i - 1][k + 1] < 0)
                {
                    //‚»‚Ì‹î‚ğŠl‚ê‚éó‘Ô‚É‚µ‚Ä’TõI—¹
                    break;
                }
                //–¡•û‹î(‚»‚Ì“_‚Å’TõI—¹)
                else if (_board.BoardInfo[i - 1][k + 1] > 0)
                    break;
            }
            else if (_manager.Phase == GameManager.PlayerPhase.Black)
            {
                //‹î‚ª‚ ‚ê‚Î’TõI—¹
                //“G‹î
                if (_board.BoardInfo[i - 1][k + 1] > 0)
                {
                    //‚»‚Ì‹î‚ğŠl‚ê‚éó‘Ô‚É‚µ‚Ä’TõI—¹
                    break;
                }
                //–¡•û‹î
                else if (_board.BoardInfo[i - 1][k + 1] < 0)
                    break;
            }
            k++;
        }

        //Œã‚ë•ûŒü
        j = _piece.TileNumX; //¶Œã‚ë
        k = _piece.TileNumX; //‰EŒã‚ë
        for (int i = _piece.TileNumZ; i < 7; i++)
        {
            //¶Œã‚ë
            if (_board.BoardInfo[i + 1][j - 1] == 0)
            {
                _board.Tiles[i + 1, j - 1].gameObject.GetComponent<MeshRenderer>().enabled = true;
                if (j == 1)
                    break;
            }

            //‚Ç‚Á‚¿‚Ìƒ^[ƒ“‚©
            if (_manager.Phase == GameManager.PlayerPhase.White)
            {
                //‹î‚ª‚ ‚ê‚Î’TõI—¹
                //“G‹î
                if (_board.BoardInfo[i + 1][j - 1] < 0)
                {
                    //‚»‚Ì‹î‚ğŠl‚ê‚éó‘Ô‚É‚µ‚Ä’TõI—¹
                    break;
                }
                //–¡•û‹î(‚»‚Ì“_‚Å’TõI—¹)
                else if (_board.BoardInfo[i + 1][j - 1] > 0)
                    break;
            }
            else if (_manager.Phase == GameManager.PlayerPhase.Black)
            {
                //‹î‚ª‚ ‚ê‚Î’TõI—¹
                //“G‹î
                if (_board.BoardInfo[i + 1][j - 1] > 0)
                {
                    //‚»‚Ì‹î‚ğŠl‚ê‚éó‘Ô‚É‚µ‚Ä’TõI—¹
                    break;
                }
                //–¡•û‹î
                else if (_board.BoardInfo[i + 1][j - 1] < 0)
                    break;
            }
            j--;
        }
        for (int i = _piece.TileNumZ; i < 7; i++)
        {
            //‰EŒã‚ë
            if (_board.BoardInfo[i + 1][k + 1] == 0)
            {
                _board.Tiles[i + 1, k + 1].gameObject.GetComponent<MeshRenderer>().enabled = true;
                if (k == 6)
                    break;
            }

            //‚Ç‚Á‚¿‚Ìƒ^[ƒ“‚©
            if (_manager.Phase == GameManager.PlayerPhase.White)
            {
                //‹î‚ª‚ ‚ê‚Î’TõI—¹
                //“G‹î
                if (_board.BoardInfo[i + 1][k + 1] < 0)
                {
                    //‚»‚Ì‹î‚ğŠl‚ê‚éó‘Ô‚É‚µ‚Ä’TõI—¹
                    break;
                }
                //–¡•û‹î(‚»‚Ì“_‚Å’TõI—¹)
                else if (_board.BoardInfo[i + 1][k + 1] > 0)
                    break;
            }
            else if (_manager.Phase == GameManager.PlayerPhase.Black)
            {
                //‹î‚ª‚ ‚ê‚Î’TõI—¹
                //“G‹î
                if (_board.BoardInfo[i + 1][k + 1] > 0)
                {
                    //‚»‚Ì‹î‚ğŠl‚ê‚éó‘Ô‚É‚µ‚Ä’TõI—¹
                    break;
                }
                //–¡•û‹î
                else if (_board.BoardInfo[i + 1][k + 1] < 0)
                    break;
            }
            k++;
        }
    }
}
