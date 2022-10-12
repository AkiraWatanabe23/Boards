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
    //�}�X�̈ړ��A�s�𔻒f����̂Ɏg���\��(true�Ȃ瓮����,�l���Afalse�Ȃ�o���Ȃ��̂悤�ȃC���[�W)
    public bool[,] Movable { get => _movable; set => _movable = value; }
    public GameObject SelectPiece { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        PieceNum = 0;
    }

    //��̌ʈړ������ւ̑J��
    public void PieceMovement()
    {
        //�����ŁA��U�S�Ă̋�̒T�������Z�b�g���鏈��������(?)
        //�����ꂼ���Movement()�ɏ����ƁA���ς������ɌĂ΂�Ȃ�����
        SearchReset();

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

    /// <summary> ��̐؂�ւ����ɒT����؂� </summary>
    void SearchReset()
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
