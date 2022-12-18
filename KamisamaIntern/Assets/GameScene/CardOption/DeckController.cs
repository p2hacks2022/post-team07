using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class DeckController : MonoBehaviour
{
    // DeckのPrefab
    [SerializeField] 
    Image cardPrefab;

    // 山札の枚数
    [SerializeField] 
    int deckCardNum;

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
    private Sprite[] deckType;

    //スキルカードの種類数
    [SerializeField]
    private int deckTypeNum;

    // 山札カード用のListの初期化
    List<Image> deckCards = new List<Image>();

    // Start is called before the first frame update
    void Start()
    {
        // 山札を作る
        for (int i = 0; i < deckCardNum; i++)
        {
            Image c = Instantiate(cardPrefab, transform, false);

            //Listにcardを追加していく
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
        //Debug.Log("カードが追加された");

        if ((nowCardNum+1) <= deckCards.Count)
        {
            if (nowCardNum == 0)
            {
                for (int i = 0; i < 3; i++)
                {
                    // カードの効果をランダムに選ぶ
                    int randomDeckTypeNum2 = Random.Range(0, deckTypeNum);

                    // 選んだカードの効果画像を設定する
                    deckCards[i].sprite = deckType[randomDeckTypeNum2];
                }

                /*
                // 山札から手札の3枚目に1枚移動
                deckCards[0].transform.DOMove(card3Tf.position, 1.0f)
                    .SetEase(Ease.InCirc)
                    .OnComplete(() => deckCards[0].transform.SetParent(card3Tf));
                */
                // 山札から手札の3枚目に1枚移動
                //カードを別の山の子要素にする
                deckCards[0].transform.SetParent(card3Tf);
                //カードのlocalPositionを0にする
                deckCards[0].transform.localPosition = Vector2.zero;

                /*
                // 山札から手札の2枚目に1枚移動
                deckCards[1].transform.DOMove(card2Tf.position, 1.0f)
                    .SetEase(Ease.InCirc)
                    .OnComplete(() => deckCards[1].transform.SetParent(card2Tf));
                */
                // 山札から手札の2枚目に1枚移動
                deckCards[1].transform.SetParent(card2Tf);
                //カードのlocalPositionを0にする
                deckCards[1].transform.localPosition = Vector2.zero;

                nowCardNum += 2;
            }

            // カードの効果をランダムに選ぶ
            int randomDeckTypeNum = Random.Range(0, deckTypeNum);

            // 選んだカードの効果画像を設定する
            deckCards[nowCardNum].sprite = deckType[randomDeckTypeNum];

            /*
            // 山札から手札の1枚目に1枚移動
            deckCards[nowCardNum].transform.DOMove(card1Tf.position, 1.0f)
                .SetEase(Ease.InCirc)
                .OnComplete(() => deckCards[nowCardNum].transform.SetParent(card1Tf));
            */

            // 山札から手札の1枚目に1枚移動
            deckCards[nowCardNum].transform.SetParent(card1Tf);
            //カードのlocalPositionを0にする
            deckCards[nowCardNum].transform.localPosition = Vector2.zero;


            if (nowCardNum > 0)
            {
                /*
                // 手札1枚目から手札2枚目へカードが移動
                deckCards[nowCardNum - 1].transform.DOMove(card2Tf.position, 1.0f)
                    .SetEase(Ease.InCirc)
                    .OnComplete(() => deckCards[nowCardNum - 1].transform.SetParent(card2Tf));
                */

                // 手札1枚目から手札の2枚目に1枚移動
                deckCards[nowCardNum - 1].transform.SetParent(card2Tf);
                //カードのlocalPositionを0にする
                deckCards[nowCardNum - 1].transform.localPosition = Vector2.zero;
            }
            
            if (nowCardNum > 1)
            {
                /*
                // 手札2枚目から手札3枚目へカードが移動
                deckCards[nowCardNum - 2].transform.DOMove(card3Tf.position, 1.0f)
                    .SetEase(Ease.InCirc)
                    .OnComplete(() => deckCards[nowCardNum - 2].transform.SetParent(card3Tf));
                */

                // 手札2枚目から手札の3枚目に1枚移動
                deckCards[nowCardNum - 2].transform.SetParent(card3Tf);
                //カードのlocalPositionを0にする
                deckCards[nowCardNum].transform.localPosition = Vector2.zero;
            }

            if (nowCardNum > 2)
            {
                //手札3枚目から山札に1枚移動
                deckCards[nowCardNum - 3].transform.SetParent(deckTf);

                //手札3枚目から山札に1枚移動
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
