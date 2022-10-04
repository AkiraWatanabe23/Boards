using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PieceMove : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] PieceType _type;
    public PieceType Type { get => _type; set => _type = value; }
    public PieceManager Piece { get; set; }
    public GameManager Manager { get; set; }

    /// <summary>
    /// 駒の選択処理(非選択もつける)
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerClick(PointerEventData eventData)
    {
        if (Piece.PieceNum == 0)
        {
            if (gameObject.CompareTag("WhitePiece") && Manager.Phase == GameManager.PlayerPhase.White ||
                gameObject.CompareTag("BlackPiece") && Manager.Phase == GameManager.PlayerPhase.Black)
            {
                Piece.PieceNum = (int)gameObject.GetComponent<PieceMove>().Type;
                Debug.Log(Piece.PieceNum);
            }
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
        Piece = GetComponentInParent<PieceManager>();
        Manager = GameObject.Find("GameManager").GetComponent<GameManager>();
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
