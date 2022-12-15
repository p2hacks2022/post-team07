using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckController : MonoBehaviour
{
    // DeckのPrefab
    [SerializeField] 
    GameObject deckPrefab;

    // 生成するカードの種類数
    [SerializeField] 
    int deckCardNum;

    // カードが追加され、入れ替わるまでの時間間隔
    [SerializeField]
    int timeOfSwappingCards;

    // 山札の何枚目が追加されたか
    int nowCardNum = 0;

    /* Card1~3のTransform */
    [SerializeField] 
    Transform card1Tf;
    [SerializeField]
    Transform card2Tf;
    [SerializeField]
    Transform card3Tf;
    /* ------------------- */

    // カードの種類保持用の配列の初期化
    [SerializeField]
    private GameObject[] deckvariety;

    // カード保持用のListの初期化
    List<GameObject> deckCards = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < deckCardNum; i++)
        {
            GameObject c = Instantiate(deckPrefab, transform, false);

            //追記　Listにcardを追加していく
            deckCards.Add(c);
        }

        //MoveCardsを0秒後に呼び出し、以降は{timeOfSwappingCards}秒毎に実行
        InvokeRepeating(nameof(MoveCards), 0f, timeOfSwappingCards);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void MoveCards()
    {
        Debug.Log("カードが追加される");

        if ((nowCardNum+1) <= deckCards.Count)
        {
            //deckカードをカード1の子要素にする
            deckCards[nowCardNum].transform.SetParent(card1Tf);

            //カードのlocalPositionを0にする
            deckCards[nowCardNum].transform.localPosition = Vector2.zero;


            if (nowCardNum > 0)
            {
                //カード1をカード2の子要素にする
                deckCards[nowCardNum - 1].transform.SetParent(card2Tf);

                //カード1のlocalPositionを0にする
                deckCards[nowCardNum - 1].transform.localPosition = Vector2.zero;
            }
            if (nowCardNum > 1)
            {
                //カード2をカード3の子要素にする
                deckCards[nowCardNum - 2].transform.SetParent(card3Tf);

                //カード2のlocalPositionを0にする
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
