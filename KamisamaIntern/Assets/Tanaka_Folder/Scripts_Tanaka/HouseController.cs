using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseController : MonoBehaviour
{
    //自然ポイント
    [SerializeField]
    private int developePoint;

    // Start is called before the first frame update
    void Start()
    {
        //変数の初期化
        developePoint = 1;
    }

    // Update is called once per frame
    void Update()
    {

    }

    //ぶつかったときの処理
    private void OnCollisionEnter2D(Collision2D col)
    {

    }
}
