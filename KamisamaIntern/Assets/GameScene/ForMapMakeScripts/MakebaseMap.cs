/*
 * マップ用の地面をランダムで生成するようにスクリプト構築
 * マップの地面には
 * field sea
 * の２種類のドット絵が用いられる
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakebaseMap : MonoBehaviour
{
    //背景となるイメージ[field][sea]を格納する配列
    [SerializeField]
    private GameObject[] GroundImages;

    //背景となるイメージ[tree][animal][house]を格納する配列
    [SerializeField]
    private GameObject[] OverImages;

    //背景となるイメージ[black]を格納する
    [SerializeField]
    private GameObject Black;

    //画面の左端上の初期値
    public float value_x;
    public float value_y;

    /// <summary>
    /// 「field」「sea」どちらを生成するかのランダム変数生成
    /// 現在　陸地：海　= 29:71 だからその割合で生成
    /// </summary>
    private int ground_random_value;

    /// <summary>
    /// 「animal」「house」「tree」のどれを生成するかのランダム変数生成
    /// 現在　動物：木：家 : 空白　= 8 : 17 : 15 : 60 だからその割合で生成
    /// </summary>
    private int over_random_value;


    // Start is called before the first frame update
    void Start()
    {
        //縦のマス目分のfor文
        for (int j = 0; j < 9; j++)
        {
            //横のマス目文のfor文
            for (int i = 0; i < 8; i++)
            {

                //OutFrame_Put(j, i);

                //1～100の中からランダムに値一つ生成
                ground_random_value = Random.Range(1, 101);
                over_random_value = Random.Range(1, 101);

                if (ground_random_value % 3 == 0)
                {
                    //プレハブを元にオブジェクトを生成する
                    if (ground_random_value > 0 && ground_random_value <= 40)
                    {   //40%は海
                        GameObject instance = Instantiate(GroundImages[0], new Vector3(value_x, value_y, 0.0f), Quaternion.identity);
                    }
                    else if (ground_random_value > 40 && ground_random_value < 101)
                    {
                        //60％は陸
                        GameObject instance = Instantiate(GroundImages[1], new Vector3(value_x, value_y, 0.0f), Quaternion.identity);
                    }
                }

                //OverItem_Put(over_random_value);

                //横にひとつ移動
                value_x += 0.89f;
            }

            //x軸方向を初期値に、y軸方向に一つ下に
            value_x = -7.5f;
            value_y -= 0.88f;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }


    /// <summary>
    /// 「animal」「house」「tree」のどれを生成するかのランダム変数生成
    /// 現在　動物：木：家 : 空白　= 8 : 17 : 15 : 60 だからその割合で生成
    /// </summary>
    public void OverItem_Put(int value)
    {
        //プレハブを元にオブジェクトを生成する
        if (value > 0 && value <= 8)
        {
            GameObject instance = Instantiate(OverImages[0], new Vector3(value_x, value_y, 0.0f), Quaternion.identity);
        }
        else if (value > 8 && value <= 16)
        {
            GameObject instance = Instantiate(OverImages[1], new Vector3(value_x, value_y, 0.0f), Quaternion.identity);
        }
        else if (value > 16 && value <= 24)
        {
            GameObject instance = Instantiate(OverImages[2], new Vector3(value_x, value_y, 0.0f), Quaternion.identity);
        }
        else if (value > 24 && value < 101)
        {
            // GameObject instance = Instantiate(OverImages[3], new Vector3(value_x, value_y, 0.0f), Quaternion.identity);
        }
    }

    /// <summary>
    /// 基礎となる[black]を外枠にランダムで配置
    /// 
    /// 外枠の時のみ実行されたいスクリプト
    /// j=0,8の時　又は　(i=0,17　且つ　j=1～7)　の時
    /// </summary>
    public void OutFrame_Put(int value_j, int value_i)
    {
        int tmp_value = Random.Range(0, 4); ;

        if (tmp_value % 3 == 0)
        {
            //プレハブを元にオブジェクトを生成する
            if (value_j == 0 || value_j == 8)
            {
                GameObject instance = Instantiate(Black, new Vector3(value_x, value_y, 0.0f), Quaternion.identity);
            }

            //プレハブを元にオブジェクトを生成する
            if (value_i == 0 || value_i == 17)
            {
                GameObject instance = Instantiate(Black, new Vector3(value_x, value_y, 0.0f), Quaternion.identity);
            }
        }


    }
}