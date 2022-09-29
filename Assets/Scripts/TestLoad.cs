using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class TestLoad : MonoBehaviour
{
    const int BOARD_HEIGHT = 8;
    const int BOARD_WIDTH = 8;
    //ジャグ配列を宣言
    [SerializeField] string[][] _tile = new string[BOARD_HEIGHT][];
    public string[][] Tile { get => _tile; set => _tile = value; }

    // Start is called before the first frame update
    void Start()
    {
        // Addressables Assets Systemを利用し、Addressables Groupから
        // 読み込む対象のパスを指定し、アセットを読み込む(アセット名をstringで指定)
        Addressables.LoadAssetAsync<TextAsset>("Assets/initial placement.csv").Completed +=
            // 読み込んだアセット(csv)をコンソールに表示する。
            (a) =>
            {
                Debug.Log(a);
                Debug.Log($"{a.Result}"); //a.Result...読み込んだ内容全体

                var sr = new StringReader(a.Result.text);
                string value = "";
                bool isFirstLine = true;
                int count = 0;
                //読み込んだ情報がnullで無ければ、以下の処理を行う
                while ((value = sr.ReadLine()) != null)
                {
                    if (isFirstLine)
                    {
                        isFirstLine = false;
                        continue;
                    }
                    Tile[count] = value.Split(',');
                    Debug.Log(count);

                    count++;
                    Debug.Log(value); //1行ごとの入力(2行目以降)
                }
            };

        for (int i = 0; i < Tile.Length; i++)
        {
            Tile[i] = new string[BOARD_WIDTH];
            print($"{i}番目の配列の要素数は {Tile[i].Length} です");
            //Debug.Log(Tile[i].Length); //ジャグ配列の要素数を確認
        }
    }

    void OnLoadCsv(TextAsset csv)
    {
        var sr = new StringReader(csv.text);
    }

    void Test0(UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle<TextAsset> obj)
    {
        Debug.Log(obj);
    }

    // Update is called once per frame
    void Update()
    {

    }

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
