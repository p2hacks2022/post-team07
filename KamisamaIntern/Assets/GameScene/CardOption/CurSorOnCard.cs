using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurSorOnCard : MonoBehaviour
{
    [SerializeField]
    private GameObject card;

    [SerializeField]
    private float cardSizeTimes; //カード拡大の度合い

    [SerializeField]
    private float cardPositionTimes; //カードの位置上げの度合い

    [SerializeField]
    private Vector3 cardDefaultSize; //カードの基準の大きさ

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // マウスカーソルが置かれたとき
    public void onPointerEnter()
    {
        // カードの位置を上げる
        card.transform.position += Vector3.up * cardPositionTimes;
        // カードを拡大させる
        card.transform.localScale = cardDefaultSize * cardSizeTimes;
    }

    // マウスカーソルが離れたとき
    public void onPointerExit()
    {
        // カードの位置を元に戻す
        card.transform.position -= Vector3.up * cardPositionTimes;
        // カードの大きさを元に戻す
        card.transform.localScale = cardDefaultSize;
    }
}
