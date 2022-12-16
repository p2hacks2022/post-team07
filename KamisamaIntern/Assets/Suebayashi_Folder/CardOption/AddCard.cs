using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddCard : MonoBehaviour
{
    // �R�D�ɐ��������J�[�h��Prefab
    [SerializeField] 
    Image cardPrefab;

    // �R�D�̖���
    [SerializeField] 
    int allCardNum;

    // �R�D�̉����ڂ��ǉ����ꂽ��
    int nowCardNum = 0;

    /* Card1~3��Transform */
    [SerializeField] 
    Transform card1Tf;
    [SerializeField]
    Transform card2Tf;
    [SerializeField]
    Transform card3Tf;
    [SerializeField]
    Transform deckTf;
    /* ------------------- */

    // �J�[�h�̎�ޕێ��p�̔z��̏�����
    [SerializeField]
    private Sprite[] cardType;

    // �J�[�h�̎�ސ�
    [SerializeField]
    private int cardTypeNum;

    // �R�D�J�[�h�p��List�̏�����
    List<Image> allCards = new List<Image>();

    // �n�߂�3���z��ꂽ��
    private bool isAddedFirst;

    // Start is called before the first frame update
    void Start()
    {
        // �R�D�����
        for (int i = 0; i < allCardNum; i++)
        {
            Image c = Instantiate(cardPrefab, transform, false);

            //List��card��ǉ����Ă���
            allCards.Add(c);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // �@�n�߂ɎR�D�����D��3���I��
        if (CardController.isSimulatedOnMap == true && isAddedFirst == false)
        {
            AddedCardFirst();

            isAddedFirst = true;
            CardController.isSimulatedOnMap = false;
        }
        // �@�ȍ~�A�R�D����1����D�ɒǉ������Ǝ�D����1���p�������
        else if(CardController.isSimulatedOnMap == true && isAddedFirst == true)
        {
            AddAndDiscardCard();

            CardController.isSimulatedOnMap = false;
        }
    }

    // �n�߂ɎR�D�����D��3���Z�b�g�����
    private void AddedCardFirst()
    {
        for (int i = 0; i < 3; i++)
        {
            // �J�[�h�̌��ʂ������_���ɑI��
            int randomDeckTypeNum = Random.Range(0, cardTypeNum);

            // �I�񂾃J�[�h�̌��ʉ摜��ݒ肷��
            allCards[i].sprite = cardType[randomDeckTypeNum];
        }

        /* ----------------�R�D�����D3���ڂւ̈ړ�-------------- */
        allCards[0].transform.SetParent(card3Tf);
        allCards[0].transform.localPosition = Vector2.zero;
        /* ------------------------------------------------------- */

        /* ----------------�R�D�����D2���ڂւ̈ړ�-------------- */
        allCards[1].transform.SetParent(card2Tf);
        allCards[1].transform.localPosition = Vector2.zero;
        /* ------------------------------------------------------- */

        /* ----------------�R�D�����D1���ڂւ̈ړ�-------------- */
        allCards[2].transform.SetParent(card1Tf);
        allCards[2].transform.localPosition = Vector2.zero;
        /* ------------------------------------------------------- */

        nowCardNum = 3;
    }

    private void AddAndDiscardCard()
    {
        if ((nowCardNum + 1) <= allCards.Count)
        {
            /* ----------------�R�D�����D1���ڂւ̈ړ�-------------- */

            // �J�[�h�̌��ʂ������_���ɑI��
            int randomDeckTypeNum = Random.Range(0, cardTypeNum);
            // �I�񂾃J�[�h�̌��ʉ摜��ݒ肷��
            allCards[nowCardNum].sprite = cardType[randomDeckTypeNum];

            allCards[nowCardNum].transform.SetParent(card1Tf);
            allCards[nowCardNum].transform.localPosition = Vector2.zero;

            /* ------------------------------------------------------- */

            /* ----------------��D1���ڂ����D2���ڂւ̈ړ�-------------- */

            allCards[nowCardNum - 1].transform.SetParent(card2Tf);
            allCards[nowCardNum - 1].transform.localPosition = Vector2.zero;

            /* ------------------------------------------------------- */

            /* ----------------��D2���ڂ����D3���ڂւ̈ړ�-------------- */

            allCards[nowCardNum - 2].transform.SetParent(card3Tf);
            allCards[nowCardNum - 2].transform.localPosition = Vector2.zero;

            /* ------------------------------------------------------- */

            /* ----------------��D3���ڂ���R�D�ւ̈ړ�-------------- */

            allCards[nowCardNum - 3].transform.SetParent(deckTf);
            allCards[nowCardNum - 3].transform.localPosition = Vector2.zero;

            /* ------------------------------------------------------- */

            nowCardNum++;
        }
    }
}
