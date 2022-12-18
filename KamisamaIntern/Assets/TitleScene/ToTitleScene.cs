using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToTitleScene : MonoBehaviour
{
    // ToTitleButtonが押された際に呼び出される
    public void ToTitleButton()
    {
        // コルーチンが呼び出される
        StartCoroutine("ToTitleSceneCoroutine");
    }
    private IEnumerator ToTitleSceneCoroutine()
    {
        // ボタンクリック時にSEが鳴る
        GetComponent<AudioSource>().Play();

        yield return new WaitForSeconds(0.4f);

        // TitleSceneに遷移
        SceneManager.LoadScene("TitleScene"); 
    }
}
