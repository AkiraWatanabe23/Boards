using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class TestLoad : MonoBehaviour
{
    const int BOARD_HEIGHT = 8;
    const int BOARD_WIDTH = 8;
    //�W���O�z���錾
    string[][] _tile = new string[BOARD_HEIGHT][];
    int[][] _boardInfo = new int[BOARD_HEIGHT][];
    public string[][] Tile { get => _tile; set => _tile = value; }
    public int[][] BoardInfo { get => _boardInfo; set => _boardInfo = value; }

    void Awake()
    {
        string value = "";
        bool isFirstLine = true;
        int count = 0;

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
                    Tile[count] = value.Split(',');
                    for (int i = 0; i < Tile.Length; i++)
                    {
                        BoardInfo[count][i] = int.Parse(Tile[count][i]);
                        Debug.Log(BoardInfo[count][i]);
                    }
                    //Debug.Log(count); //while������Ă���񐔂��m�F����
                    //Debug.Log(value); //value...1�s���Ƃ̓���(2�s�ڈȍ~)
                    count++;
                }
            };
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < Tile.Length; i++)
        {
            //�����ŁA8*8�̃W���O�z�������
            Tile[i] = new string[BOARD_WIDTH];
            BoardInfo[i] = new int[BOARD_WIDTH];
            print($"{i}�Ԗڂ̔z��̗v�f���� {Tile[i].Length} �ł�"); //�W���O�z��̗v�f�����m�F

            for (int j = 0; j < Tile[i].Length; j++)
            {
                //�����ŔՖʂ̃}�X�ɓǂݍ��񂾏������蓖�Ă�
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
