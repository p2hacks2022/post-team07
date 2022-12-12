using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StorySceneController : MonoBehaviour
{

    public FadeController myFade;

    //画面上のテキストオブジェクト
    [SerializeField]
    private Text text;

    //文章が記入されているテキストファイル
    [SerializeField]
    private TextAsset scenarioAsset;

    //分割した文字列を格納する配列
    private string[] wordArray;

    //文章を代入する変数
    private string scenario;

    //文章を改行で分けたものを入れる変数
    private string[] scenarios;

    //現在の行番号
    private int currentLine = 0;

    //マウスが押されたかどうか示す変数
    private bool isPush = false;

    // Start is called before the first frame update
    void Start()
    {
        //表示したい文章
        //テキストファイルから取得
        scenario = scenarioAsset.text;
        
        //シナリオをaで分ける
        scenarios = scenario.Split("a");   
    }

    // Update is called once per frame
    void Update()
    {
        //行番号が最後まで行っていない状態でマウスを左クリックすると、テキスト更新
        if(isPush == false && currentLine < scenarios.Length && Input.GetMouseButtonDown(0))
        {
            //コルーチン開始
            StartCoroutine("SetText");
        }

        //最後の行番号まで行ったら
        if(currentLine == scenarios.Length){
            //シーン替え用コルーチン開始
            StartCoroutine("ChangeScene");
        }
    }

    IEnumerator SetText()
    {
        //2度おし防止用
        isPush =true;
        
        //現在の行番号の文章を、カンマで分割
        wordArray = scenarios[currentLine].Split(',');

        //wordArrayの文字数分操作を行う
        foreach ( var p  in wordArray)
        {
            //１文字ずつ代入
            text.text = text.text + p;

            //0.1秒待つ
            yield return new WaitForSeconds(0.1f);
        }

        //行番号を更新
        currentLine++;

        //マウスクリックで進むようにする
        isPush = false;
    }

    IEnumerator ChangeScene()
    {
        myFade.isFadeOut = true;
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("GameScene");
    }
}
