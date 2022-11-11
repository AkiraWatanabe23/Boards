using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// �z�u������I�ԏ���(��ʉ��̋�ɂ���)
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

    //�}�E�X�J�[�\�����I�u�W�F�N�g�ɐG�ꂽ�ꍇ�̏���(�N���b�N����͊֌W�Ȃ�)
    public void OnPointerEnter(PointerEventData eventData)
    {
        gameObject.GetComponent<MeshRenderer>().material = _select;
    }

    //�}�E�X�J�[�\�����I�u�W�F�N�g���痣�ꂽ�ꍇ�̏���(�N���b�N����͊֌W�Ȃ�)
    public void OnPointerExit(PointerEventData eventData)
    {
        gameObject.GetComponent<MeshRenderer>().material = _back;
    }

    //�}�E�X�N���b�N�����ꍇ�̏���
    public void OnPointerClick(PointerEventData eventData)
    {
        if (gameObject.name == "Knight")
        {
            if (_manager.Phase == GameManager.PlayerPhase.White)
                _board.SetPiece = _board.Pieces[1];
            else if (_manager.Phase == GameManager.PlayerPhase.Black)
                _board.SetPiece = _board.Pieces[7];

            Debug.Log("Knight ��u���܂�");
        }
        else if (gameObject.name == "Bishop")
        {
            if (_manager.Phase == GameManager.PlayerPhase.White)
                _board.SetPiece = _board.Pieces[2];
            else if (_manager.Phase == GameManager.PlayerPhase.Black)
                _board.SetPiece = _board.Pieces[8];

            Debug.Log("Bishop ��u���܂�");
        }
        else if (gameObject.name == "Rook")
        {
            if (_manager.Phase == GameManager.PlayerPhase.White)
                _board.SetPiece = _board.Pieces[3];
            else if (_manager.Phase == GameManager.PlayerPhase.Black)
                _board.SetPiece = _board.Pieces[9];

            Debug.Log("Rook ��u���܂�");
        }
    }
}
