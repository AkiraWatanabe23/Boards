using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour, IPointerClickHandler
{
    private PieceManager _piece;

    /// <summary>
    /// �I�����ꂽ����ړ������鏈��
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerClick(PointerEventData eventData)
    {
        //���Ȃɂ���I������Ă��āA�N���b�N���ꂽ�}�X���T���͈͓��Ȃ�
        int x = Mathf.Abs((int)gameObject.transform.position.x);
        int z = Mathf.Abs((int)gameObject.transform.position.z);

        //�I����Ԃ̋���w�肵���}�X�Ɉړ�������
        _piece.MoveToSquare(x, z, gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        _piece = GameObject.Find("Piece").GetComponent<PieceManager>();
    }

    /// <summary> �}�X�̏�Ԃ𒲂ׂ� </summary>
    void StateCheck()
    {
        //��̗L���A�ʒu�̕ύX����_board.BoardInfo[][] �̒l���X�V����
    }
}
