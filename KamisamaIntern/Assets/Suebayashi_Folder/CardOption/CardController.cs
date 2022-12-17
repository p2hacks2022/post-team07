using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class CardController : MonoBehaviour
{
    // カード選択ターン
    public static bool canChooseCard = false;

    // シミュレートターン
    public static bool isSimulatedOnMap = true;

    // カードが選択されたかどうか
    public static bool isChoseCard = false;

    // カード選択ターンの制限時間
    [SerializeField]
    private float countTimeOfChoosingCard;

    // カードを選ぶ際のカウントダウンを表示
    [SerializeField]
    private TextMeshProUGUI countTimeOfChoosingCardText;

    // シミュレートの時間
    [SerializeField]
    private float timeOfSimulation;

    // カードを選択する際の制限時間の初期値を保存
    private float defaultCountTimeOfChoosingCard;

    // 選択したカードのタグを格納
    public static string choseCardTag;

    //RaycastAllの引数
    private PointerEventData pointData;

    // 決定ボタンが押されたかどうか
    public static bool isPushedChooseCardButton;

    // カーソル置いている画像のタグを保存
    public static string tagCursorOnCard;

    // カードの情報を提示するかどうか
    public static bool shouldShowCardInfomation;

    // カードスキルを発動するための関数がまとまっているスクリプトからインスタンスを生成
    public CardSkillController cardSkillController;

    // 何枚目のカードが選択されたかを保存
    public static int NumOfChoosingcard;

    // どのカードが選択されているかがわかるパネル
    [SerializeField]
    private GameObject[] chosingPanel;

    // Start is called before the first frame update
    void Start()
    {
        defaultCountTimeOfChoosingCard = countTimeOfChoosingCard;

        PanelFalse();

        // 始めにマップでシミュレート
        SimulateOnMap();

        //RaycastAllの引数PointerEvenDataを作成
        pointData = new PointerEventData(EventSystem.current);
    }

    // Update is called once per frame
    void Update()
    {
        /* カードを選ぶたいむに入る */
        if (canChooseCard == true)
        {
            // カウントダウン開始
            CountTimeOfChoosingCard();

            /* ------------------------カードをクリックした際の処理------------------------ */

            //RaycastAllの結果格納用のリスト作成
            List<RaycastResult> RayResult = new List<RaycastResult>();

            //PointerEvenDataに、マウスの位置をセット
            pointData.position = Input.mousePosition;

            //RayCast（スクリーン座標）
            EventSystem.current.RaycastAll(pointData, RayResult);

            foreach (RaycastResult result in RayResult)
            {
                if (result.gameObject.name == "CardImage(Clone)")
                {
                    // カーソルが置かれた画像のタグを保存する
                    tagCursorOnCard = result.gameObject.tag;
                    // カーソルが置かれた際にカードの情報を提示する
                    shouldShowCardInfomation = true;
                    Debug.Log(tagCursorOnCard);

                    if (Input.GetMouseButtonDown(0))
                    {
                        /* カードがクリックされた際に行う処理 */
                        // 選択したカードのタグを保存
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

    // シミュレートが開始された際に行う処理
    private void SimulateOnMap()
    {
        AddCard(); //カードが1枚追加される関数を呼び出す

        Debug.Log("マップでシミュレートする");

        /* マップのシミュレート処理 */
    }

    // カードが1枚追加され、1枚破棄される処理
    private void AddCard()
    {
        Debug.Log("カードが追加される");

        Invoke("AllowChooseCard", timeOfSimulation);
    }

    // カード選択可能時間に行われる処理
    private void AllowChooseCard()
    {
        isSimulatedOnMap = false; // ここで、AddCardスクリプトでAddAndDiscardCard関数が実行される
        canChooseCard = true;

        Debug.Log("カードを選択するたいむ");
    }

    /* カードを選択するターンの制限時間をカウントする処理
    　 （カウントの途中でカードが選択されたらカウントを中断）*/
    private void CountTimeOfChoosingCard()
    {
        // カードを選ぶたいむの時間を刻む
        countTimeOfChoosingCard -= Time.deltaTime;
        Debug.Log(countTimeOfChoosingCard);
        countTimeOfChoosingCardText.text = "【カード選択モード】\n" + "  あと" + Mathf.Round(countTimeOfChoosingCard*100.0f)/100 + "秒！";

        // カウントの途中でカードが選択されたらその際の処理へ
        if (isChoseCard == true && isPushedChooseCardButton == true)
        {
            PanelFalse();
            countTimeOfChoosingCard = 0f;
            countTimeOfChoosingCardText.text = "【シミュレーションモード】";
            countTimeOfChoosingCard = defaultCountTimeOfChoosingCard; // 制限時間の初期化
            canChooseCard = false;
            isPushedChooseCardButton = false;
            shouldShowCardInfomation = false;
            ChoseCard();
        }
        // 何も選択されないままカウントが0になったらシミュレートへ
        else if (countTimeOfChoosingCard <= 0 && isPushedChooseCardButton == false)
        {
            NumOfChoosingcard = 0;
            PanelFalse();
            countTimeOfChoosingCard = 0f;
            countTimeOfChoosingCardText.text = "【シミュレーションモード】";
            countTimeOfChoosingCard = defaultCountTimeOfChoosingCard; // 制限時間の初期化
            canChooseCard = false;
            isSimulatedOnMap = true;
            shouldShowCardInfomation = false;
            SimulateOnMap();
        }
    }

    // カードが選択された際に行う処理
    private void ChoseCard()
    {
        Debug.Log("カードが選択された");

        isChoseCard = false;
        canChooseCard = false;
        isSimulatedOnMap = true;

        SimulateOnMap();
    }

    // 決定ボタンをクリックした際に行う処理
    public void PushChooseCardButton()
    {
        // カードを選べるたいむでカードを選んでいたら
        if (canChooseCard == true　&& isChoseCard == true)
        {
            isPushedChooseCardButton = true;
            Debug.Log("選ばれたカード：" + choseCardTag);

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
                    Debug.Log(" その他 ");
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
