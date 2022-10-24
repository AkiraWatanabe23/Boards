using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.AddressableAssets;

/// <summary>
/// テキストデータを読み込み、初期配置を設定する処理
/// 駒を配置する処理
/// </summary>
public class TestLoad : MonoBehaviour
{
    //配置する駒,マス
    [SerializeField] GameObject[] _pieces = new GameObject[12];
    [SerializeField] GameObject[] _tile = new GameObject[2];
    [SerializeField] GameObject _movableTile;
    //マスの配列
    GameObject[,] _tiles = new GameObject[8, 8];
    //ジャグ配列を宣言
    string[][] _board = new string[8][];
    int[][] _boardInfo = new int[8][];
    RaycastHit _hit;
    GameManager _manager;

    //SetPieceに代入する配置する駒の種類
    public GameObject[] Pieces { get => _pieces; set => _pieces = value; }
    //移動可能を示すパネルの設置
    public GameObject[,] Tiles { get => _tiles; set => _tiles = value; }
    //盤の初期配置を読み込む用
    public string[][] Board { get => _board; set => _board = value; }
    //読み込んだものを数値として扱い、シーン上に起こす用
    public int[][] BoardInfo { get => _boardInfo; set => _boardInfo = value; }
    //新しく駒を配置する
    public GameObject SetPiece { get; set; }

    void Awake()
    {
        string value = "";
        bool isFirstLine = true;
        int count = 0;
        int x = 0;
        int z = 0;
        GameObject tile = null;
        GameObject setTile = null;

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
                    if (tile != null) //最初は白マスから配置
                    {
                        if (z % 2 != 0)
                            tile = _tile[0];
                        else
                            tile = _tile[1];
                    }

                    for (int i = 0; i < Board.Length; i++)
                    {
                        //読み込んだ情報を数字のジャグ配列に変換
                        BoardInfo[count][i] = int.Parse(Board[count][i]);
                        Debug.Log(BoardInfo[count][i]);
                        Tiles[count, i] = Instantiate(_movableTile, new Vector3(x, 0.1f, z), _movableTile.transform.rotation);

                        if (tile == null || tile == _tile[1])
                        {
                            setTile = Instantiate(_tile[0], new Vector3(x, 0, z), _tile[0].transform.rotation);
                            tile = _tile[0];
                        }
                        else if (tile == _tile[0])
                        {
                            setTile = Instantiate(_tile[1], new Vector3(x, 0, z), _tile[0].transform.rotation);
                            tile = _tile[1];
                        }
                        //駒の初期配置
                        if (BoardInfo[count][i] == 6)
                            Instantiate(Pieces[5], new Vector3(x, 0.1f, z), Pieces[5].transform.rotation, GameObject.Find("Piece").transform);
                        //↓親オブジェクトを指定し、子オブジェクトに設定
                        else if (BoardInfo[count][i] == -6)
                            Instantiate(Pieces[11], new Vector3(x, 0.1f, z), Pieces[11].transform.rotation, GameObject.Find("Piece").transform);

                        setTile.transform.SetParent(gameObject.transform);
                        x++;
                    }
                    count++;
                    x = 0;
                    z--;
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
            Board[i] = new string[8];
            BoardInfo[i] = new int[8];
        }

        _manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void OnLoadCsv(TextAsset csv)
    {
        var sr = new StringReader(csv.text);
    }

    void Test0(UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle<TextAsset> obj)
    {
        Debug.Log(obj);
    }

    //新しく配置する駒を選択し、空いているマスに配置する処理
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out _hit))
            {
                if (_hit.collider.gameObject.CompareTag("Tile") && SetPiece != null)
                {
                    //x,zの値を取得
                    int x = (int)_hit.collider.gameObject.transform.position.x;
                    int z = (int)_hit.collider.gameObject.transform.position.z;

                    //マスが空のとき
                    if (BoardInfo[Mathf.Abs(z)][x] == 0)
                    {
                        //配置する駒を選べるようにする(現在は指定の駒を置くようになっている)
                        Instantiate(SetPiece, new Vector3(x, 0.1f, z), SetPiece.transform.rotation, GameObject.Find("Piece").transform);
                        BoardInfo[Mathf.Abs(z)][x] = (int)SetPiece.GetComponent<PieceMove>().Type;

                        _manager.Phase = _manager.Phase == GameManager.PlayerPhase.White
                            ? GameManager.PlayerPhase.Black : GameManager.PlayerPhase.White;

                        BoardInfo[Mathf.Abs(z)][x] = (int)SetPiece.GetComponent<PieceMove>().Type;
                        SetPiece = null;
                    }
                }
            }
        }
    }
}
