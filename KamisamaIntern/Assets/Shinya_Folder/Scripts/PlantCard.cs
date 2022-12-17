using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantCard : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlantCardEffect()
    {
        //Listの宣言
        List<GameObject> fields = new List<GameObject>();

        //Fieldタグが付いたオブジェクト＝草原を取得
        fields.AddRange(GameObject.FindGameObjectsWithTag("Field"));
        
        Debug.Log("効果発動！！！");

        foreach (GameObject field in fields)
        {
            int rnd = Random.Range(0,2);
            if(rnd == 1){

                //Resoucesファイルから、Burnt_Fieldプレハブを取得
                GameObject prefab = (GameObject)Resources.Load("WorldTree");
                //Burnt_Fieldを複製
                GameObject cloneBurnt = Instantiate(prefab, field.transform.position, Quaternion.identity);

                //Fieldオブジェクトを削除
                Destroy(field);
                
                break;
            }
        }
    }
}
