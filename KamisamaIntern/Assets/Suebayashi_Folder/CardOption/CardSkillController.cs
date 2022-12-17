using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSkillController : MonoBehaviour
{
    //焼け野原に変えた数
    private int burntCount;

    // 雷
    public void ThunderCardEffect()
    {
        //ボタン呼び出しの際の初期化
        burntCount = 0;

        //Listの宣言
        List<GameObject> fields = new List<GameObject>();

        //Fieldタグが付いたオブジェクト＝草原を取得
        fields.AddRange(GameObject.FindGameObjectsWithTag("Field"));

        //Seaタグが付いたオブジェクト＝海を取得
        fields.AddRange(GameObject.FindGameObjectsWithTag("Sea"));

        //WorldTreeタグが付いたオブジェクト＝世界樹を取得
        fields.AddRange(GameObject.FindGameObjectsWithTag("WorldTree"));
        Debug.Log("雷の効果発動！！！");

        //取得した草原全てに操作を行う
        foreach (GameObject field in fields)
        {
            //0か1で乱数取得
            int rnd = Random.Range(0, 2);
            //乱数が１で作動
            if (rnd == 1)
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
                if (burntCount == 10)
                {
                    //ループを抜ける
                    break;
                }
            }
        }
    }

    // 太陽
    public void SunCardEffect()
    {
        //Listの宣言
        List<GameObject> seas = new List<GameObject>();

        //Seaタグが付いたオブジェクト＝海を取得
        seas.AddRange(GameObject.FindGameObjectsWithTag("Sea"));
        Debug.Log("太陽の効果発動！！！");

        foreach (GameObject sea in seas)
        {
            int rnd = Random.Range(0, 2);
            //乱数が１で作動
            if (rnd == 1)
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
                if (burntCount == 5)
                {
                    //ループを抜ける
                    break;
                }
            }
        }
    }

    //恵みの雨の効果
    public void RainCardEffect()
    {
        //Fieldタグが付いたオブジェクト＝草原を取得
        GameObject[] fields = GameObject.FindGameObjectsWithTag("Field");
        Debug.Log("恵みの雨の効果発動！！！");

        // 恵みの雨
        //取得した草原全てに操作を行う
        foreach (GameObject field in fields)
        {
            //草原の子オブジェクトの数を数える（動物などがなければ、０になる）
            int objCount = field.transform.childCount;

            //子オブジェクトが０であれば作動
            if (objCount == 0)
            {
                //乱数を生成
                int rnd = Random.Range(0, 100);

                //0～99のうち、１が出たら作動（確率1％）
                if (rnd == 1)
                {
                    //Resoucesファイルから、treeプレハブを取得
                    GameObject prefab = (GameObject)Resources.Load("tree");

                    //treeを複製
                    GameObject cloneTree = Instantiate(prefab, field.transform.position, Quaternion.identity);

                    //treeの親をfieldに指定
                    //cloneTree.transform.parent = field.transform;
                    Destroy(field);

                    Debug.Log("木を作成");
                }
            }
        }
    }

    // 世界樹
    public void PlantCardEffect()
    {
        //Listの宣言
        List<GameObject> fields = new List<GameObject>();

        //Fieldタグが付いたオブジェクト＝草原を取得
        fields.AddRange(GameObject.FindGameObjectsWithTag("Field"));

        Debug.Log("世界樹の効果発動！！！");

        foreach (GameObject field in fields)
        {
            int rnd = Random.Range(0, 2);
            if (rnd == 1)
            {

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

    // 突然変異
    public void MutationCardEffect()
    {
        //Fieldタグが付いたオブジェクト＝草原を取得
        GameObject[] fields = GameObject.FindGameObjectsWithTag("Field");
        Debug.Log("突然変異の効果発動！！！");

        //取得した草原全てに操作を行う
        foreach (GameObject field in fields)
        {
            if (field.GetComponent<FieldController>() != null)
            {
                //fieldのFieldControllerを取得
                FieldController myField = field.GetComponent<FieldController>();
                //確率を求める際の最大値を更新
                myField.max = 20;
            }
        }
    }

    // 隕石
    public void MeteorCardEffect()
    {
        //呼び出しの際の初期化
        burntCount = 0;

        //Listの宣言
        List<GameObject> fields = new List<GameObject>();

        //Fieldタグが付いたオブジェクト＝草原を取得
        fields.AddRange(GameObject.FindGameObjectsWithTag("Field"));

        //Seaタグが付いたオブジェクト＝海を取得
        fields.AddRange(GameObject.FindGameObjectsWithTag("Sea"));

        //WorldTreeタグが付いたオブジェクト＝世界樹を取得
        fields.AddRange(GameObject.FindGameObjectsWithTag("WorldTree"));
        Debug.Log("隕石の効果発動！！！");

        //取得した草原全てに操作を行う
        foreach (GameObject field in fields)
        {
            //0か1で乱数生成
            int rnd = Random.Range(0, 2);
            //乱数が１で作動
            if (rnd == 1)
            {
                //Resoucesファイルから、Burnt_Fieldプレハブを取得
                GameObject prefab = (GameObject)Resources.Load("Burnt_Field");
                //Burnt_Fieldを複製
                GameObject cloneBurnt = Instantiate(prefab, field.transform.position, Quaternion.identity);

                //Fieldオブジェクトを削除
                Destroy(field);

                //カウントを増やす
                burntCount++;

                //カウントが25で作動
                if (burntCount == 25)
                {
                    //ループを抜ける
                    break;
                }
            }
        }
    }

    // 疫病
    public void DiseaseCardEffect()
    {
        //Listの宣言
        List<GameObject> humans = new List<GameObject>();

        humans.AddRange(GameObject.FindGameObjectsWithTag("Human"));

        Debug.Log("疫病の効果発動！！！");

        foreach (GameObject human in humans)
        {
            int rnd = Random.Range(0, 3);
            if (rnd == 0)
            {
                Destroy(human);
            }
        }
    }

    // 豪雨
    public void HeavyRainCardEffect()
    {
        List<GameObject> burns = new List<GameObject>();

        burns.AddRange(GameObject.FindGameObjectsWithTag("Burnt_Field"));

        Debug.Log("豪雨の効果発動！！！");

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
