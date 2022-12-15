using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MutationCard : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MutationCardEffect()
    {
        //Fieldタグが付いたオブジェクト＝草原を取得
        GameObject[] fields = GameObject.FindGameObjectsWithTag("Field");
        Debug.Log("効果発動！！！");

        //取得した草原全てに操作を行う
        foreach (GameObject field in fields)
        {
            if(field.GetComponent<FieldController>() != null){
                //fieldのFieldControllerを取得
                FieldController myField = field.GetComponent<FieldController>();
                //確率を求める際の最大値を更新
                myField.max = 20;
            }
        }
    }
}
