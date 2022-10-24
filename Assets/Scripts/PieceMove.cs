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
    /// ��̑I������(��I��������)
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerClick(PointerEventData eventData)
    {
        var go = eventData.pointerCurrentRaycast.gameObject;

        //��̑I��
        //����...��I�΂�Ă��Ȃ� or �I����Ԃ̋�ƐV�����I�񂾋�قȂ�
        //�����I�ׂ����...��I�΂�Ă��Ȃ� or �����̃^�[���Ɏ����̋��I�Ԃ���
        if (_piece.PieceNum == 0 || _piece.SelectPiece != go)
        {
            //�����̃^�[���Ɏ����̋��I�񂾂�����
            if (gameObject.CompareTag("WhitePiece") && _manager.Phase == GameManager.PlayerPhase.White ||
                gameObject.CompareTag("BlackPiece") && _manager.Phase == GameManager.PlayerPhase.Black)
            {
                //��I�΂�Ă��Ȃ������ꍇ
                if (_piece.PieceNum == 0)
                {
                    Debug.Log($"{go} ��I�т܂���");
                }
                //��̑I����؂�ւ���ꍇ
                else if (_piece.PieceNum != 0)
                {
                    if (_piece.SelectPiece.CompareTag("WhitePiece"))
                    {
                        //���؂�ւ������ɑI��ł��Ȃ���Ԃɖ߂�����(���݂͐F��߂�����)
                        _piece.SelectPiece.GetComponent<Renderer>().material = _piece.White;
                    }
                    else if (_piece.SelectPiece.CompareTag("BlackPiece"))
                    {
                        _piece.SelectPiece.GetComponent<Renderer>().material = _piece.Black;
                    }
                    Debug.Log("�I�ԋ��؂�ւ��܂�");
                }
                _piece.PieceSelect(gameObject);
            }
            //����̃^�[�������� or ���^�[���ɑ���̋��I��
            else
            {
                Debug.Log("���݂͑���̃^�[���ł�");
            }
        }
        else
        {
            Debug.Log("���łɋ�I����Ԃł�");
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
