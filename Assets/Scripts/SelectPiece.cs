using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectPiece : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] Material _select;
    [SerializeField] Material _back;

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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
