using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour, IPointerClickHandler
{
    PieceManager _piece;
    GameManager _manager;
    TestLoad _board;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (_piece.SelectPiece != null) //ここに、動けるマスであることの条件も書く
        {
            //駒のpositionをこのマスに移動させて、マスの情報を更新する
            //元々駒がいたマスは0になる
            //移動してきたマスはきた駒の番号に変換される
            _piece.SelectPiece = null;
            //ターンを切り替える
        }
        else
        {
            Debug.Log("ここには動けない");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _piece = GameObject.Find("Piece").GetComponent<PieceManager>();
        _manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _board = GameObject.Find("Board").GetComponent<TestLoad>();
    }

    //マスの状態を調べる
    void StateCheck()
    {
        //駒の有無、位置の変更等で_board.BoardInfo[][] の値を更新する
    }
}
