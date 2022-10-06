using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceManager : MonoBehaviour
{
    [SerializeField] Material _select;
    bool[,] _movable = new bool[8, 8];
    public Material Select { get => _select; set => _select = value; }
    public int PieceNum { get; set; }
    //選択した駒のマス番号を取得する(X,Z)
    public int TileNumX { get; set; }
    public int TileNumZ { get; set; }
    public bool[,] Movable { get => _movable; set => _movable = value; }

    // Start is called before the first frame update
    void Start()
    {
        PieceNum = 0;
    }

    //駒の個別移動処理への遷移
    public void PieceMovement()
    {
        switch (Mathf.Abs(PieceNum))
        {
            case 1:
                Debug.Log("Pawn");
                break;
            case 2:
                Debug.Log("Knight");
                break;
            case 3:
                Debug.Log("Bishop");
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
    /// 駒の選択、非選択に関する処理
    /// </summary>
    public void PieceSelect()
    {
        //すでに駒が選ばれていた場合...他の駒をクリックで選択対象を切り替える
    }
}
