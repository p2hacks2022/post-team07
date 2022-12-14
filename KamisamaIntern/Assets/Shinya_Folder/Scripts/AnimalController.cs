using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalController : MonoBehaviour
{
    //自然ポイント
    [SerializeField]
    private int naturePoint;

    // Start is called before the first frame update
    void Start()
    {
        //変数の初期化
        naturePoint = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //ぶつかったときの処理
    private void OnCollisionEnter2D(Collision2D col)
    {
        //ぶつかったオブジェクトのタグで分岐
        switch(col.gameObject.tag)
        {
            //人間の場合
            case "Human":
                //オブジェクト削除
                Destroy(this.gameObject);
                break;
        }
    }
}
