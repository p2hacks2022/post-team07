using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class DeckController : MonoBehaviour
{
    // Deck��Prefab
    [SerializeField] 
    Image cardPrefab;

    // �R�D�̖���
    [SerializeField] 
    int deckCardNum;

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
    private Sprite[] deckType;

    //�X�L���J�[�h�̎�ސ�
    [SerializeField]
    private int deckTypeNum;

    // �R�D�J�[�h�p��List�̏�����
    List<Image> deckCards = new List<Image>();

    // Start is called before the first frame update
    void Start()
    {
        // �R�D�����
        for (int i = 0; i < deckCardNum; i++)
        {
            Image c = Instantiate(cardPrefab, transform, false);

            //List��card��ǉ����Ă���
            deckCards.Add(c);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (CardController.isSimulatedOnMap == true)
        {
            MoveCards();

            CardController.isSimulatedOnMap = false;
        }
    }

    public void MoveCards()
    {
        //Debug.Log("�J�[�h���ǉ����ꂽ");

        if ((nowCardNum+1) <= deckCards.Count)
        {
            if (nowCardNum == 0)
            {
                for (int i = 0; i < 3; i++)
                {
                    // �J�[�h�̌��ʂ������_���ɑI��
                    int randomDeckTypeNum2 = Random.Range(0, deckTypeNum);

                    // �I�񂾃J�[�h�̌��ʉ摜��ݒ肷��
                    deckCards[i].sprite = deckType[randomDeckTypeNum2];
                }

                /*
                // �R�D�����D��3���ڂ�1���ړ�
                deckCards[0].transform.DOMove(card3Tf.position, 1.0f)
                    .SetEase(Ease.InCirc)
                    .OnComplete(() => deckCards[0].transform.SetParent(card3Tf));
                */
                // �R�D�����D��3���ڂ�1���ړ�
                //�J�[�h��ʂ̎R�̎q�v�f�ɂ���
                deckCards[0].transform.SetParent(card3Tf);
                //�J�[�h��localPosition��0�ɂ���
                deckCards[0].transform.localPosition = Vector2.zero;

                /*
                // �R�D�����D��2���ڂ�1���ړ�
                deckCards[1].transform.DOMove(card2Tf.position, 1.0f)
                    .SetEase(Ease.InCirc)
                    .OnComplete(() => deckCards[1].transform.SetParent(card2Tf));
                */
                // �R�D�����D��2���ڂ�1���ړ�
                deckCards[1].transform.SetParent(card2Tf);
                //�J�[�h��localPosition��0�ɂ���
                deckCards[1].transform.localPosition = Vector2.zero;

                nowCardNum += 2;
            }

            // �J�[�h�̌��ʂ������_���ɑI��
            int randomDeckTypeNum = Random.Range(0, deckTypeNum);

            // �I�񂾃J�[�h�̌��ʉ摜��ݒ肷��
            deckCards[nowCardNum].sprite = deckType[randomDeckTypeNum];

            /*
            // �R�D�����D��1���ڂ�1���ړ�
            deckCards[nowCardNum].transform.DOMove(card1Tf.position, 1.0f)
                .SetEase(Ease.InCirc)
                .OnComplete(() => deckCards[nowCardNum].transform.SetParent(card1Tf));
            */

            // �R�D�����D��1���ڂ�1���ړ�
            deckCards[nowCardNum].transform.SetParent(card1Tf);
            //�J�[�h��localPosition��0�ɂ���
            deckCards[nowCardNum].transform.localPosition = Vector2.zero;


            if (nowCardNum > 0)
            {
                /*
                // ��D1���ڂ����D2���ڂփJ�[�h���ړ�
                deckCards[nowCardNum - 1].transform.DOMove(card2Tf.position, 1.0f)
                    .SetEase(Ease.InCirc)
                    .OnComplete(() => deckCards[nowCardNum - 1].transform.SetParent(card2Tf));
                */

                // ��D1���ڂ����D��2���ڂ�1���ړ�
                deckCards[nowCardNum - 1].transform.SetParent(card2Tf);
                //�J�[�h��localPosition��0�ɂ���
                deckCards[nowCardNum - 1].transform.localPosition = Vector2.zero;
            }
            
            if (nowCardNum > 1)
            {
                /*
                // ��D2���ڂ����D3���ڂփJ�[�h���ړ�
                deckCards[nowCardNum - 2].transform.DOMove(card3Tf.position, 1.0f)
                    .SetEase(Ease.InCirc)
                    .OnComplete(() => deckCards[nowCardNum - 2].transform.SetParent(card3Tf));
                */

                // ��D2���ڂ����D��3���ڂ�1���ړ�
                deckCards[nowCardNum - 2].transform.SetParent(card3Tf);
                //�J�[�h��localPosition��0�ɂ���
                deckCards[nowCardNum].transform.localPosition = Vector2.zero;
            }

            if (nowCardNum > 2)
            {
                //��D3���ڂ���R�D��1���ړ�
                deckCards[nowCardNum - 3].transform.SetParent(deckTf);

                //��D3���ڂ���R�D��1���ړ�
                deckCards[nowCardNum - 3].transform.localPosition = Vector2.zero;
            }

            nowCardNum++;
        }
        else
        {
            CancelInvoke();
        }
    }
}
