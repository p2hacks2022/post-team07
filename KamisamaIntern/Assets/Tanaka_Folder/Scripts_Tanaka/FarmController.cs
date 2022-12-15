using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmController : MonoBehaviour
{
    //���b�Ɉ��̗͂����邩
    [SerializeField]
    private float decreaseHealth = 5.0f;

    //�̗͂���������܂ł̎���
    private float decreaseTime = 5.0f;

    //���W�|�C���g
    [SerializeField]
    private int developmentPoint;

    //���j�b�g�̗̑�
    [SerializeField]
    private int health;

    //�̗͏��
    [SerializeField]
    private int maxHealth;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //���Ԍo�ߏ���
        decreaseTime -= Time.deltaTime;

        //���Ԃ�0�ɂȂ�����s��
        if (decreaseTime <= 0f)
        {
            //�̗͂��P���炷
            health--;

            //���Ԃ����Ƃɖ߂�
            decreaseTime = 5.0f;
        }

        //�̗͂�0�ɂȂ�����s��
        if (health <= 0)
        {
            //���̃I�u�W�F�N�g����������
            Destroy(this.gameObject);
        }
    }

    //���̂ƂԂ������Ƃ��̏���
    private void OnCollisionEnter2D(Collision2D col)
    {
        //�Ԃ������I�u�W�F�N�g�̃^�O�ŕ���
        switch (col.gameObject.tag)
        {
            //�����̏ꍇ
            case "Animal":
                //�̗͑��₷
                health += 5;
                //���Ԃ����Ƃɖ߂�
                decreaseTime = 5.0f;
                //�̗͂̏�����z���Ă���ꍇ
                if (health > maxHealth)
                {
                    //�̗͂�̗͏���̐��l�܂Ŗ߂�
                    health = maxHealth;
                }
                break;
        }
    }
}
