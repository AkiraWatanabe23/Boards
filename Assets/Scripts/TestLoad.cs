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
    [SerializeField] string[][] _tile = new string[BOARD_HEIGHT][];
    public string[][] Tile { get => _tile; set => _tile = value; }

    // Start is called before the first frame update
    void Start()
    {
        // Addressables Assets System�𗘗p���AAddressables Group����
        // �ǂݍ��ޑΏۂ̃p�X���w�肵�A�A�Z�b�g��ǂݍ���(�A�Z�b�g����string�Ŏw��)
        Addressables.LoadAssetAsync<TextAsset>("Assets/initial placement.csv").Completed +=
            // �ǂݍ��񂾃A�Z�b�g(csv)���R���\�[���ɕ\������B
            (a) =>
            {
                Debug.Log(a);
                Debug.Log($"{a.Result}"); //a.Result...�ǂݍ��񂾓��e�S��

                var sr = new StringReader(a.Result.text);
                string value = "";
                bool isFirstLine = true;
                int count = 0;
                //�ǂݍ��񂾏��null�Ŗ�����΁A�ȉ��̏������s��
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
                    Debug.Log(value); //1�s���Ƃ̓���(2�s�ڈȍ~)
                }
            };

        for (int i = 0; i < Tile.Length; i++)
        {
            Tile[i] = new string[BOARD_WIDTH];
            print($"{i}�Ԗڂ̔z��̗v�f���� {Tile[i].Length} �ł�");
            //Debug.Log(Tile[i].Length); //�W���O�z��̗v�f�����m�F
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
