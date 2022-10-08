using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceManager : MonoBehaviour
{
    [SerializeField] Material _select;
    bool[,] _movable = new bool[8, 8];
    public Material Select { get => _select; set => _select = value; }
    public int PieceNum { get; set; }
    //�I��������̃}�X�ԍ����擾����(X,Z)
    public int TileNumX { get; set; }
    public int TileNumZ { get; set; }
    public bool[,] Movable { get => _movable; set => _movable = value; }
    public int ChangedPieceNum { get; set; }
    /// <summary> �I�����ꂽ�� </summary>
    public GameObject SelectedPiece { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        PieceNum = 0;
    }

    //��̌ʈړ������ւ̑J��
    public void PieceMovement()
    {
        switch (Mathf.Abs(PieceNum))
        {
            case 1:
                Debug.Log("Pawn");
                break;
            case 2:
                Debug.Log("Knight");
                GameObject.Find("Board").GetComponent<Knight>().Movement();
                break;
            case 3:
                Debug.Log("Bishop");
                GameObject.Find("Board").GetComponent<Bishop>().Movement();
                break;
            case 4:
                Debug.Log("Rook");
                GameObject.Find("Board").GetComponent<Rook>().Movement();
                break;
            case 5:
                Debug.Log("Queen");
                break;
            case 6:
                Debug.Log("King");
                break;
        }
    }

    /// <summary>
    /// ��̑I���A��I���Ɋւ��鏈��
    /// </summary>
    public void PieceSelect()
    {
        //���łɋ�I�΂�Ă����ꍇ...���̋���N���b�N�őI��Ώۂ�؂�ւ���
        //�I������Ă����̒T�����I��(�ؒf)���A�V�����I�΂ꂽ��̒T���ɐ؂�ւ���
        PieceMovement();
    }
}
