using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceManager : MonoBehaviour
{
    public int PieceNum { get; set; }
    //選択した駒のマス番号を取得する(X,Z)
    public int TileNumX { get; set; }
    public int TileNumZ { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        PieceNum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //駒の個別移動処理への遷移
        if (PieceNum != 0)
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
                    GameObject.Find("Movements").GetComponent<Rook>().Movement();
                    break;
                case 5:
                    Debug.Log("Queen");
                    break;
                case 6:
                    Debug.Log("King");
                    break;
            }
        }
    }
}
