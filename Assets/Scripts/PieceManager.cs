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
    /// <summary> 駒を選んだ時に色を変える </summary>
    public Material Select { get => _select; set => _select = value; }
    /// <summary> 現在選ばれている駒 </summary>
    public GameObject SelectPiece { get => _selectPiece; set => _selectPiece = value; }
    /// <summary> 駒に割り振った番号(個別探索処理に使う) </summary>
    public int PieceNum { get; set; }
    //選択した駒のマス番号を取得する(X,Z)
    public int TileNumX { get; set; }
    public int TileNumZ { get; set; }
    /// <summary> マスの移動可、不可を判断するのに使う予定
    /// (trueなら動ける,獲れる、falseなら出来ないのようなイメージ) </summary>
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
        //ここで、一旦全ての駒の探索をリセットする処理を書く
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

    /// <summary>
    /// 
    /// </summary>
    /// <param name="selected">選ばれた駒</param>
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
    /// マスの移動
    /// </summary>
    /// <param name="x">移動選択されたマスのx座標</param>
    /// <param name="z">移動選択されたマスのz座標</param>
    /// <param name="square">移動選択されたマス</param>
    public void MoveToSquare(int x, int z, GameObject square)
    {
        if (SelectPiece != null && _board.Tiles[z, x].GetComponent<MeshRenderer>().enabled == true)
        {
            //駒のpositionをこのマスに移動させて、マスの情報を更新する
            SelectPiece.transform.position = square.transform.position + new Vector3(0, 0.1f, 0);
            //元々駒がいたマスは0になる
            //移動してきたマスはきた駒の番号に変換される
            //駒の選択状態を切る
            SelectPiece.GetComponent<Renderer>().material
                = SelectPiece.CompareTag("WhitePiece") ? White : Black;
            SelectPiece = null;
            PieceNum = 0;
            //ターンを切り替える(白→黒、黒→白)
            _manager.Phase = _manager.Phase == GameManager.PlayerPhase.White
                ? GameManager.PlayerPhase.Black : GameManager.PlayerPhase.White;
            SearchReset();
        }
    }

    /// <summary> 駒の切り替え時にそれまで選んでいた駒の探索を切る </summary>
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
