using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PointCount : MonoBehaviour
{

    //合計自然ポイント
    public int naturePoint = 0;

    //合計発展ポイント
    public int developmentPoint = 0;

    //エンディング分岐のための変数
    public static int endingNum = 0;

    //時間
    private float time;

    [SerializeField]
    private int judgeNum = 10;

    //自然/発展ポイントを数えたかどうか
    private bool isCount = false;

    //制限時間（デフォルトは130）
    [SerializeField] int limitTime;

    //各ユニットを参照して格納するList
    //タグ利用によるユニット数計測のために使う
    List<GameObject> humans = new List<GameObject>();
    List<GameObject> animals = new List<GameObject>();
    List<GameObject> trees = new List<GameObject>();
    List<GameObject> houses = new List<GameObject>();
    List<GameObject> farms = new List<GameObject>();
    List<GameObject> worldTrees = new List<GameObject>();
    List<GameObject> factorys = new List<GameObject>();

    private float totalTime;

    [SerializeField]
    private int minute;
    
    [SerializeField]
    private float seconds;

    // Start is called before the first frame update
    void Start()
    {
        totalTime = minute * 60 + seconds;
    }

    // Update is called once per frame
    void Update()
    {
        //時間を測る
        if (totalTime <= 0f)
        {
            return;
        }
        if (CardController.canChooseCard == false)
        {
            totalTime = minute * 60 + seconds;
            totalTime -= Time.deltaTime;
        }

        minute = (int)totalTime / 60;
        seconds = totalTime - minute * 60;

        //まだ数えてなくて、制限時間になったら作動
        if(isCount ==false && totalTime < 1.0f)
        {
            //合計自然ポイントを取得
            naturePoint = gatherNaturePoint();

            //合計発展ポイントを取得
            developmentPoint = gatherDevelopmentPoint();

            //デバッグ用
            Debug.Log("自然ポイント：" + naturePoint);
            Debug.Log("発展ポイント：" + developmentPoint);
            
            //数え終わり
            isCount = true;

            //分岐を取得
            endingNum = judgeEndingNumber();
            //デバッグ用
            Debug.Log(endingNum);

        }
    }

    //自然ポイントの集計
    private int gatherNaturePoint()
    {
        //WorldTreeタグが付いたオブジェクト＝世界樹を取得
        worldTrees.AddRange(GameObject.FindGameObjectsWithTag("WorldTree"));

        //Animalタグが付いたオブジェクト＝動物を取得
        animals.AddRange(GameObject.FindGameObjectsWithTag("Animal"));

        //Treeタグが付いたオブジェクト＝木を取得
        trees.AddRange(GameObject.FindGameObjectsWithTag("Tree"));

        //集計
        int totall = worldTrees.Count * 5 + animals.Count + trees.Count *2;

        //集計を返す
        return totall;
    }

    //発展ポイントの集計
    private int gatherDevelopmentPoint()
    {
        //Humanタグが付いたオブジェクト＝人間を取得
        humans.AddRange(GameObject.FindGameObjectsWithTag("Human"));

        //Houseタグが付いたオブジェクト＝家を取得
        houses.AddRange(GameObject.FindGameObjectsWithTag("House"));

        //Farmタグが付いたオブジェクト＝農場を取得
        farms.AddRange(GameObject.FindGameObjectsWithTag("Farm"));

        //Factoryタグが付いたオブジェクト＝工場を取得
        factorys.AddRange(GameObject.FindGameObjectsWithTag("Factory"));

        //ポイント集計
        int totall = humans.Count + houses.Count * 4 + farms.Count * 6 + factorys.Count * 8;

        //集計を返す
        return totall;

    }

    //エンディングの分岐決定
    private int judgeEndingNumber()
    {
        //エンディング分岐の準備
        int diff = naturePoint - developmentPoint;

        //変数代入用
        int end = 0;

        //差が-5～5
        if(-5 < diff && diff <5)
        {
            //ポイントがどちらも10より大きい時
            if(naturePoint >= judgeNum && developmentPoint >= judgeNum)
            {
                //両立エンド
                end = 1;
            }
            else
            {
                //滅亡エンド
                end = 4;
            }
        }
        else
        {
            if(Mathf.Sign(diff) == 1)
            {
                //自然エンド
                end = 3;
            }
            if(Mathf.Sign(diff) == -1)
            {
                //発展エンド
                end = 2;
            }
        }
        return end;
    }

    //挙動確認用関数
    public void MoveEnding()
    {
        SceneManager.LoadScene("EndingScene");
    }
}
