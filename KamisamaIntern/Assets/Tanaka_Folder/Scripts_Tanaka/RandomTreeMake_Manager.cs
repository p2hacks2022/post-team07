using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTreeMake_Manager : MonoBehaviour
{
    //�w�i�ƂȂ�C���[�W[black]���i�[����
    [SerializeField]
    private GameObject TreeObject;

    //��ʂ̍��[��̏����l
    public float firstposi_value_x;
    public float firstposi_value_y;

    /// <summary>
    /// �؂�\�����邩���Ȃ����̔��f�p�̃����_���ϐ����i�[����ꏊ
    /// </summary>
    private int ground_random_value;


    // Start is called before the first frame update
    void Start()
    {
        //�c�̃}�X�ڕ���for��
        for (int j = 0; j < 9; j++)
        {
            //���̃}�X�ڕ���for��
            for (int i = 0; i < 8; i++)
            {

                //1�`100�̒����烉���_���ɒl�����
                ground_random_value = Random.Range(1, 101);

                if (ground_random_value % 3 == 0)
                {
                    //�v���n�u�����ɃI�u�W�F�N�g�𐶐�����

                    GameObject instance = Instantiate(TreeObject, new Vector3(firstposi_value_x, firstposi_value_y, 0.0f), Quaternion.identity);

                }

                //���ɂЂƂړ�
                firstposi_value_x += 0.89f;
            }

            //x�������������l�ɁAy�������Ɉ����
            firstposi_value_x = -7.5f;
            firstposi_value_y -= 0.88f;
        }
    }

}
