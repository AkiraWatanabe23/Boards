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
        GameObject selectPiece = null;
        var go = eventData.pointerCurrentRaycast.gameObject;

        //駒の選択
        //現在...駒が選ばれていない or 選択状態の駒と新しく選んだ駒が異なる
        //※駒を選べる条件...駒が選ばれていない or 自分のターンに自分の駒を選ぶこと
        if (_piece.PieceNum == 0 || selectPiece != go)
        {
            //選んだ駒と選択状態の駒をそろえる
            selectPiece = go;
            //自分のターンに自分の駒を選んだか判定
            if (gameObject.CompareTag("WhitePiece") && _manager.Phase == GameManager.PlayerPhase.White ||
                gameObject.CompareTag("BlackPiece") && _manager.Phase == GameManager.PlayerPhase.Black)
            {
                if (_piece.PieceNum == 0)
                {
                    _piece.PieceNum = (int)gameObject.GetComponent<PieceMove>().Type;
                    _piece.TileNumX = Mathf.Abs((int)gameObject.transform.position.x);
                    _piece.TileNumZ = Mathf.Abs((int)gameObject.transform.position.z);
                    _piece.PieceMovement();
                    Debug.Log($"{go} を選びました");
                }
                else if (_piece.PieceNum != 0)
                {
                    _piece.ChangedPieceNum = (int)gameObject.GetComponent<PieceMove>().Type;
                    _piece.PieceSelect();
                    Debug.Log("選ぶ駒をに切り替えます");
                }
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
    }

    // Start is called before the first frame update
    void Start()
    {
        _piece = GetComponentInParent<PieceManager>();
        _manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
