using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class TestLoad : MonoBehaviour
{
    const int BOARD_HEIGHT = 8;
    const int BOARD_WIDTH = 8;
    [SerializeField] string[][] _tile = new string[BOARD_HEIGHT][]; //�W���O�z���錾

    public string[][] Tile { get => _tile; set => _tile = value; }

    // Start is called before the first frame update
    void Start()
    {
        // Addressables Assets System�𗘗p���AAddressables Group����
        // �ǂݍ��ޑΏۂ̃p�X���w�肵�A�A�Z�b�g��ǂݍ��ށB
        Addressables.LoadAssetAsync<TextAsset>("Assets/initial placement.csv").Completed +=
            // �ǂݍ��񂾃A�Z�b�g(csv)���R���\�[���ɕ\������B
            (a) =>
            {
                Debug.Log(a);
                Debug.Log($"{a.Result}");

                var sr = new StringReader(a.Result.text);
                string value = "";
                bool isFirstLine = true;
                int count = 0;
                while ((value = sr.ReadLine()) != null)
                {
                    if (isFirstLine)
                    {
                        isFirstLine = false;
                        continue;
                    }
                    Tile[count] = value.Split(',');

                    count++;

                    Debug.Log(value);
                }
            };

        for (int i = 0; i < Tile.Length; i++)
        {
            Tile[i] = new string[BOARD_WIDTH];
            Debug.Log(i);
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
