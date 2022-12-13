using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTreeMake_Manager : MonoBehaviour
{
    //背景となるイメージ[black]を格納する
    [SerializeField]
    private GameObject TreeObject;

    //画面の左端上の初期値
    public float firstposi_value_x;
    public float firstposi_value_y;

    /// <summary>
    /// 木を表示するかしないかの判断用のランダム変数を格納する場所
    /// </summary>
    private int ground_random_value;


    // Start is called before the first frame update
    void Start()
    {
        //縦のマス目分のfor文
        for (int j = 0; j < 9; j++)
        {
            //横のマス目文のfor文
            for (int i = 0; i < 8; i++)
            {

                //1～100の中からランダムに値一つ生成
                ground_random_value = Random.Range(1, 101);

                if (ground_random_value % 3 == 0)
                {
                    //プレハブを元にオブジェクトを生成する

                    GameObject instance = Instantiate(TreeObject, new Vector3(firstposi_value_x, firstposi_value_y, 0.0f), Quaternion.identity);

                }

                //横にひとつ移動
                firstposi_value_x += 0.89f;
            }

            //x軸方向を初期値に、y軸方向に一つ下に
            firstposi_value_x = -7.5f;
            firstposi_value_y -= 0.88f;
        }
    }

}
