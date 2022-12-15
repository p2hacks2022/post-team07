using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeckController : MonoBehaviour
{
    // DeckのPrefab
    [SerializeField] 
    Image deckPrefab;

    // 山札の枚数
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
    private Sprite[] deckType;

    // カード保持用のListの初期化
    List<Image> deckCards = new List<Image>();

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < deckCardNum; i++)
        {
            Image c = Instantiate(deckPrefab, transform, false);

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

        // カードの効果をランダムに選ぶ
        int deckTypeNum = Random.Range(0,5);  

        if(nowCardNum == 0)
        {
            for(int i=0; i<3; i++)
            {
                // カードの効果をランダムに選ぶ
                deckTypeNum = Random.Range(0, 5);

                // 選んだカードの効果画像を設定する
                deckCards[i].sprite = deckType[deckTypeNum];
            }

            //deckカードをカード3の子要素にする
            deckCards[0].transform.SetParent(card3Tf);
            //カードのlocalPositionを0にする
            deckCards[0].transform.localPosition = Vector2.zero;

            //deckカードをカード2の子要素にする
            deckCards[1].transform.SetParent(card2Tf);
            //カードのlocalPositionを0にする
            deckCards[1].transform.localPosition = Vector2.zero;

            //deckカードをカード1の子要素にする
            deckCards[2].transform.SetParent(card1Tf);
            //カードのlocalPositionを0にする
            deckCards[2].transform.localPosition = Vector2.zero;

            nowCardNum++;
        }
        else if ((nowCardNum+1) <= deckCards.Count)
        {
            // 選んだカードの効果画像を設定する
            deckCards[nowCardNum].sprite = deckType[deckTypeNum];

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
