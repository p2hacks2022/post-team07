using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainCard : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //恵みの雨の効果
    public void RainCardEffect()
    {
        //Fieldタグが付いたオブジェクト＝草原を取得
        GameObject[] fields = GameObject.FindGameObjectsWithTag("Field");
        Debug.Log("効果発動！！！");

        //取得した草原全てに操作を行う
        foreach (GameObject field in fields)
        {
            //草原の子オブジェクトの数を数える（動物などがなければ、０になる）
            int objCount = field.transform.childCount;

            //子オブジェクトが０であれば作動
            if(objCount == 0)
            {
                //乱数を生成
                int rnd = Random.Range(0, 100);

                //0～99のうち、１が出たら作動（確率1％）
                if(rnd == 1){
                    //Resoucesファイルから、treeプレハブを取得
                    GameObject prefab = (GameObject)Resources.Load("tree");

                    //treeを複製
                    GameObject cloneTree = Instantiate(prefab, field.transform.position, Quaternion.identity);

                    //treeの親をfieldに指定
                    cloneTree.transform.parent = field.transform;
                    
                    Debug.Log("木を作成");
                }
            }
        }
    }
}
