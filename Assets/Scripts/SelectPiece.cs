using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectPiece : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] Material _select;
    [SerializeField] Material _back;
    GameManager _manager;
    TestLoad _board;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (gameObject.name == "Knight")
        {
            if (_manager.Phase == GameManager.PlayerPhase.White)
                _board.SelectPiece = _board.Pieces[1];
            else if (_manager.Phase == GameManager.PlayerPhase.Black)
                _board.SelectPiece = _board.Pieces[7];

            Debug.Log("追加");

        }
        else if (gameObject.name == "Bishop")
        {
            if (_manager.Phase == GameManager.PlayerPhase.White)
                _board.SelectPiece = _board.Pieces[2];
            else if (_manager.Phase == GameManager.PlayerPhase.Black)
                _board.SelectPiece = _board.Pieces[8];

            Debug.Log("追加");
        }
        else if (gameObject.name == "Rook")
        {
            if (_manager.Phase == GameManager.PlayerPhase.White)
                _board.SelectPiece = _board.Pieces[3];
            else if (_manager.Phase == GameManager.PlayerPhase.Black)
                _board.SelectPiece = _board.Pieces[9];

            Debug.Log("追加");
        }
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

    // Start is called before the first frame update
    void Start()
    {
        _manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _board = GameObject.Find("Board").GetComponent<TestLoad>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
