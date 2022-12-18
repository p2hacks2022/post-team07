using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunCard : MonoBehaviour
{

    private int burntCount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SunCardEffect()
    {
        //Listの宣言
        List<GameObject> seas = new List<GameObject>();

        //Seaタグが付いたオブジェクト＝海を取得
        seas.AddRange(GameObject.FindGameObjectsWithTag("Sea"));
        Debug.Log("効果発動！！！");

        foreach(GameObject sea in seas)
        {
            int rnd = Random.Range(0,2);
            //乱数が１で作動
            if(rnd == 1)
            {
                //Resoucesファイルから、Burnt_Fieldプレハブを取得
                GameObject prefab = (GameObject)Resources.Load("Burnt_Field");
                //Burnt_Fieldを複製
                GameObject cloneBurnt = Instantiate(prefab, sea.transform.position, Quaternion.identity);

                //Fieldオブジェクトを削除
                Destroy(sea);
                
                //カウントを増やす
                burntCount++;

                //カウントが5で作動
                if(burntCount == 5)
                {
                    //ループを抜ける
                    break;
                }
            }
        }
    }
}
