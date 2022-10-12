using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceManager : MonoBehaviour
{
    [SerializeField] Material _select;
    [SerializeField] GameObject _selectPiece;
    bool[,] _movable = new bool[8, 8];
    //駒を選んだ時に色を変える
    public Material Select { get => _select; set => _select = value; }
    //現在選ばれている駒
    public GameObject SelectPiece { get => _selectPiece; set => _selectPiece = value; }
    //駒に割り振った番号(個別探索処理に使う)
    public int PieceNum { get; set; }
    //選択した駒のマス番号を取得する(X,Z)
    public int TileNumX { get; set; }
    public int TileNumZ { get; set; }
    //マスの移動可、不可を判断するのに使う予定(trueなら動ける,獲れる、falseなら出来ないのようなイメージ)
    public bool[,] Movable { get => _movable; set => _movable = value; }

    // Start is called before the first frame update
    void Start()
    {
        PieceNum = 0;
    }

    //駒の個別移動処理への遷移
    public void PieceMovement()
    {
        SearchReset();
        //ここで、一旦全ての駒の探索をリセットする処理を書く(?)
        //↑それぞれのMovement()に書くと、駒を変えた時に呼ばれないため

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

    /// <summary> 駒の切り替え時に探索を切る </summary>
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
