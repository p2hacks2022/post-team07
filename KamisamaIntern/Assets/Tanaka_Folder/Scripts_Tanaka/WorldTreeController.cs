using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldTreeController : MonoBehaviour
{
    //���R�|�C���g
    [SerializeField]
    private int naturePoint;

    // Start is called before the first frame update
    void Start()
    {
        //�ϐ��̏�����
        naturePoint = 1;
    }

    // Update is called once per frame
    void Update()
    {

    }

    //�Ԃ������Ƃ��̏���
    private void OnCollisionEnter2D(Collision2D col)
    {
        //�Ԃ������I�u�W�F�N�g�̃^�O�ŕ���
        switch (col.gameObject.tag)
        {
            /*
            //�l�Ԃ̏ꍇ
            case "Human":
                //�I�u�W�F�N�g�폜
                Destroy(this.gameObject);
                break;
        
            */}
    }
}
