using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StateCheck();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //マスの状態を調べる
    void StateCheck()
    {
        //駒の有無、位置の変更等でTestLoad.BoardInfo[][] の値を更新する
    }
}
