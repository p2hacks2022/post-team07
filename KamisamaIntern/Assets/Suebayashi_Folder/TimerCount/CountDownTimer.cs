using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class CountDownTimer : MonoBehaviour
{
    //　トータル制限時間
    private float totalTime;
    //　制限時間（分）
    [SerializeField]
    private int minute;
    //　制限時間（秒）
    [SerializeField]
    private float seconds;
    //　前回Update時の秒数
    private float oldSeconds;
    private TextMeshProUGUI timerText;

    void Start()
    {
        totalTime = minute * 60 + seconds;
        oldSeconds = 0f;
        timerText = GetComponentInChildren<TextMeshProUGUI>();
    }

    void Update()
    {
        //　制限時間が0秒以下なら何もしない
        if (totalTime <= 0f)
        {
            return;
        }
        //　一旦トータルの制限時間を計測；
        if (CardController.canChooseCard == false)
        {
            totalTime = minute * 60 + seconds;
            totalTime -= Time.deltaTime;
        }

        //　再設定
        minute = (int)totalTime / 60;
        seconds = totalTime - minute * 60;

        //　タイマー表示用UIテキストに時間を表示する
        if ((int)seconds != (int)oldSeconds)
        {
            timerText.text = "島が完成するまで：" + minute.ToString("00") + ":" + ((int)seconds).ToString("00");
        }
        oldSeconds = seconds;
        //　制限時間以下になったらコンソールにEndingSceneに遷移
        if (totalTime < 1.0f)
        {
            // EndingSceneに遷移
            SceneManager.LoadScene("EndingScene");
        }
    }
}
