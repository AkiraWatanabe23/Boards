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

    //Ç«Ç¡ÇøÇÃÉ^Å[ÉìÇ©
    public enum PlayerPhase
    {
        White = 1,
        Black
    }
}
