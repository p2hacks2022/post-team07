using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class CardController : MonoBehaviour
{
    // �J�[�h�I���^�[��
    public static bool canChooseCard = false;

    // �V�~�����[�g�^�[��
    public static bool isSimulatedOnMap = true;

    // �J�[�h���I�����ꂽ���ǂ���
    public static bool isChoseCard = false;

    // �J�[�h�I���^�[���̐�������
    [SerializeField]
    private float countTimeOfChoosingCard;

    // �J�[�h��I�ԍۂ̃J�E���g�_�E����\��
    [SerializeField]
    private TextMeshProUGUI countTimeOfChoosingCardText;

    // �V�~�����[�g�̎���
    [SerializeField]
    private float timeOfSimulation;

    // �J�[�h��I������ۂ̐������Ԃ̏����l��ۑ�
    private float defaultCountTimeOfChoosingCard;

    // �I�������J�[�h�̃^�O���i�[
    public static string choseCardTag;

    //RaycastAll�̈���
    private PointerEventData pointData;

    // ����{�^���������ꂽ���ǂ���
    public static bool isPushedChooseCardButton;

    // �J�[�\���u���Ă���摜�̃^�O��ۑ�
    public static string tagCursorOnCard;

    // �J�[�h�̏���񎦂��邩�ǂ���
    public static bool shouldShowCardInfomation;

    // �J�[�h�X�L���𔭓����邽�߂̊֐����܂Ƃ܂��Ă���X�N���v�g����C���X�^���X�𐶐�
    public CardSkillController cardSkillController;

    // �����ڂ̃J�[�h���I�����ꂽ����ۑ�
    public static int NumOfChoosingcard;

    // �ǂ̃J�[�h���I������Ă��邩���킩��p�l��
    [SerializeField]
    private GameObject[] chosingPanel;

    // Start is called before the first frame update
    void Start()
    {
        defaultCountTimeOfChoosingCard = countTimeOfChoosingCard;

        PanelFalse();

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

            //PointerEvenData�ɁA�}�E�X�̈ʒu���Z�b�g
            pointData.position = Input.mousePosition;

            //RayCast�i�X�N���[�����W�j
            EventSystem.current.RaycastAll(pointData, RayResult);

            foreach (RaycastResult result in RayResult)
            {
                if (result.gameObject.name == "CardImage(Clone)")
                {
                    // �J�[�\�����u���ꂽ�摜�̃^�O��ۑ�����
                    tagCursorOnCard = result.gameObject.tag;
                    // �J�[�\�����u���ꂽ�ۂɃJ�[�h�̏���񎦂���
                    shouldShowCardInfomation = true;
                    Debug.Log(tagCursorOnCard);

                    if (Input.GetMouseButtonDown(0))
                    {
                        /* �J�[�h���N���b�N���ꂽ�ۂɍs������ */
                        // �I�������J�[�h�̃^�O��ۑ�
                        choseCardTag = result.gameObject.tag;
                        isChoseCard = true;
                        //ChoseCard();
                    }
                }else if(result.gameObject.tag == "CardPanel")
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        switch(result.gameObject.name){
                            case "MyCard1":
                                NumOfChoosingcard = 1;
                                chosingPanel[0].SetActive(true);
                                chosingPanel[1].SetActive(false);
                                chosingPanel[2].SetActive(false);
                                break;
                            case "MyCard2":
                                NumOfChoosingcard = 2;
                                chosingPanel[0].SetActive(false);
                                chosingPanel[1].SetActive(true);
                                chosingPanel[2].SetActive(false);
                                break;
                            case "MyCard3":
                                NumOfChoosingcard = 3;
                                chosingPanel[0].SetActive(false);
                                chosingPanel[1].SetActive(false);
                                chosingPanel[2].SetActive(true);
                                break;
                            default:
                                NumOfChoosingcard = 0;
                                break;
                        }
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
        // �J�[�h��I�Ԃ����ނ̎��Ԃ�����
        countTimeOfChoosingCard -= Time.deltaTime;
        Debug.Log(countTimeOfChoosingCard);
        countTimeOfChoosingCardText.text = "�y�J�[�h�I�����[�h�z\n" + "  ����" + Mathf.Round(countTimeOfChoosingCard*100.0f)/100 + "�b�I";

        // �J�E���g�̓r���ŃJ�[�h���I�����ꂽ�炻�̍ۂ̏�����
        if (isChoseCard == true && isPushedChooseCardButton == true)
        {
            PanelFalse();
            countTimeOfChoosingCard = 0f;
            countTimeOfChoosingCardText.text = "�y�V�~�����[�V�������[�h�z";
            countTimeOfChoosingCard = defaultCountTimeOfChoosingCard; // �������Ԃ̏�����
            canChooseCard = false;
            isPushedChooseCardButton = false;
            shouldShowCardInfomation = false;
            ChoseCard();
        }
        // �����I������Ȃ��܂܃J�E���g��0�ɂȂ�����V�~�����[�g��
        else if (countTimeOfChoosingCard <= 0 && isPushedChooseCardButton == false)
        {
            NumOfChoosingcard = 0;
            PanelFalse();
            countTimeOfChoosingCard = 0f;
            countTimeOfChoosingCardText.text = "�y�V�~�����[�V�������[�h�z";
            countTimeOfChoosingCard = defaultCountTimeOfChoosingCard; // �������Ԃ̏�����
            canChooseCard = false;
            isSimulatedOnMap = true;
            shouldShowCardInfomation = false;
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

    // ����{�^�����N���b�N�����ۂɍs������
    public void PushChooseCardButton()
    {
        // �J�[�h��I�ׂ邽���ނŃJ�[�h��I��ł�����
        if (canChooseCard == true�@&& isChoseCard == true)
        {
            isPushedChooseCardButton = true;
            Debug.Log("�I�΂ꂽ�J�[�h�F" + choseCardTag);

            switch (choseCardTag)
            {
                case "kaminari":
                    cardSkillController.ThunderCardEffect();
                    break;
                case "rain":
                    cardSkillController.RainCardEffect();
                    break;
                case "sun":
                    cardSkillController.SunCardEffect();
                    break;
                case "world_tree":
                    cardSkillController.PlantCardEffect();
                    break;
                case "mutant":
                    cardSkillController.MutationCardEffect();
                    break;
                case "innseki":
                    cardSkillController.MeteorCardEffect();
                    break;
                case "virus":
                    cardSkillController.DiseaseCardEffect();
                    break;
                case "heavy_rain":
                    cardSkillController.HeavyRainCardEffect();
                    break;
                case "industrial_revolution":
                    cardSkillController.IndustrialCardEffect();
                    break;
                case "starting_agriculture":
                    cardSkillController.AgricultureCardEffect();
                    break;
                default:
                    Debug.Log(" ���̑� ");
                    break;
                    
            }
        }
    }

    private void PanelFalse()
    {
        for(int i = 0; i < 3; i++)
        {
            chosingPanel[i].SetActive(false);
        }
    }
}
