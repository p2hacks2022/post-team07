using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderCard : MonoBehaviour
{
    //焼け野原に変えた数
    private int burntCount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ThunderCardEffect()
    {
        //ボタン呼び出しの際の初期化
        burntCount = 0; 

        //Fieldタグが付いたオブジェクト＝草原を取得
        GameObject[] fields = GameObject.FindGameObjectsWithTag("Field");
        Debug.Log("効果発動！！！");

        //取得した草原全てに操作を行う
        foreach (GameObject field in fields)
        {
            //0か1で乱数取得
            int rnd = Random.Range(0,2);
            //乱数が１で作動
            if(rnd == 1)
            {
                //Resoucesファイルから、Burnt_Fieldプレハブを取得
                GameObject prefab = (GameObject)Resources.Load("Burnt_Field");
                //Burnt_Fieldを複製
                GameObject cloneBurnt = Instantiate(prefab, field.transform.position, Quaternion.identity);

                //Fieldオブジェクトを削除
                Destroy(field);

                //カウントを増やす
                burntCount++;
                
                //カウントが10で作動
                if(burntCount == 10)
                {
                    //ループを抜ける
                    break;
                }
            }
        }
    }
}
