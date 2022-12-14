using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanController : MonoBehaviour
{
    //何秒に一回体力が減るか
    [SerializeField]
    private float decreaseHealth = 5.0f;
    
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

    // Start is called before the first frame update
    void Start()
    {
        //変数の初期化
        health = 20;
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
        }
    }
}
