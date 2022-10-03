using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectPiece : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] Material _select;
    [SerializeField] Material _back;

    //�}�E�X�J�[�\�����I�u�W�F�N�g�ɐG�ꂽ�ꍇ�̏���(�N���b�N����͊֌W�Ȃ�)
    public void OnPointerEnter(PointerEventData eventData)
    {
        gameObject.GetComponent<MeshRenderer>().material = _select;
    }

    //�}�E�X�J�[�\�����I�u�W�F�N�g���痣�ꂽ�ꍇ�̏���(�N���b�N����͊֌W�Ȃ�)
    public void OnPointerExit(PointerEventData eventData)
    {
        gameObject.GetComponent<MeshRenderer>().material = _back;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
