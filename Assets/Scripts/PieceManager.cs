using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceManager : MonoBehaviour
{
    [SerializeField] GameManager _manager;
    [SerializeField] TestLoad _board;
    [SerializeField] Material _white;
    [SerializeField] Material _black;
    [SerializeField] Material _select;
    [SerializeField] GameObject _selectPiece;
    bool[,] _movable = new bool[8, 8];
    public Material White { get => _white; set => _white = value; }
    public Material Black { get => _black; set => _black = value; }
    /// <summary> ���I�񂾎��ɐF��ς��� </summary>
    public Material Select { get => _select; set => _select = value; }
    /// <summary> ���ݑI�΂�Ă���� </summary>
    public GameObject SelectPiece { get => _selectPiece; set => _selectPiece = value; }
    /// <summary> ��Ɋ���U�����ԍ�(�ʒT�������Ɏg��) </summary>
    public int PieceNum { get; set; }
    //�I��������̃}�X�ԍ����擾����(X,Z)
    public int TileNumX { get; set; }
    public int TileNumZ { get; set; }
    /// <summary> �}�X�̈ړ��A�s�𔻒f����̂Ɏg���\��
    /// (true�Ȃ瓮����,�l���Afalse�Ȃ�o���Ȃ��̂悤�ȃC���[�W) </summary>
    public bool[,] Movable { get => _movable; set => _movable = value; }

    // Start is called before the first frame update
    void Start()
    {
        PieceNum = 0;
    }

    //��̌ʈړ������ւ̑J��
    public void PieceMovement()
    {
        SearchReset();
        //�����ŁA��U�S�Ă̋�̒T�������Z�b�g���鏈��������
        //�����ꂼ���Movement()�ɏ����ƁA���ς������ɌĂ΂�Ȃ�����

        switch (Mathf.Abs(PieceNum))
        {
            case 1:
                Debug.Log("Pawn");
                break;
            case 2:
                Debug.Log("Knight");
                GetComponent<Knight>().Movement();
                break;
            case 3:
                Debug.Log("Bishop");
                GetComponent<Bishop>().Movement();
                break;
            case 4:
                Debug.Log("Rook");
                GetComponent<Rook>().Movement();
                break;
            case 5:
                Debug.Log("Queen");
                break;
            case 6:
                Debug.Log("King");
                GetComponent<King>().Movement();
                break;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="selected">�I�΂ꂽ��</param>
    public void PieceSelect(GameObject selected)
    {
        SelectPiece = selected;
        SelectPiece.GetComponent<MeshRenderer>().material = Select;
        PieceNum = (int)selected.GetComponent<PieceMove>().Type;
        TileNumX = Mathf.Abs((int)selected.transform.position.x);
        TileNumZ = Mathf.Abs((int)selected.transform.position.z);
        PieceMovement();
    }

    /// <summary>
    /// �}�X�̈ړ�
    /// </summary>
    /// <param name="x">�ړ��I�����ꂽ�}�X��x���W</param>
    /// <param name="z">�ړ��I�����ꂽ�}�X��z���W</param>
    /// <param name="square">�ړ��I�����ꂽ�}�X</param>
    public void MoveToSquare(int x, int z, GameObject square)
    {
        if (SelectPiece != null && _board.Tiles[x, z].GetComponent<MeshRenderer>().enabled == true)
        {
            //���position�����̃}�X�Ɉړ������āA�}�X�̏����X�V����
            SelectPiece.transform.position = square.transform.position + new Vector3(0, 0.1f, 0);
            //���X������}�X��0�ɂȂ�
            //�ړ����Ă����}�X�͂�����̔ԍ��ɕϊ������
            //��̑I����Ԃ�؂�
            SelectPiece.GetComponent<Renderer>().material
                = SelectPiece.CompareTag("WhitePiece") ? White : Black;
            SelectPiece = null;
            PieceNum = 0;
            //�^�[����؂�ւ���(�������A������)
            _manager.Phase = _manager.Phase == GameManager.PlayerPhase.White
                ? GameManager.PlayerPhase.Black : GameManager.PlayerPhase.White;
        }
    }

    /// <summary> ��̐؂�ւ����ɂ���܂őI��ł�����̒T����؂� </summary>
    public void SearchReset()
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                Movable[i, j] = false;
            }
        }
    }
}
