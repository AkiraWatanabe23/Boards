using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    //�}�X�ɂǂ̋���邩
    [SerializeField] TileState _state = TileState.None;
    //�G���[�̗��R��������Ȃ�
    //public TileState State { get => _state; set => _state = value; }

    // Start is called before the first frame update
    void Start()
    {
        StateCheck();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //�}�X�̏�Ԃ𒲂ׂ�
    void StateCheck()
    {

    }

    /// <summary> �}�X�̏�� </summary>
    enum TileState
    {
        B_King = -6,
        B_Queen,
        B_Rook,
        B_Bishop,
        B_Knight,
        B_Pawn,
        None = 0,
        W_Pawn,
        W_Knight,
        W_Bishop,
        W_Rook,
        W_Queen,
        W_King,
    }
}
