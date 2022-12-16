using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour
{
    // カード選択ターン
    public static bool canChooseCard = false;

    // シミュレートターン
    public static bool isSimulatedOnMap = true;

    // カードが選択されたかどうか
    private bool isChoseCard = false;

    // カード選択ターンの制限時間
    [SerializeField]
    private float countTimeOfChoosingCard;

    // シミュレートの時間
    [SerializeField]
    private float timeOfSimulation;

    // カードを選択する際の制限時間の初期値を保存
    private float defaultCountTimeOfChoosingCard;

    // Start is called before the first frame update
    void Start()
    {
        defaultCountTimeOfChoosingCard = countTimeOfChoosingCard;

        // 始めにマップでシミュレート
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
        countTimeOfChoosingCard -= Time.deltaTime;
        Debug.Log(countTimeOfChoosingCard);

        // カウントの途中でカードが選択されたらその際の処理へ
        if (isChoseCard == true)
        {
            countTimeOfChoosingCard = defaultCountTimeOfChoosingCard; // 制限時間の初期化
            canChooseCard = false;
            ChoseCard();
        }
        // 何も選択されないままカウントが0になったらシミュレートへ
        else if (isChoseCard == false && countTimeOfChoosingCard <= 0)
        {
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

        /* 選択したカードの判別を行う */

        isChoseCard = false;
        canChooseCard = false;
        isSimulatedOnMap = true;

        SimulateOnMap();
    }

    // カードがクリックされた際に呼び出される関数
    public void CardClicked()
    {
        if (canChooseCard == true)
        {
            /* カードがクリックされた際に行う処理 */
            isChoseCard = true;
            ChoseCard();
        }
    }
}
