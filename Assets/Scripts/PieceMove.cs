using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PieceMove : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] PieceType _type;
    PieceManager _piece;
    GameManager _manager;
    public PieceType Type { get => _type; set => _type = value; }

    /// <summary>
    /// 駒の選択処理(非選択もつける)
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerClick(PointerEventData eventData)
    {
        var go = eventData.pointerCurrentRaycast.gameObject;

        //駒の選択
        //現在...駒が選ばれていない or 選択状態の駒と新しく選んだ駒が異なる
        //※駒を選べる条件...駒が選ばれていない or 自分のターンに自分の駒を選ぶこと
        if (_piece.PieceNum == 0 || _piece.SelectPiece != go)
        {
            //自分のターンに自分の駒を選んだか判定
            if (gameObject.CompareTag("WhitePiece") && _manager.Phase == GameManager.PlayerPhase.White ||
                gameObject.CompareTag("BlackPiece") && _manager.Phase == GameManager.PlayerPhase.Black)
            {
                //駒が選ばれていなかった場合
                if (_piece.PieceNum == 0)
                {
                    Debug.Log($"{go} を選びました");
                }
                //駒の選択を切り替える場合
                else if (_piece.PieceNum != 0)
                {
                    if (_piece.SelectPiece.CompareTag("WhitePiece"))
                    {
                        //駒を切り替えた時に選んでいない状態に戻す処理(現在は色を戻すだけ)
                        _piece.SelectPiece.GetComponent<Renderer>().material = _piece.White;
                    }
                    else if (_piece.SelectPiece.CompareTag("BlackPiece"))
                    {
                        _piece.SelectPiece.GetComponent<Renderer>().material = _piece.Black;
                    }
                    Debug.Log("選ぶ駒を切り替えます");
                }
                _piece.PieceSelect(gameObject);
            }
            //相手のターンだった or 自ターンに相手の駒を選んだ
            else
            {
                Debug.Log("現在は相手のターンです");
            }
        }
        else
        {
            Debug.Log("すでに駒が選択状態です");
        }

        if (_piece.SelectPiece != null)
        {

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _piece = GetComponentInParent<PieceManager>();
        _manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public enum PieceType
    {
        B_King = -6,
        B_Queen,
        B_Rook,
        B_Bishop,
        B_Knight,
        B_Pawn,
        W_Pawn = 1,
        W_Knight,
        W_Bishop,
        W_Rook,
        W_Queen,
        W_King,
    }
}
