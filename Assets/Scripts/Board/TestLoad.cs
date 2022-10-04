using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.AddressableAssets;

/// <summary>
/// �e�L�X�g�f�[�^��ǂݍ��݁A�����z�u��ݒ肷�鏈��
/// ���z�u���鏈��
/// </summary>
public class TestLoad : MonoBehaviour
{
    //�z�u�����
    [SerializeField] GameObject[] _pieces = new GameObject[12];
    [SerializeField] GameObject[] _tiles = new GameObject[2];
    //�W���O�z���錾
    string[][] _board = new string[8][];
    int[][] _boardInfo = new int[8][];
    RaycastHit _hit;
    GameManager _manager;

    public GameObject[] Pieces { get => _pieces; set => _pieces = value; }
    public string[][] Board { get => _board; set => _board = value; }
    public int[][] BoardInfo { get => _boardInfo; set => _boardInfo = value; }
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
                        //�ǂݍ��񂾏��𐔎��̃W���O�z��ɕϊ�
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
                            Instantiate(Pieces[5], new Vector3(x, 0.1f, z), Pieces[5].transform.rotation, GameObject.Find("Piece").transform);
                        //���e�I�u�W�F�N�g���w�肵�A�q�I�u�W�F�N�g�ɐݒ�
                        else if (BoardInfo[count][i] == -6)
                            Instantiate(Pieces[11], new Vector3(x, 0.1f, z), Pieces[11].transform.rotation, GameObject.Find("Piece").transform);

                        setTile.transform.SetParent(gameObject.transform);
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
                    //x,z�̒l���擾
                    int x = (int)_hit.collider.gameObject.transform.position.x;
                    int z = (int)_hit.collider.gameObject.transform.position.z;

                    //�}�X����̂Ƃ�
                    if (BoardInfo[Mathf.Abs(z)][x] == 0)
                    {
                        //�z�u������I�ׂ�悤�ɂ���(���݂͎w��̋��u���悤�ɂȂ��Ă���)
                        if (_manager.Phase == GameManager.PlayerPhase.White)
                        {
                            Instantiate(SetPiece, new Vector3(x, 0.1f, z), SetPiece.transform.rotation, GameObject.Find("Piece").transform);
                            BoardInfo[Mathf.Abs(z)][x] = (int)SetPiece.GetComponent<PieceMove>().Type;
                            _manager.Phase = GameManager.PlayerPhase.Black;
                        } 
                        else if (_manager.Phase == GameManager.PlayerPhase.Black)
                        {
                            Instantiate(SetPiece, new Vector3(x, 0.1f, z), SetPiece.transform.rotation, GameObject.Find("Piece").transform);
                            BoardInfo[Mathf.Abs(z)][x] = (int)SetPiece.GetComponent<PieceMove>().Type;
                            _manager.Phase = GameManager.PlayerPhase.White;
                        }
                        BoardInfo[Mathf.Abs(z)][x] = (int)SetPiece.GetComponent<PieceMove>().Type;
                        SetPiece = null;
                    }
                }
                else if (SetPiece == null)
                {
                    Debug.Log("��w�肳��Ă��܂���");
                }
            }
        }
    }
}