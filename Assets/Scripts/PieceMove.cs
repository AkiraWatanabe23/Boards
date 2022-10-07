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
        GameObject selectPiece = null;
        var go = eventData.pointerCurrentRaycast.gameObject;

        //��̑I��
        //����...��I�΂�Ă��Ȃ� or �I����Ԃ̋�ƐV�����I�񂾋�قȂ�
        //�����I�ׂ����...��I�΂�Ă��Ȃ� or �����̃^�[���Ɏ����̋��I�Ԃ���
        if (_piece.PieceNum == 0 || selectPiece != go)
        {
            //�I�񂾋�ƑI����Ԃ̋�����낦��
            selectPiece = go;
            //�����̃^�[���Ɏ����̋��I�񂾂�����
            if (gameObject.CompareTag("WhitePiece") && _manager.Phase == GameManager.PlayerPhase.White ||
                gameObject.CompareTag("BlackPiece") && _manager.Phase == GameManager.PlayerPhase.Black)
            {
                if (_piece.PieceNum == 0)
                {
                    _piece.PieceNum = (int)gameObject.GetComponent<PieceMove>().Type;
                    _piece.TileNumX = Mathf.Abs((int)gameObject.transform.position.x);
                    _piece.TileNumZ = Mathf.Abs((int)gameObject.transform.position.z);
                    _piece.PieceMovement();
                    Debug.Log($"{go} ��I�т܂���");
                }
                else if (_piece.PieceNum != 0)
                {
                    _piece.ChangedPieceNum = (int)gameObject.GetComponent<PieceMove>().Type;
                    _piece.PieceSelect();
                    Debug.Log("�I�ԋ���ɐ؂�ւ��܂�");
                }
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
