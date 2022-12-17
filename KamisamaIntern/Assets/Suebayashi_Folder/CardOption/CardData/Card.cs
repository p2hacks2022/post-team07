using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Card", menuName = "CreateCard")]
public class Card : ScriptableObject
{
    [SerializeField]
    private string tag; //カードのタグ

    [SerializeField]
    private string cardName; // カードの名前

    [SerializeField]
    private string cardInformation; // カードのスキル情報

    public string GetTag()//  タグを入力したら、
    {
        return tag;//  tagに返す
    }

    public string GetCardName()//  カードの名前を入力したら、
    {
        return cardName; // cardNameに返す
    }

    public string GetCardInformation() // カードのスキル情報を入力したら、
    {
        return cardInformation; // cardInformationに返す
    }
}