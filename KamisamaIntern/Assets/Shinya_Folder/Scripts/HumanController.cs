using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanController : MonoBehaviour
{
    //何秒に一回体力が減るか
    public static float decreaseHealth = 5.0f;
    
    //体力が減少するまでの時間
    private float decreaseTime = 5.0f;

    //ユニットの体力
    [SerializeField]
    private int health;

    //発展ポイント
    [SerializeField]
    private int developmentPoint;

    //体力上限
    [SerializeField]
    private int maxHealth;

    //農場のカードを使ったか
    public static bool isFarm;

    //工場のカードを使ったか
    public static bool isFactory;

    // Start is called before the first frame update
    void Start()
    {
        //変数の初期化
        health = 10;
        maxHealth = 20;
        developmentPoint = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //時間経過処理
        decreaseTime -= Time.deltaTime;
        
        //時間が0になったら行う
        if(decreaseTime <= 0f)
        {
            //体力を１減らす
            health--;

            //時間をもとに戻す
            decreaseTime = 5.0f;
        }

        //体力が0になったら行う
        if(health <= 0)
        {
            //そのオブジェクトを消去する
            Destroy(this.gameObject);
        }
    }

    //物体とぶつかったときの処理
    private void OnCollisionEnter2D(Collision2D col)
    {
        //ぶつかったオブジェクトのタグで分岐
        switch(col.gameObject.tag)
        {
            //動物の場合
            case "Animal":
                //体力増やす
                health += 5;
                //時間をもとに戻す
                decreaseTime = 5.0f;
                //体力の上限を越している場合
                if(health > maxHealth)
                {
                    //体力を体力上限の数値まで戻す
                    health = maxHealth;
                }
                break;
            case "Tree":
            //体力が15以上で作動
                if(health >= 15)
                {
                    //農場のカードを使っているときのみ作動
                    if(isFarm == true)
                    {
                        //乱数生成
                        int rnd = Random.Range(0,3);
                        
                        //乱数が0で作動
                        if(rnd == 0)
                        {
                            //工場が作れるとき、工場を作る
                            if(isFactory == true)
                            {
                                //Resoucesファイルから、Factoryプレハブを取得
                                GameObject prefab = (GameObject)Resources.Load("Factory");
                                //Houseを複製
                                GameObject clone = Instantiate(prefab, col.transform.position, Quaternion.identity);
                            }
                            //そうでなければ、農場を作る
                            else
                            {
                                //Resoucesファイルから、Farmプレハブを取得
                                GameObject prefab = (GameObject)Resources.Load("Farm");
                                //Houseを複製
                                GameObject clone = Instantiate(prefab, col.transform.position, Quaternion.identity);
                            }
                        }
                        //乱数が0でない時、作動
                        //家を作る
                        else
                        {
                            //Resoucesファイルから、Houseプレハブを取得
                            GameObject prefab = (GameObject)Resources.Load("house");

                            //Houseを複製
                            GameObject clone = Instantiate(prefab, col.transform.position, Quaternion.identity);                          
                        }
                    //農場カードを使ってない時作動
                    }
                    else
                    {
                    //Resoucesファイルから、Houseプレハブを取得
                    GameObject prefab = (GameObject)Resources.Load("house");

                    //Houseを複製
                    GameObject clone = Instantiate(prefab, col.transform.position, Quaternion.identity);
                    }
                    //ぶつかった対象を消す
                    Destroy(col.gameObject);
                }
                break;
        }
    }
}
