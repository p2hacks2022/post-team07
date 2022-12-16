using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour
{
    // �J�[�h�I���^�[��
    public static bool canChooseCard = false;

    // �V�~�����[�g�^�[��
    private bool isSimulatedOnMap;

    // �J�[�h���I�����ꂽ���ǂ���
    private bool isChoseCard = false;

    // �J�[�h�I���^�[���̐�������
    [SerializeField]
    private float countTimeOfChoosingCard;

    // �V�~�����[�g�̎���
    [SerializeField]
    private float timeOfSimulation;

    // �J�[�h��I������ۂ̐������Ԃ̏����l��ۑ�
    private float defaultCountTimeOfChoosingCard;

    // Start is called before the first frame update
    void Start()
    {
        defaultCountTimeOfChoosingCard = countTimeOfChoosingCard;

        // �n�߂Ƀ}�b�v�ŃV�~�����[�g
        SimulateOnMap();
    }

    // Update is called once per frame
    void Update()
    {
        if (canChooseCard == true)
        {
            CountTimeOfChoosingCard();
        }
    }

    // �V�~�����[�g���J�n���ꂽ�ۂɍs������
    private void SimulateOnMap()
    {
        AddCard(); //�J�[�h��1���ǉ������֐����Ăяo��

        Debug.Log("�}�b�v�ŃV�~�����[�g����");

        /* �}�b�v�̃V�~�����[�g���� */
    }

    // �J�[�h��1���ǉ�����A1���j������鏈��
    private void AddCard()
    {
        Debug.Log("�J�[�h��1���ǉ������");

        /* �J�[�h���ꖇ�ǉ�����A1���j������鏈�� */

        Invoke("AllowChooseCard", timeOfSimulation);
    }

    // �J�[�h�I���\���Ԃɍs���鏈��
    private void AllowChooseCard()
    {
        isSimulatedOnMap = false;
        canChooseCard = true;

        Debug.Log("�J�[�h��I�����邽����");
    }

    /* �J�[�h��I������^�[���̐������Ԃ��J�E���g���鏈��
    �@ �i�J�E���g�̓r���ŃJ�[�h���I�����ꂽ��J�E���g�𒆒f�j*/
    private void CountTimeOfChoosingCard()
    {
        countTimeOfChoosingCard -= Time.deltaTime;
        Debug.Log(countTimeOfChoosingCard);

        // �J�E���g�̓r���ŃJ�[�h���I�����ꂽ�炻�̍ۂ̏�����
        if (isChoseCard == true)
        {
            countTimeOfChoosingCard = defaultCountTimeOfChoosingCard; // �������Ԃ̏�����
            canChooseCard = false;
            ChoseCard();
        }
        // �����I������Ȃ��܂܃J�E���g��0�ɂȂ�����V�~�����[�g��
        else if (isChoseCard == false && countTimeOfChoosingCard <= 0)
        {
            countTimeOfChoosingCard = defaultCountTimeOfChoosingCard; // �������Ԃ̏�����
            canChooseCard = false;
            isSimulatedOnMap = true;
            SimulateOnMap();
        }
    }

    // �J�[�h���I�����ꂽ�ۂɍs������
    private void ChoseCard()
    {
        Debug.Log("�J�[�h���I�����ꂽ");

        /* �I�������J�[�h�̔��ʂ��s�� */

        isChoseCard = false;
        isSimulatedOnMap = true;

        SimulateOnMap();
    }

    // �J�[�h���N���b�N���ꂽ�ۂɌĂяo�����֐�
    private void CardClicked()
    {
        /* �J�[�h���N���b�N���ꂽ�ۂɍs������ */
        isChoseCard = true;
    }
}
