using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Tooltip("�ǂ����̃^�[����")]
    [SerializeField] private Text _phase;

    private int _beFrPhase; //(BeforeFramePhase)...���O�̃t���[���̃^�[��

    /// <summary> �^�[���̐��� </summary>
    public PlayerPhase Phase { get; set; }
    /// <summary>�l������ </summary>
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
        //�^�[�����؂�ւ�����^�C�~���O�ŏ�������
        if ((int)Phase != _beFrPhase)
        {
            WinningCheck();
            _beFrPhase = (int)Phase;
        }
    }

    //�^�[�����؂�ւ�����^�C�~���O�ŃQ�[�����N���A���ꂽ�����肷��
    //(1�^�[�����̏������I������^�C�~���O�ŌĂԂ̂��A��)
    //�N���A���ꂽ��Atrue ��Ԃ�
    bool WinningCheck()
    {
        //�����ɏ������菈��������
        //1,�G��King���l�邱��
        //2,�����F�̋���c�A���A�΂߂̂����ꂩ��4���ׂ�
        //3,������ނ̋���c�A���A�΂߂̂����ꂩ��4���ׂ�(�F�͍������Ă��Ă��悢)
        return false;
    }

    //�ǂ����̃^�[����
    public enum PlayerPhase
    {
        White = 1,
        Black
    }
}
