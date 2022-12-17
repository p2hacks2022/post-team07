using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSkillController : MonoBehaviour
{
    //�Ă��쌴�ɕς�����
    private int burntCount;

    // ��
    public void ThunderCardEffect()
    {
        //�{�^���Ăяo���̍ۂ̏�����
        burntCount = 0;

        //List�̐錾
        List<GameObject> fields = new List<GameObject>();

        //Field�^�O���t�����I�u�W�F�N�g���������擾
        fields.AddRange(GameObject.FindGameObjectsWithTag("Field"));

        //Sea�^�O���t�����I�u�W�F�N�g���C���擾
        fields.AddRange(GameObject.FindGameObjectsWithTag("Sea"));

        //WorldTree�^�O���t�����I�u�W�F�N�g�����E�����擾
        fields.AddRange(GameObject.FindGameObjectsWithTag("WorldTree"));
        Debug.Log("���̌��ʔ����I�I�I");

        //�擾���������S�Ăɑ�����s��
        foreach (GameObject field in fields)
        {
            //0��1�ŗ����擾
            int rnd = Random.Range(0, 2);
            //�������P�ō쓮
            if (rnd == 1)
            {
                //Resouces�t�@�C������ABurnt_Field�v���n�u���擾
                GameObject prefab = (GameObject)Resources.Load("Burnt_Field");
                //Burnt_Field�𕡐�
                GameObject cloneBurnt = Instantiate(prefab, field.transform.position, Quaternion.identity);

                //Field�I�u�W�F�N�g���폜
                Destroy(field);

                //�J�E���g�𑝂₷
                burntCount++;

                //�J�E���g��10�ō쓮
                if (burntCount == 10)
                {
                    //���[�v�𔲂���
                    break;
                }
            }
        }
    }

    // ���z
    public void SunCardEffect()
    {
        //List�̐錾
        List<GameObject> seas = new List<GameObject>();

        //Sea�^�O���t�����I�u�W�F�N�g���C���擾
        seas.AddRange(GameObject.FindGameObjectsWithTag("Sea"));
        Debug.Log("���z�̌��ʔ����I�I�I");

        foreach (GameObject sea in seas)
        {
            int rnd = Random.Range(0, 2);
            //�������P�ō쓮
            if (rnd == 1)
            {
                //Resouces�t�@�C������ABurnt_Field�v���n�u���擾
                GameObject prefab = (GameObject)Resources.Load("Burnt_Field");
                //Burnt_Field�𕡐�
                GameObject cloneBurnt = Instantiate(prefab, sea.transform.position, Quaternion.identity);

                //Field�I�u�W�F�N�g���폜
                Destroy(sea);

                //�J�E���g�𑝂₷
                burntCount++;

                //�J�E���g��5�ō쓮
                if (burntCount == 5)
                {
                    //���[�v�𔲂���
                    break;
                }
            }
        }
    }

    //�b�݂̉J�̌���
    public void RainCardEffect()
    {
        //Field�^�O���t�����I�u�W�F�N�g���������擾
        GameObject[] fields = GameObject.FindGameObjectsWithTag("Field");
        Debug.Log("�b�݂̉J�̌��ʔ����I�I�I");

        // �b�݂̉J
        //�擾���������S�Ăɑ�����s��
        foreach (GameObject field in fields)
        {
            //�����̎q�I�u�W�F�N�g�̐��𐔂���i�����Ȃǂ��Ȃ���΁A�O�ɂȂ�j
            int objCount = field.transform.childCount;

            //�q�I�u�W�F�N�g���O�ł���΍쓮
            if (objCount == 0)
            {
                //�����𐶐�
                int rnd = Random.Range(0, 100);

                //0�`99�̂����A�P���o����쓮�i�m��1���j
                if (rnd == 1)
                {
                    //Resouces�t�@�C������Atree�v���n�u���擾
                    GameObject prefab = (GameObject)Resources.Load("tree");

                    //tree�𕡐�
                    GameObject cloneTree = Instantiate(prefab, field.transform.position, Quaternion.identity);

                    //tree�̐e��field�Ɏw��
                    //cloneTree.transform.parent = field.transform;
                    Destroy(field);

                    Debug.Log("�؂��쐬");
                }
            }
        }
    }

    // ���E��
    public void PlantCardEffect()
    {
        //List�̐錾
        List<GameObject> fields = new List<GameObject>();

        //Field�^�O���t�����I�u�W�F�N�g���������擾
        fields.AddRange(GameObject.FindGameObjectsWithTag("Field"));

        Debug.Log("���E���̌��ʔ����I�I�I");

        foreach (GameObject field in fields)
        {
            int rnd = Random.Range(0, 2);
            if (rnd == 1)
            {

                //Resouces�t�@�C������ABurnt_Field�v���n�u���擾
                GameObject prefab = (GameObject)Resources.Load("WorldTree");
                //Burnt_Field�𕡐�
                GameObject cloneBurnt = Instantiate(prefab, field.transform.position, Quaternion.identity);

                //Field�I�u�W�F�N�g���폜
                Destroy(field);

                break;
            }
        }
    }

    // �ˑR�ψ�
    public void MutationCardEffect()
    {
        //Field�^�O���t�����I�u�W�F�N�g���������擾
        GameObject[] fields = GameObject.FindGameObjectsWithTag("Field");
        Debug.Log("�ˑR�ψق̌��ʔ����I�I�I");

        //�擾���������S�Ăɑ�����s��
        foreach (GameObject field in fields)
        {
            if (field.GetComponent<FieldController>() != null)
            {
                //field��FieldController���擾
                FieldController myField = field.GetComponent<FieldController>();
                //�m�������߂�ۂ̍ő�l���X�V
                myField.max = 20;
            }
        }
    }

    // 覐�
    public void MeteorCardEffect()
    {
        //�Ăяo���̍ۂ̏�����
        burntCount = 0;

        //List�̐錾
        List<GameObject> fields = new List<GameObject>();

        //Field�^�O���t�����I�u�W�F�N�g���������擾
        fields.AddRange(GameObject.FindGameObjectsWithTag("Field"));

        //Sea�^�O���t�����I�u�W�F�N�g���C���擾
        fields.AddRange(GameObject.FindGameObjectsWithTag("Sea"));

        //WorldTree�^�O���t�����I�u�W�F�N�g�����E�����擾
        fields.AddRange(GameObject.FindGameObjectsWithTag("WorldTree"));
        Debug.Log("覐΂̌��ʔ����I�I�I");

        //�擾���������S�Ăɑ�����s��
        foreach (GameObject field in fields)
        {
            //0��1�ŗ�������
            int rnd = Random.Range(0, 2);
            //�������P�ō쓮
            if (rnd == 1)
            {
                //Resouces�t�@�C������ABurnt_Field�v���n�u���擾
                GameObject prefab = (GameObject)Resources.Load("Burnt_Field");
                //Burnt_Field�𕡐�
                GameObject cloneBurnt = Instantiate(prefab, field.transform.position, Quaternion.identity);

                //Field�I�u�W�F�N�g���폜
                Destroy(field);

                //�J�E���g�𑝂₷
                burntCount++;

                //�J�E���g��25�ō쓮
                if (burntCount == 25)
                {
                    //���[�v�𔲂���
                    break;
                }
            }
        }
    }

    // �u�a
    public void DiseaseCardEffect()
    {
        //List�̐錾
        List<GameObject> humans = new List<GameObject>();

        humans.AddRange(GameObject.FindGameObjectsWithTag("Human"));

        Debug.Log("�u�a�̌��ʔ����I�I�I");

        foreach (GameObject human in humans)
        {
            int rnd = Random.Range(0, 3);
            if (rnd == 0)
            {
                Destroy(human);
            }
        }
    }

    // ���J
    public void HeavyRainCardEffect()
    {
        List<GameObject> burns = new List<GameObject>();

        burns.AddRange(GameObject.FindGameObjectsWithTag("Burnt_Field"));

        Debug.Log("���J�̌��ʔ����I�I�I");

        foreach (GameObject burn in burns)
        {
            //Resouces�t�@�C������AField�v���n�u���擾
            GameObject prefab = (GameObject)Resources.Load("Field");
            //Field�𕡐�
            GameObject cloneBurnt = Instantiate(prefab, burn.transform.position, Quaternion.identity);

            //Field�I�u�W�F�N�g���폜
            Destroy(burn);
        }
    }
}
