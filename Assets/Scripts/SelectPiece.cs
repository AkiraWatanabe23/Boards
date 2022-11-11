using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// 配置する駒を選ぶ処理(画面下の駒につける)
/// </summary>
public class SelectPiece : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Material _select;
    [SerializeField] private Material _back;
    private GameManager _manager;
    private TestLoad _board;

    // Start is called before the first frame update
    void Start()
    {
        _manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _board = GameObject.Find("Board").GetComponent<TestLoad>();
    }

    //マウスカーソルがオブジェクトに触れた場合の処理(クリック判定は関係ない)
    public void OnPointerEnter(PointerEventData eventData)
    {
        gameObject.GetComponent<MeshRenderer>().material = _select;
    }

    //マウスカーソルがオブジェクトから離れた場合の処理(クリック判定は関係ない)
    public void OnPointerExit(PointerEventData eventData)
    {
        gameObject.GetComponent<MeshRenderer>().material = _back;
    }

    //マウスクリックした場合の処理
    public void OnPointerClick(PointerEventData eventData)
    {
        if (gameObject.name == "Knight")
        {
            if (_manager.Phase == GameManager.PlayerPhase.White)
                _board.SetPiece = _board.Pieces[1];
            else if (_manager.Phase == GameManager.PlayerPhase.Black)
                _board.SetPiece = _board.Pieces[7];

            Debug.Log("Knight を置きます");
        }
        else if (gameObject.name == "Bishop")
        {
            if (_manager.Phase == GameManager.PlayerPhase.White)
                _board.SetPiece = _board.Pieces[2];
            else if (_manager.Phase == GameManager.PlayerPhase.Black)
                _board.SetPiece = _board.Pieces[8];

            Debug.Log("Bishop を置きます");
        }
        else if (gameObject.name == "Rook")
        {
            if (_manager.Phase == GameManager.PlayerPhase.White)
                _board.SetPiece = _board.Pieces[3];
            else if (_manager.Phase == GameManager.PlayerPhase.Black)
                _board.SetPiece = _board.Pieces[9];

            Debug.Log("Rook を置きます");
        }
    }
}
