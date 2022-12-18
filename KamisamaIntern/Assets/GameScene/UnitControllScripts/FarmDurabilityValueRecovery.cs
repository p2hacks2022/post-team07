using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmDurabilityValueRecovery : MonoBehaviour
{
    //周囲八マスの中にある木を格納するための配列
    [SerializeField]
    private GameObject[] Trees;

    //周囲八マスの中にある草原を格納するための配列
    [SerializeField]
    private GameObject[] Field;

    //新たに生み出すときに参照する人間のオブジェクト
    [SerializeField]
    private GameObject Human;

    //配列管理のためのポインタ
    int treePointer = 0;
    int fieldPointer = 0;

    //格納が終わったのか確認するため
    bool finTree = false;
    bool finField = false;

    //対象選択用の仮変数
    bool full1 = false;
    bool full2 = false;
    bool full3 = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()

    {
    }

    // when the GameObjects collider arrange for this GameObject to travel to the left of the screen
    void OnTriggerStay2D(Collider2D collider)
    {
        //農場のCollider内に
        if (collider.gameObject.name != null)
        {
            Debug.Log(collider.gameObject.tag);

            //配列の格納が終わってなければ
            if (!finTree)
            {
                //Treeのタグが付いた物を
                if (collider.gameObject.tag == "Tree")
                {
                    //配列に空きがあるまで入れていく
                    if (treePointer < 9)
                    {
                        Trees[treePointer] = collider.gameObject;

                    }
                    else
                    {
                        //配列の空きがないくらい入れたら終わり
                        finTree = true;
                    }

                    treePointer++;
                }
            }

            //配列の格納が終わってなければ
            if (!finField)
            {
                //Fielfのタグがついたものを
                if (collider.gameObject.tag == "Field")
                {
                    //格納していく
                    if (fieldPointer < 9)
                    {

                        Field[fieldPointer] = collider.gameObject;

                    }
                    else
                    {
                        finField = true;
                    }

                    fieldPointer++;
                }
            }


            if (!full1)
            {
                //配列埋まってるから
                if (finTree)
                {
                    ///
                    /// 体力が10以下になり，家(house)の周り8タイルに木(tree)があると，木(tree)を1つ消し耐久値を5回復する．
                    ///


                    //配列の中から一つランダムで選んで消す
                    int k = Random.Range(0, Trees.Length);
                    Debug.Log("えらばれたのは" + Trees[k]);
                    Destroy(Trees[k].gameObject);
                    full1 = true;

                }
            }

            if (!full2)
            {

                ///家(house)の周りに上下左右のどれにニンゲン(human)を配置する場所があれば，5秒に1回ニンゲン(human)を配置する．//
                ///

                if (finField)
                {
                    //配列のなかから一つランダムに選んで人間と置き換える
                    int k = Random.Range(0, Field.Length);
                    Debug.Log("えらばれたのは" + Field[k]);
                    Instantiate(Human, Field[k].transform.position, Quaternion.identity);
                    Human.transform.position = Field[k].gameObject.transform.position;
                    full2 = true;
                }
            }

        }
    }
}