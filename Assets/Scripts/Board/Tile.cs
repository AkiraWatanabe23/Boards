using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour, IPointerClickHandler
{
    PieceManager _piece;
    GameManager _manager;
    TestLoad _board;

    public void OnPointerClick(PointerEventData eventData)
    {
        //���Ȃɂ���I������Ă��āA�N���b�N���ꂽ�}�X���T���͈͓��Ȃ�
        int x = Mathf.Abs((int)gameObject.transform.position.x);
        int z = Mathf.Abs((int)gameObject.transform.position.z);

        if (_piece.SelectPiece != null && _board.Tiles[x, z].GetComponent<MeshRenderer>().enabled == true)
        {
            //���position�����̃}�X�Ɉړ������āA�}�X�̏����X�V����
            _piece.SelectPiece.transform.position = gameObject.transform.position;
            //���X������}�X��0�ɂȂ�
            //�ړ����Ă����}�X�͂�����̔ԍ��ɕϊ������
            //��̑I����Ԃ�؂�
            _piece.SelectPiece = null;
            _piece.PieceNum = 0;
            //�^�[����؂�ւ���
            _manager.Phase = _manager.Phase == GameManager.PlayerPhase.White
                ? GameManager.PlayerPhase.Black : GameManager.PlayerPhase.White;
        }
        else
        {
            Debug.Log($"�����ɂ͓����Ȃ� {x}, {z}");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _piece = GameObject.Find("Piece").GetComponent<PieceManager>();
        _manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _board = GameObject.Find("Board").GetComponent<TestLoad>();
    }

    //�}�X�̏�Ԃ𒲂ׂ�
    void StateCheck()
    {
        //��̗L���A�ʒu�̕ύX����_board.BoardInfo[][] �̒l���X�V����
    }
}
