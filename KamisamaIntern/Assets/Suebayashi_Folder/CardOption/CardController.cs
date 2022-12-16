using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardController : MonoBehaviour
{
    // �J�[�h�I���^�[��
    public static bool canChooseCard = false;

    // �V�~�����[�g�^�[��
    public static bool isSimulatedOnMap = true;

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


    //RaycastAll�̈���
    private PointerEventData pointData;

    // Start is called before the first frame update
    void Start()
    {
        defaultCountTimeOfChoosingCard = countTimeOfChoosingCard;

        // �n�߂Ƀ}�b�v�ŃV�~�����[�g
        SimulateOnMap();


        //RaycastAll�̈���PointerEvenData���쐬
        pointData = new PointerEventData(EventSystem.current);
    }

    // Update is called once per frame
    void Update()
    {
        /* �J�[�h��I�Ԃ����ނɓ��� */
        if (canChooseCard == true)
        {
            // �J�E���g�_�E���J�n
            CountTimeOfChoosingCard();

            /* ------------------------�J�[�h���N���b�N�����ۂ̏���------------------------ */

            //RaycastAll�̌��ʊi�[�p�̃��X�g�쐬
            List<RaycastResult> RayResult = new List<RaycastResult>();

            if (Input.GetMouseButtonDown(0))
            {
                //PointerEvenData�ɁA�}�E�X�̈ʒu���Z�b�g
                pointData.position = Input.mousePosition;

                //RayCast�i�X�N���[�����W�j
                EventSystem.current.RaycastAll(pointData, RayResult);

                foreach (RaycastResult result in RayResult)
                {
                    if (result.gameObject.name == "CardImage(Clone)")
                    {
                        /* �J�[�h���N���b�N���ꂽ�ۂɍs������ */
                        Debug.Log("�I�΂ꂽ�J�[�h�F"�@+ result.gameObject.tag);
                        isChoseCard = true;
                        ChoseCard();
                    }
                }
            }

            /* ------------------------------------------------------------------- */
        }
        /* ---------------------------------------------- */
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
        Debug.Log("�J�[�h���ǉ������");

        Invoke("AllowChooseCard", timeOfSimulation);
    }

    // �J�[�h�I���\���Ԃɍs���鏈��
    private void AllowChooseCard()
    {
        isSimulatedOnMap = false; // �����ŁAAddCard�X�N���v�g��AddAndDiscardCard�֐������s�����
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

        isChoseCard = false;
        canChooseCard = false;
        isSimulatedOnMap = true;

        SimulateOnMap();
    }
}