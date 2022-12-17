using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardDataBase", menuName = "CreateCardDataBase")]//  CreateからCreateCardというメニューを表示し、Cardを作成する
public class CardDataBase : ScriptableObject
{
    [SerializeField]
    private List<Card> cardLists = new List<Card>();//  Cardのリストを新しく生成する

    public List<Card> GetCardLists()//  Cardのリストがあったら、
    {
        return cardLists;//  cardListsに返す
    }
}