using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CardInfomation : MonoBehaviour
{
    [SerializeField]
    private CardDataBase cardDataBase; //�g�p����f�[�^�x�[�X

    //  �f�B�N�V���i���[��Card����쐬���AnumOfCard��Card�̔ԍ���U��
    private Dictionary<Card, int> numOfCard = new Dictionary<Card, int>();

    // �J�[�h�̃^�C�g��
    [SerializeField]
    private TextMeshProUGUI cardTitle;

    // �J�[�h�̃X�L������
    [SerializeField]
    private TextMeshProUGUI cardInfomation;

    // �J�[�h�̏���\������|�b�v�A�b�v
    [SerializeField]
    private GameObject popupOfCardInfomation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // �J�[�\�����J�[�h�̏�ɒu���ꂽ��
        if(CardController.shouldShowCardInfomation == true)
        {
            // �^�O���猟�����ăJ�[�h�̏���\��
            SearchCardInfomation(CardController.tagCursorOnCard);
        }
        else
        {
            cardTitle.text = " ";
            cardInfomation.text = " ";
            popupOfCardInfomation.SetActive(false);
        }
    }

    public void SearchCardInfomation(string tag)
    {
        for (int i = 0; i < cardDataBase.GetCardLists().Count; i++)
        {
            if(tag == cardDataBase.GetCardLists()[i].GetTag())
            {
                popupOfCardInfomation.SetActive(true);
                cardTitle.text = cardDataBase.GetCardLists()[i].GetCardName();
                cardInfomation.text = cardDataBase.GetCardLists()[i].GetCardInformation();
            }
        }
    }
}
