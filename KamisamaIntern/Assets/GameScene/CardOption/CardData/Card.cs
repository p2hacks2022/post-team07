using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Card", menuName = "CreateCard")]
public class Card : ScriptableObject
{
    [SerializeField]
    private string tag; //�J�[�h�̃^�O

    [SerializeField]
    private string cardName; // �J�[�h�̖��O

    [SerializeField]
    private string cardInformation; // �J�[�h�̃X�L�����

    public string GetTag()//  �^�O����͂�����A
    {
        return tag;//  tag�ɕԂ�
    }

    public string GetCardName()//  �J�[�h�̖��O����͂�����A
    {
        return cardName; // cardName�ɕԂ�
    }

    public string GetCardInformation() // �J�[�h�̃X�L��������͂�����A
    {
        return cardInformation; // cardInformation�ɕԂ�
    }
}