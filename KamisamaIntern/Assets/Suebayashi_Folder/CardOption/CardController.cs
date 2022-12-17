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

    // Start is called before the first frame update
    void Start()
    {
        defaultCountTimeOfChoosingCard = countTimeOfChoosingCard;

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
                    if (Input.GetMouseButtonDown(0))
                    {
                        /* カードがクリックされた際に行う処理 */
                        // 選択したカードのタグを保存
                        choseCardTag = result.gameObject.tag;
                        Debug.Log("選ばれたカード：" + choseCardTag);
                        isChoseCard = true;
                        //ChoseCard();
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
        countTimeOfChoosingCardText.text = "あと" + Mathf.Round(countTimeOfChoosingCard*100.0f)/100 + "秒！";

        // カウントの途中でカードが選択されたらその際の処理へ
        if (isChoseCard == true)
        {
            countTimeOfChoosingCard = 0f;
            countTimeOfChoosingCardText.text = " ";
            countTimeOfChoosingCard = defaultCountTimeOfChoosingCard; // 制限時間の初期化
            canChooseCard = false;
            ChoseCard();
        }
        // 何も選択されないままカウントが0になったらシミュレートへ
        else if (isChoseCard == false && countTimeOfChoosingCard <= 0)
        {
            countTimeOfChoosingCard = 0f;
            countTimeOfChoosingCardText.text = " ";
            countTimeOfChoosingCard = defaultCountTimeOfChoosingCard; // 制限時間の初期化
            canChooseCard = false;
            isSimulatedOnMap = true;
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
}
