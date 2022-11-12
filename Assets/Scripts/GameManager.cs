using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Tooltip("どっちのターンか")]
    [SerializeField] private Text _phase;

    private int _beFrPhase; //(BeforeFramePhase)...直前のフレームのターン

    /// <summary> ターンの制御 </summary>
    public PlayerPhase Phase { get; set; }
    /// <summary>獲った駒 </summary>
    public GameObject GottenPiece { get; set; }

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
        //ターンが切り替わったタイミングで勝利判定
        if ((int)Phase != _beFrPhase)
        {
            WinningCheck();
            _beFrPhase = (int)Phase;
        }
    }

    //ターンが切り替わったタイミングでゲームがクリアされたか判定する
    //(1ターン分の処理が終わったタイミングで呼ぶのもアリ)
    //クリアされたら、true を返す
    bool WinningCheck()
    {
        //ここに勝利判定処理を書く
        //1,敵のKingを獲ること
        //2,同じ色の駒を縦、横、斜めのいずれかで4つ並べる
        //3,同じ種類の駒を縦、横、斜めのいずれかで4つ並べる(色は混ざっていてもよい)
        return false;
    }

    //どっちのターンか
    public enum PlayerPhase
    {
        White = 1,
        Black
    }
}
