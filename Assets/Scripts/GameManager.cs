using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerPhase Phase { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        Phase = PlayerPhase.White;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //�ǂ����̃^�[����
    public enum PlayerPhase
    {
        White = 1,
        Black
    }
}
