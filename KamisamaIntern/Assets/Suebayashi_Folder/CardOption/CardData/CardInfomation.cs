using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CardInfomation : MonoBehaviour
{
    [SerializeField]
    private CardDataBase cardDataBase; //使用するデータベース

    //  ディクショナリーをCardから作成し、numOfCardにCardの番号を振る
    private Dictionary<Card, int> numOfCard = new Dictionary<Card, int>();

    // カードのタイトル
    [SerializeField]
    private TextMeshProUGUI cardTitle;

    // カードのスキル説明
    [SerializeField]
    private TextMeshProUGUI cardInfomation;

    // カードの情報を表示するポップアップ
    [SerializeField]
    private GameObject popupOfCardInfomation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // カーソルがカードの上に置かれたら
        if(CardController.shouldShowCardInfomation == true)
        {
            // タグから検索してカードの情報を表示
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
