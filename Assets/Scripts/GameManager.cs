using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Tooltip("どっちのターンか"), SerializeField] Text _phase;
    public PlayerPhase Phase { get; set; }
    int _beFrPhase; //(BeforeFramePhase)

    // Start is called before the first frame update
    void Start()
    {
        Phase = PlayerPhase.White;
        _beFrPhase = (int)Phase;
    }

    // Update is called once per frame
    void Update()
    {
        _phase.text = Phase.ToString();
    }

    //ターンが切り替わったタイミングでゲームがクリアされたか判定する
    //(1ターン分の処理が終わったタイミングで呼ぶのもアリ)
    //クリアされたら、true を返す
    bool WinningCheck()
    {
        if ((int)Phase != _beFrPhase)
        {
            //この上に勝利判定処理を書く
            _beFrPhase = (int)Phase;
        }
        return false;
    }

    //どっちのターンか
    public enum PlayerPhase
    {
        White = 1,
        Black
    }
}
