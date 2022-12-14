using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanMoveController : MonoBehaviour
{
    //1フレーム当たりの人間のX軸の移動距離
    [SerializeField]
    private float moveX = 0.01f;

    //1フレーム当たりの人間のY軸の移動距離
    [SerializeField]
    private float moveY = 0f;

    //最後に移動した方向の数字
    [SerializeField]
    private int pastnum;

    // Start is called before the first frame update
    void Start()
    {
        //方向決定
        SelectDirection();
    }

    // Update is called once per frame
    void Update()
    {
        //moveXとmoveYの分だけ移動
        this.gameObject.transform.position += new Vector3(moveX, moveY, 0);
    }

    //方向をランダムで決定するための関数
    private void SelectDirection()
    {
        //整数をランダムで生成
        int rnd = Random.Range(0, 4);
        
        //乱数によって分岐
        switch(rnd)
        {
            //上方向
            case 0:
                moveX = 0;
                moveY = 0.01f;
                Debug.Log("うえ");
                break;
            //左方向
            case 1:
                moveX = -0.01f;
                moveY = 0;
                Debug.Log("ひだり");
                break;
            //下方向
            case 2:
                moveX = 0;
                moveY = -0.01f;
                Debug.Log("した");
                break;
            //右方向
            case 3:
                moveX = 0.01f;
                moveY = 0f;
                Debug.Log("みぎ");
                break;
        }
        //最後に移動した方向と同じ方向に向かおうとしたら作動
        if(pastnum == rnd){
            //再帰による方向の再決定
            Debug.Log("再帰");
            SelectDirection();            
        }
        else
        {
            //方向が異なっていればpastnum更新
            pastnum = rnd;
        }

    }

    //ほかの物体とぶつかったときの処理
    private void OnCollisionEnter2D(Collision2D col)
    {
        //方向転換
        SelectDirection();
    }
}
