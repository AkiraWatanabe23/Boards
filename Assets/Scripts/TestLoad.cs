using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class TestLoad : MonoBehaviour
{
    //配置する駒
    [SerializeField] GameObject[] _pieces = new GameObject[12];
    [SerializeField] GameObject[] _tiles = new GameObject[2];
    //ジャグ配列を宣言(& 配列に関する変数)
    const int BOARD_HEIGHT = 8;
    const int BOARD_WIDTH = 8;
    string[][] _board = new string[BOARD_HEIGHT][];
    int[][] _boardInfo = new int[BOARD_HEIGHT][];

    public GameObject[] Pieces { get; set; }
    public string[][] Board { get => _board; set => _board = value; }
    public int[][] BoardInfo { get => _boardInfo; set => _boardInfo = value; }

    void Awake()
    {
        string value = "";
        bool isFirstLine = true;
        int count = 0;
        int x = 0;
        int z = 0;
        GameObject tile = null;
        GameObject setTile = null;
        GameObject setPiece = null;

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
                    Board[count] = value.Split(',');

                    //盤面の初期設定(盤面を出し、駒を初期配置に設定する...盤面は左上から右下にかけて配置)
                    //===============================================================
                    if (tile != null) //最初は白駒から置く
                    {
                        if (z % 6 != 0)
                        {
                            tile = _tiles[0];
                        }
                        else
                        {
                            tile = _tiles[1];
                        }
                    }

                    for (int i = 0; i < Board.Length; i++)
                    {
                        BoardInfo[count][i] = int.Parse(Board[count][i]);
                        Debug.Log(BoardInfo[count][i]);

                        if (tile == null || tile == _tiles[1])
                        {
                            setTile = Instantiate(_tiles[0], new Vector3(x, 0, z), _tiles[0].transform.rotation);
                            tile = _tiles[0];
                        }
                        else if (tile == _tiles[0])
                        {
                            setTile = Instantiate(_tiles[1], new Vector3(x, 0, z), _tiles[0].transform.rotation);
                            tile = _tiles[1];
                        }
                        //駒の初期配置
                        if (BoardInfo[count][i] == 1)
                            setPiece = Instantiate(_pieces[5], new Vector3(x, 0.5f, z), _pieces[5].transform.rotation);
                        else if (BoardInfo[count][i] == -1)
                            setPiece = Instantiate(_pieces[11], new Vector3(x, 0.5f, z), _pieces[11].transform.rotation);

                        setTile.transform.SetParent(gameObject.transform);
                        if (setPiece != null)
                        {
                            setPiece.transform.SetParent(GameObject.Find("Piece").transform);
                            //↓指定したコンポーネントを持っているかをboolで返す
                            //　今回は、もっていない場合にコンポーネントを追加する処理
                            if (!setPiece.GetComponent<PieceMove>())
                            {
                                setPiece.AddComponent<PieceMove>();
                            }
                        }
                        x += 3;
                    }
                    //Debug.Log(count); //whileが回っている回数を確認する
                    //Debug.Log(value); //value...1行ごとの入力(2行目以降)
                    count++;
                    x = 0;
                    z -= 3;
                    //===============================================================
                }
            };
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < Board.Length; i++)
        {
            //ここで、8*8のジャグ配列をつくる
            Board[i] = new string[BOARD_WIDTH];
            BoardInfo[i] = new int[BOARD_WIDTH];
            //print($"{i}番目の配列の要素数は {Board[i].Length} です");
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
