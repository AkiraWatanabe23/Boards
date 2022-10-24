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
        //↓なにか駒が選択されていて、クリックされたマスが探索範囲内なら
        int x = Mathf.Abs((int)gameObject.transform.position.x);
        int z = Mathf.Abs((int)gameObject.transform.position.z);

        if (_piece.SelectPiece != null && _board.Tiles[x, z].GetComponent<MeshRenderer>().enabled == true)
        {
            //駒のpositionをこのマスに移動させて、マスの情報を更新する
            _piece.SelectPiece.transform.position = gameObject.transform.position;
            //元々駒がいたマスは0になる
            //移動してきたマスはきた駒の番号に変換される
            //駒の選択状態を切る
            _piece.SelectPiece = null;
            _piece.PieceNum = 0;
            //ターンを切り替える
            _manager.Phase = _manager.Phase == GameManager.PlayerPhase.White
                ? GameManager.PlayerPhase.Black : GameManager.PlayerPhase.White;
        }
        else
        {
            Debug.Log($"ここには動けない {x}, {z}");
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
