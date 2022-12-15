using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckController : MonoBehaviour
{
    // Deck��Prefab
    [SerializeField] 
    GameObject deckPrefab;

    // ��������J�[�h�̎�ސ�
    [SerializeField] 
    int deckCardNum;

    // �J�[�h���ǉ�����A����ւ��܂ł̎��ԊԊu
    [SerializeField]
    int timeOfSwappingCards;

    // �R�D�̉����ڂ��ǉ����ꂽ��
    int nowCardNum = 0;

    /* Card1~3��Transform */
    [SerializeField] 
    Transform card1Tf;
    [SerializeField]
    Transform card2Tf;
    [SerializeField]
    Transform card3Tf;
    /* ------------------- */

    // �J�[�h�̎�ޕێ��p�̔z��̏�����
    [SerializeField]
    private GameObject[] deckvariety;

    // �J�[�h�ێ��p��List�̏�����
    List<GameObject> deckCards = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < deckCardNum; i++)
        {
            GameObject c = Instantiate(deckPrefab, transform, false);

            //�ǋL�@List��card��ǉ����Ă���
            deckCards.Add(c);
        }

        //MoveCards��0�b��ɌĂяo���A�ȍ~��{timeOfSwappingCards}�b���Ɏ��s
        InvokeRepeating(nameof(MoveCards), 0f, timeOfSwappingCards);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void MoveCards()
    {
        Debug.Log("�J�[�h���ǉ������");

        if ((nowCardNum+1) <= deckCards.Count)
        {
            //deck�J�[�h���J�[�h1�̎q�v�f�ɂ���
            deckCards[nowCardNum].transform.SetParent(card1Tf);

            //�J�[�h��localPosition��0�ɂ���
            deckCards[nowCardNum].transform.localPosition = Vector2.zero;


            if (nowCardNum > 0)
            {
                //�J�[�h1���J�[�h2�̎q�v�f�ɂ���
                deckCards[nowCardNum - 1].transform.SetParent(card2Tf);

                //�J�[�h1��localPosition��0�ɂ���
                deckCards[nowCardNum - 1].transform.localPosition = Vector2.zero;
            }
            if (nowCardNum > 1)
            {
                //�J�[�h2���J�[�h3�̎q�v�f�ɂ���
                deckCards[nowCardNum - 2].transform.SetParent(card3Tf);

                //�J�[�h2��localPosition��0�ɂ���
                deckCards[nowCardNum - 2].transform.localPosition = Vector2.zero;
            }

            if (nowCardNum > 2)
            {
                Destroy(deckCards[nowCardNum - 3]);
            }

            nowCardNum++;
        }
        else
        {
            CancelInvoke();
        }
    }
}
