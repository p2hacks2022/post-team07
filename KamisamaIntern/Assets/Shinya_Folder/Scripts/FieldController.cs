using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldController : MonoBehaviour
{
    //現在の蓄積時間
    [SerializeField]
    private float time = 0f;

    //動物を生み出す間隔
    [SerializeField]
    private float span = 1f;

    //複製する動物オブジェクト
    [SerializeField]
    private GameObject Animal;

    //確率を求める際の条件の最大値
    [SerializeField]
    private int max;

    //確率を求める際の条件の最小値
    [SerializeField]
    private int min;

    //Fieldにオブジェクトが重なっているかの判定
    private bool isTrigger = false;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //ゲーム内経過時間を代入
        time += Time.deltaTime;
        //一定間隔で作動
        if(time > span)
        {
            //動物を生み出す
            SpawnAnimal();
            //時間を0にする
            time = 0f;
        }
    }

    //確率で動物をそのタイルに生成する関数
    private void SpawnAnimal()
    {
        //整数をランダムで生成
        int rnd = Random.Range(0, 200);
        //乱数が最小値以上最大値未満だったら
        if(rnd >= min && rnd < max)
        {
            //オブジェクトの上に何も重なっていなかったら作動
            if(isTrigger == false)
            {
                //動物を自分の上に複製
                Instantiate(Animal, this.transform.position, Quaternion.identity);
            }
        }
    }
    //オブジェクトが自分の上にある時作動
    private void OnTriggerStay2D(Collider2D other) {
        //上に乗った判定
        isTrigger = true;
    }

    //オブジェクトが離れたとき作動
    private void OnTriggerExit2D(Collider2D other) {
        //上に乗ってない判定
        isTrigger = false;
    }
}
