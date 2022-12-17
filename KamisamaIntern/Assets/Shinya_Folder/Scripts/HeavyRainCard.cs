using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyRainCard : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HeavyRainCardEffect()
    {
        List<GameObject> burns = new List<GameObject>();

        burns.AddRange(GameObject.FindGameObjectsWithTag("Burnt_Field"));

        Debug.Log("効果発動！！！");

        foreach (GameObject burn in burns)
        {
            //Resoucesファイルから、Fieldプレハブを取得
            GameObject prefab = (GameObject)Resources.Load("Field");
            //Fieldを複製
            GameObject cloneBurnt = Instantiate(prefab, burn.transform.position, Quaternion.identity);
            
            //Fieldオブジェクトを削除
            Destroy(burn);
        }
    }
}
