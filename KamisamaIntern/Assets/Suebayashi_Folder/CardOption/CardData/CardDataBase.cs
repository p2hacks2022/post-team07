using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardDataBase", menuName = "CreateCardDataBase")]//  Create����CreateCard�Ƃ������j���[��\�����ACard���쐬����
public class CardDataBase : ScriptableObject
{
    [SerializeField]
    private List<Card> cardLists = new List<Card>();//  Card�̃��X�g��V������������

    public List<Card> GetCardLists()//  Card�̃��X�g����������A
    {
        return cardLists;//  cardLists�ɕԂ�
    }
}