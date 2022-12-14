using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField]
    private GameObject card;

    [SerializeField]
    private float cardSizeTimes; //�J�[�h�g��̓x����

    [SerializeField]
    private float cardPositionTimes; //�J�[�h�̈ʒu�グ�̓x����

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // �}�E�X�J�[�\�����u���ꂽ�Ƃ�
    public void onPointerEnter()
    {
        // �J�[�h�̈ʒu���グ��
        card.transform.position += Vector3.up * cardPositionTimes;
        // �J�[�h���g�傳����
        card.transform.localScale = Vector3.one * cardSizeTimes;
    }

    // �}�E�X�J�[�\�������ꂽ�Ƃ�
    public void onPointerExit()
    {
        // �J�[�h�̈ʒu�����ɖ߂�
        card.transform.position -= Vector3.up * cardPositionTimes;
        // �J�[�h�̑傫�������ɖ߂�
        card.transform.localScale = Vector3.one;
    }
}
