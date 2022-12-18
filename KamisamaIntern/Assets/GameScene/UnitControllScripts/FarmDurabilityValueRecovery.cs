using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmDurabilityValueRecovery : MonoBehaviour
{
    //���͔��}�X�̒��ɂ���؂��i�[���邽�߂̔z��
    [SerializeField]
    private GameObject[] Trees;

    //���͔��}�X�̒��ɂ��鑐�����i�[���邽�߂̔z��
    [SerializeField]
    private GameObject[] Field;

    //�V���ɐ��ݏo���Ƃ��ɎQ�Ƃ���l�Ԃ̃I�u�W�F�N�g
    [SerializeField]
    private GameObject Human;

    //�z��Ǘ��̂��߂̃|�C���^
    int treePointer = 0;
    int fieldPointer = 0;

    //�i�[���I������̂��m�F���邽��
    bool finTree = false;
    bool finField = false;

    //�ΏۑI��p�̉��ϐ�
    bool full1 = false;
    bool full2 = false;
    bool full3 = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()

    {
    }

    // when the GameObjects collider arrange for this GameObject to travel to the left of the screen
    void OnTriggerStay2D(Collider2D collider)
    {
        //�_���Collider����
        if (collider.gameObject.name != null)
        {
            Debug.Log(collider.gameObject.tag);

            //�z��̊i�[���I����ĂȂ����
            if (!finTree)
            {
                //Tree�̃^�O���t��������
                if (collider.gameObject.tag == "Tree")
                {
                    //�z��ɋ󂫂�����܂œ���Ă���
                    if (treePointer < 9)
                    {
                        Trees[treePointer] = collider.gameObject;

                    }
                    else
                    {
                        //�z��̋󂫂��Ȃ����炢���ꂽ��I���
                        finTree = true;
                    }

                    treePointer++;
                }
            }

            //�z��̊i�[���I����ĂȂ����
            if (!finField)
            {
                //Fielf�̃^�O���������̂�
                if (collider.gameObject.tag == "Field")
                {
                    //�i�[���Ă���
                    if (fieldPointer < 9)
                    {

                        Field[fieldPointer] = collider.gameObject;

                    }
                    else
                    {
                        finField = true;
                    }

                    fieldPointer++;
                }
            }


            if (!full1)
            {
                //�z�񖄂܂��Ă邩��
                if (finTree)
                {
                    ///
                    /// �̗͂�10�ȉ��ɂȂ�C��(house)�̎���8�^�C���ɖ�(tree)������ƁC��(tree)��1�����ϋv�l��5�񕜂���D
                    ///


                    //�z��̒����������_���őI��ŏ���
                    int k = Random.Range(0, Trees.Length);
                    Debug.Log("����΂ꂽ�̂�" + Trees[k]);
                    Destroy(Trees[k].gameObject);
                    full1 = true;

                }
            }

            if (!full2)
            {

                ///��(house)�̎���ɏ㉺���E�̂ǂ�Ƀj���Q��(human)��z�u����ꏊ������΁C5�b��1��j���Q��(human)��z�u����D//
                ///

                if (finField)
                {
                    //�z��̂Ȃ����������_���ɑI��Ől�Ԃƒu��������
                    int k = Random.Range(0, Field.Length);
                    Debug.Log("����΂ꂽ�̂�" + Field[k]);
                    Instantiate(Human, Field[k].transform.position, Quaternion.identity);
                    Human.transform.position = Field[k].gameObject.transform.position;
                    full2 = true;
                }
            }

        }
    }
}