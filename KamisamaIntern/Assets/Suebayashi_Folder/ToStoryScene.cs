using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToStoryScene : MonoBehaviour
{
    public FadeController fadeController; //FadeControllerクラスのインスタンスを生成

    // ToStoryButtonが押された際に呼び出される
    public void ToStoryButton()
    {
        // コルーチンが呼び出される
        StartCoroutine("ToStorySceneCoroutine"); 
    }

    private IEnumerator ToStorySceneCoroutine()
    {
        // ボタンクリック時にSEが鳴る
        GetComponent<AudioSource>().Play();

        yield return new WaitForSeconds(0.8f);

        // フェイドアウトする
        fadeController.isFadeOut = true;

        yield return new WaitForSeconds(1.0f);

        // StorySceneに遷移
        SceneManager.LoadScene("StoryScene");

    }
}
