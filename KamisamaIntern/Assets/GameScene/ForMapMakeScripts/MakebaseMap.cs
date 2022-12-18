/*
 * �}�b�v�p�̒n�ʂ������_���Ő�������悤�ɃX�N���v�g�\�z
 * �}�b�v�̒n�ʂɂ�
 * field sea
 * �̂Q��ނ̃h�b�g�G���p������
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakebaseMap : MonoBehaviour
{
    //�w�i�ƂȂ�C���[�W[field][sea]���i�[����z��
    [SerializeField]
    private GameObject[] GroundImages;

    //�w�i�ƂȂ�C���[�W[tree][animal][house]���i�[����z��
    [SerializeField]
    private GameObject[] OverImages;

    //�w�i�ƂȂ�C���[�W[black]���i�[����
    [SerializeField]
    private GameObject Black;

    //��ʂ̍��[��̏����l
    public float value_x;
    public float value_y;

    /// <summary>
    /// �ufield�v�usea�v�ǂ���𐶐����邩�̃����_���ϐ�����
    /// ���݁@���n�F�C�@= 29:71 �����炻�̊����Ő���
    /// </summary>
    private int ground_random_value;

    /// <summary>
    /// �uanimal�v�uhouse�v�utree�v�̂ǂ�𐶐����邩�̃����_���ϐ�����
    /// ���݁@�����F�؁F�� : �󔒁@= 8 : 17 : 15 : 60 �����炻�̊����Ő���
    /// </summary>
    private int over_random_value;


    // Start is called before the first frame update
    void Start()
    {
        //�c�̃}�X�ڕ���for��
        for (int j = 0; j < 9; j++)
        {
            //���̃}�X�ڕ���for��
            for (int i = 0; i < 8; i++)
            {

                //OutFrame_Put(j, i);

                //1�`100�̒����烉���_���ɒl�����
                ground_random_value = Random.Range(1, 101);
                over_random_value = Random.Range(1, 101);

                if (ground_random_value % 3 == 0)
                {
                    //�v���n�u�����ɃI�u�W�F�N�g�𐶐�����
                    if (ground_random_value > 0 && ground_random_value <= 40)
                    {   //40%�͊C
                        GameObject instance = Instantiate(GroundImages[0], new Vector3(value_x, value_y, 0.0f), Quaternion.identity);
                    }
                    else if (ground_random_value > 40 && ground_random_value < 101)
                    {
                        //60���͗�
                        GameObject instance = Instantiate(GroundImages[1], new Vector3(value_x, value_y, 0.0f), Quaternion.identity);
                    }
                }

                //OverItem_Put(over_random_value);

                //���ɂЂƂړ�
                value_x += 0.89f;
            }

            //x�������������l�ɁAy�������Ɉ����
            value_x = -7.5f;
            value_y -= 0.88f;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }


    /// <summary>
    /// �uanimal�v�uhouse�v�utree�v�̂ǂ�𐶐����邩�̃����_���ϐ�����
    /// ���݁@�����F�؁F�� : �󔒁@= 8 : 17 : 15 : 60 �����炻�̊����Ő���
    /// </summary>
    public void OverItem_Put(int value)
    {
        //�v���n�u�����ɃI�u�W�F�N�g�𐶐�����
        if (value > 0 && value <= 8)
        {
            GameObject instance = Instantiate(OverImages[0], new Vector3(value_x, value_y, 0.0f), Quaternion.identity);
        }
        else if (value > 8 && value <= 16)
        {
            GameObject instance = Instantiate(OverImages[1], new Vector3(value_x, value_y, 0.0f), Quaternion.identity);
        }
        else if (value > 16 && value <= 24)
        {
            GameObject instance = Instantiate(OverImages[2], new Vector3(value_x, value_y, 0.0f), Quaternion.identity);
        }
        else if (value > 24 && value < 101)
        {
            // GameObject instance = Instantiate(OverImages[3], new Vector3(value_x, value_y, 0.0f), Quaternion.identity);
        }
    }

    /// <summary>
    /// ��b�ƂȂ�[black]���O�g�Ƀ����_���Ŕz�u
    /// 
    /// �O�g�̎��̂ݎ��s���ꂽ���X�N���v�g
    /// j=0,8�̎��@���́@(i=0,17�@���@j=1�`7)�@�̎�
    /// </summary>
    public void OutFrame_Put(int value_j, int value_i)
    {
        int tmp_value = Random.Range(0, 4); ;

        if (tmp_value % 3 == 0)
        {
            //�v���n�u�����ɃI�u�W�F�N�g�𐶐�����
            if (value_j == 0 || value_j == 8)
            {
                GameObject instance = Instantiate(Black, new Vector3(value_x, value_y, 0.0f), Quaternion.identity);
            }

            //�v���n�u�����ɃI�u�W�F�N�g�𐶐�����
            if (value_i == 0 || value_i == 17)
            {
                GameObject instance = Instantiate(Black, new Vector3(value_x, value_y, 0.0f), Quaternion.identity);
            }
        }


    }
}