using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class TestLoad : MonoBehaviour
{
    //�z�u�����
    [SerializeField] GameObject[] _pieces = new GameObject[12];
    [SerializeField] GameObject[] _tiles = new GameObject[2];
    //�W���O�z���錾(& �z��Ɋւ���ϐ�)
    const int BOARD_HEIGHT = 8;
    const int BOARD_WIDTH = 8;
    string[][] _board = new string[BOARD_HEIGHT][];
    int[][] _boardInfo = new int[BOARD_HEIGHT][];
    GameObject _setPiece = null;
    RaycastHit _hit;

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

        // Addressables Assets System�𗘗p���AAddressables Group����
        // �ǂݍ��ޑΏۂ̃p�X���w�肵�A�A�Z�b�g��ǂݍ���(�A�Z�b�g����string�Ŏw��)
        Addressables.LoadAssetAsync<TextAsset>("Assets/initial placement.csv").Completed +=
            // �ǂݍ��񂾃A�Z�b�g(csv)���R���\�[���ɕ\������B
            (a) =>
            {
                //Debug.Log(a);
                //Debug.Log($"{a.Result}"); //a.Result...�ǂݍ��񂾓��e�S��

                var sr = new StringReader(a.Result.text);
                //�ǂݍ��񂾏��null�Ŗ�����΁A�ȉ��̏������s��
                while ((value = sr.ReadLine()) != null)
                {
                    if (isFirstLine)
                    {
                        isFirstLine = false;
                        continue;
                    }
                    Board[count] = value.Split(',');

                    //�Ֆʂ̏����ݒ�(�Ֆʂ��o���A��������z�u�ɐݒ肷��...�Ֆʂ͍��ォ��E���ɂ����Ĕz�u)
                    //===============================================================
                    if (tile != null) //�ŏ��͔����u��
                    {
                        if (z % 2 != 0)
                            tile = _tiles[0];
                        else
                            tile = _tiles[1];
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
                        //��̏����z�u
                        if (BoardInfo[count][i] == 6)
                            _setPiece = Instantiate(_pieces[5], new Vector3(x, 0.1f, z), _pieces[5].transform.rotation);
                        else if (BoardInfo[count][i] == -6)
                            _setPiece = Instantiate(_pieces[11], new Vector3(x, 0.1f, z), _pieces[11].transform.rotation);

                        setTile.transform.SetParent(gameObject.transform);
                        if (_setPiece != null)
                            _setPiece.transform.SetParent(GameObject.Find("Piece").transform);
                        x++;
                    }
                    //Debug.Log(count); //while������Ă���񐔂��m�F����
                    //Debug.Log(value); //value...1�s���Ƃ̓���(2�s�ڈȍ~)
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
            //�����ŁA8*8�̃W���O�z�������
            Board[i] = new string[BOARD_WIDTH];
            BoardInfo[i] = new int[BOARD_WIDTH];
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
        //�ŏI�I�ɂ͑S�L�[�{�[�h����ɂ��Ă݂���
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    //��(or �}�X)��I�����鏈������������
        //    Debug.Log("Click Space");
        //    if (BoardInfo[0][0] == 0)
        //    {
        //        setPiece = Instantiate(_pieces[3], new Vector3(0, 0.1f, 0), _pieces[3].transform.rotation);
        //        BoardInfo[0][0] = 3;
        //    }
        //}
        //else if (Input.GetKeyDown(KeyCode.Escape))
        //{
        //    //�I�������̏�������������
        //    Debug.Log("Click Escape");
        //}

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out _hit))
            {
                //x,z�̒l���擾
                int x = (int)_hit.collider.gameObject.transform.position.x;
                int z = (int)_hit.collider.gameObject.transform.position.z;

                //�}�X����̂Ƃ�
                if (BoardInfo[Mathf.Abs(z)][x] == 0)
                {
                    Instantiate(_pieces[3], new Vector3(x, 0.1f, z), _pieces[3].transform.rotation);
                    _setPiece = _pieces[3];
                    BoardInfo[Mathf.Abs(z)][x] = (int)_setPiece.GetComponent<PieceMove>().Type;
                }
            }
        }
    }
}
