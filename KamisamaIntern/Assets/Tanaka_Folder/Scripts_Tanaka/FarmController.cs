using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmController : MonoBehaviour
{
    //何秒に一回体力が減るか
    [SerializeField]
    private float decreaseHealth = 5.0f;

    //体力が減少するまでの時間
    private float decreaseTime = 5.0f;

    //発展ポイント
    [SerializeField]
    private int developmentPoint;

    //ユニットの体力
    public int health;

    //体力上限
    [SerializeField]
    private int maxHealth;

    // Start is called before the first frame update
    void Start()
    {
        //変数の初期化
        health = 23;
        maxHealth = 23;
        HumanController.decreaseHealth = 7.0f;
    }

    // Update is called once per frame
    void Update()
    {
        //時間経過処理
        decreaseTime -= Time.deltaTime;

        //時間が0になったら行う
        if (decreaseTime <= 0f)
        {
            //体力を１減らす
            health--;

            //時間をもとに戻す
            decreaseTime = 5.0f;
        }

        //体力が0になったら行う
        if (health <= 0)
        {
            //農場の数を調べる
            GameObject[] farms = GameObject.FindGameObjectsWithTag("Farm");
            
            //農場の数が１つのみである時作動
            if(farms.Length == 1)
            {
                //人間の体力減少時間をもとに戻す
                HumanController.decreaseHealth = 5.0f;
            }
            //そのオブジェクトを消去する
           Destroy(this.gameObject);
        }
    }

    //物体が重なっているときの処理
    private void OnTriggerStay2D(Collider2D col)
    {
        //通ったオブジェクトのタグで分岐
        switch(col.gameObject.tag)
        {
            //木の場合
            case "Tree":
            //体力10以上で作動
                if(health <= 10)
                {
                    //体力５回復
                    health += 5;
                    
                    //当たったオブジェクトを消去
                    Destroy(col.gameObject);
                    //現在の体力が体力上限を超えていたら作動
                    if(health > maxHealth)
                    {
                        //体力を体力上限の数値まで戻す
                        health = maxHealth;
                    } 
                }
                break;
        }
    }
}
