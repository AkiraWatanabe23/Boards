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
    string[][] _tile = new string[BOARD_HEIGHT][];
    int[][] _boardInfo = new int[BOARD_HEIGHT][];
    public string[][] Tile { get => _tile; set => _tile = value; }
    public int[][] BoardInfo { get => _boardInfo; set => _boardInfo = value; }

    void Awake()
    {
        string value = "";
        bool isFirstLine = true;
        int count = 0;

        // Addressables Assets Systemを利用し、Addressables Groupから
        // 読み込む対象のパスを指定し、アセットを読み込む(アセット名をstringで指定)
        Addressables.LoadAssetAsync<TextAsset>("Assets/initial placement.csv").Completed +=
            // 読み込んだアセット(csv)をコンソールに表示する。
            (a) =>
            {
                //Debug.Log(a);
                //Debug.Log($"{a.Result}"); //a.Result...読み込んだ内容全体

                var sr = new StringReader(a.Result.text);
                //読み込んだ情報がnullで無ければ、以下の処理を行う
                while ((value = sr.ReadLine()) != null)
                {
                    if (isFirstLine)
                    {
                        isFirstLine = false;
                        continue;
                    }
                    Tile[count] = value.Split(',');
                    for (int i = 0; i < Tile.Length; i++)
                    {
                        BoardInfo[count][i] = int.Parse(Tile[count][i]);
                        Debug.Log(BoardInfo[count][i]);
                    }
                    //Debug.Log(count); //whileが回っている回数を確認する
                    //Debug.Log(value); //value...1行ごとの入力(2行目以降)
                    count++;
                }
            };
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < Tile.Length; i++)
        {
            //ここで、8*8のジャグ配列をつくる
            Tile[i] = new string[BOARD_WIDTH];
            BoardInfo[i] = new int[BOARD_WIDTH];
            print($"{i}番目の配列の要素数は {Tile[i].Length} です"); //ジャグ配列の要素数を確認

            for (int j = 0; j < Tile[i].Length; j++)
            {
                //ここで盤面のマスに読み込んだ情報を割り当てる
            }
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
}
