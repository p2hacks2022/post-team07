using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseController : MonoBehaviour
{
    //���R�|�C���g
    [SerializeField]
    private int developePoint;

    // Start is called before the first frame update
    void Start()
    {
        //�ϐ��̏�����
        developePoint = 1;
    }

    // Update is called once per frame
    void Update()
    {

    }

    //�Ԃ������Ƃ��̏���
    private void OnCollisionEnter2D(Collision2D col)
    {

    }
}
