using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Tooltip("�ǂ����̃^�[����"), SerializeField] Text _phase;
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

    //�^�[�����؂�ւ�����^�C�~���O�ŃQ�[�����N���A���ꂽ�����肷��
    //(1�^�[�����̏������I������^�C�~���O�ŌĂԂ̂��A��)
    //�N���A���ꂽ��Atrue ��Ԃ�
    bool WinningCheck()
    {
        if ((int)Phase != _beFrPhase)
        {
            //���̏�ɏ������菈��������
            _beFrPhase = (int)Phase;
        }
        return false;
    }

    //�ǂ����̃^�[����
    public enum PlayerPhase
    {
        White = 1,
        Black
    }
}
