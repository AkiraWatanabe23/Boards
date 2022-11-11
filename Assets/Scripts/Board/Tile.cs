using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour, IPointerClickHandler
{
    private PieceManager _piece;

    /// <summary>
    /// 選択された駒を移動させる処理
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerClick(PointerEventData eventData)
    {
        //↓なにか駒が選択されていて、クリックされたマスが探索範囲内なら
        int x = Mathf.Abs((int)gameObject.transform.position.x);
        int z = Mathf.Abs((int)gameObject.transform.position.z);

        //選択状態の駒を指定したマスに移動させる
        _piece.MoveToSquare(x, z, gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        _piece = GameObject.Find("Piece").GetComponent<PieceManager>();
    }

    /// <summary> マスの状態を調べる </summary>
    void StateCheck()
    {
        //駒の有無、位置の変更等で_board.BoardInfo[][] の値を更新する
    }
}
