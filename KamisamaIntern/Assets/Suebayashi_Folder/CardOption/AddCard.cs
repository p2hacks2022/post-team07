using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddCard : MonoBehaviour
{
    // 山札に生成されるカードのPrefab
    [SerializeField] 
    Image cardPrefab;

    // 山札の枚数
    [SerializeField] 
    int allCardNum;

    // 山札の何枚目が追加されたか
    int nowCardNum = 0;

    /* Card1~3のTransform */
    [SerializeField] 
    Transform card1Tf;
    [SerializeField]
    Transform card2Tf;
    [SerializeField]
    Transform card3Tf;
    [SerializeField]
    Transform deckTf;
    /* ------------------- */

    // カードの種類保持用の配列の初期化
    [SerializeField]
    private Sprite[] cardType;

    // カードの種類数
    [SerializeField]
    private int cardTypeNum;

    // 山札カード用のListの初期化
    List<Image> allCards = new List<Image>();

    // 始めに3枚配られたか
    private bool isAddedFirst;

    // Start is called before the first frame update
    void Start()
    {
        // 山札を作る
        for (int i = 0; i < allCardNum; i++)
        {
            Image c = Instantiate(cardPrefab, transform, false);

            //Listにcardを追加していく
            allCards.Add(c);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // ①始めに山札から手札に3枚選ぶ
        if (CardController.isSimulatedOnMap == true && isAddedFirst == false)
        {
            AddedCardFirst();

            isAddedFirst = true;
            CardController.isSimulatedOnMap = false;
        }
        // ①以降、山札から1枚手札に追加されると手札から1枚廃棄される
        else if(CardController.isSimulatedOnMap == true && isAddedFirst == true)
        {
            AddAndDiscardCard();

            CardController.isSimulatedOnMap = false;
        }
    }

    // 始めに山札から手札に3枚セットされる
    private void AddedCardFirst()
    {
        for (int i = 0; i < 3; i++)
        {
            // カードの効果をランダムに選ぶ
            int randomDeckTypeNum = Random.Range(0, cardTypeNum);

            // 選んだカードの効果画像を設定する
            allCards[i].sprite = cardType[randomDeckTypeNum];
        }

        /* ----------------山札から手札3枚目への移動-------------- */
        allCards[0].transform.SetParent(card3Tf);
        allCards[0].transform.localPosition = Vector2.zero;
        /* ------------------------------------------------------- */

        /* ----------------山札から手札2枚目への移動-------------- */
        allCards[1].transform.SetParent(card2Tf);
        allCards[1].transform.localPosition = Vector2.zero;
        /* ------------------------------------------------------- */

        /* ----------------山札から手札1枚目への移動-------------- */
        allCards[2].transform.SetParent(card1Tf);
        allCards[2].transform.localPosition = Vector2.zero;
        /* ------------------------------------------------------- */

        nowCardNum = 3;
    }

    private void AddAndDiscardCard()
    {
        if ((nowCardNum + 1) <= allCards.Count)
        {
            /* ----------------山札から手札1枚目への移動-------------- */

            // カードの効果をランダムに選ぶ
            int randomDeckTypeNum = Random.Range(0, cardTypeNum);
            // 選んだカードの効果画像を設定する
            allCards[nowCardNum].sprite = cardType[randomDeckTypeNum];

            allCards[nowCardNum].transform.SetParent(card1Tf);
            allCards[nowCardNum].transform.localPosition = Vector2.zero;

            /* ------------------------------------------------------- */

            /* ----------------手札1枚目から手札2枚目への移動-------------- */

            allCards[nowCardNum - 1].transform.SetParent(card2Tf);
            allCards[nowCardNum - 1].transform.localPosition = Vector2.zero;

            /* ------------------------------------------------------- */

            /* ----------------手札2枚目から手札3枚目への移動-------------- */

            allCards[nowCardNum - 2].transform.SetParent(card3Tf);
            allCards[nowCardNum - 2].transform.localPosition = Vector2.zero;

            /* ------------------------------------------------------- */

            /* ----------------手札3枚目から山札への移動-------------- */

            allCards[nowCardNum - 3].transform.SetParent(deckTf);
            allCards[nowCardNum - 3].transform.localPosition = Vector2.zero;

            /* ------------------------------------------------------- */

            nowCardNum++;
        }
    }
}
