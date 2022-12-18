using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour
{
    // QuitGameButtonが押された際に呼び出される
    public void QuitGameButton()
    {
        Quit(); //ゲーム終了
    }


    // ゲームを終了する際に呼び出される
    void Quit()
    {
        StartCoroutine("QuitGameCoroutine");
    }

    private IEnumerator QuitGameCoroutine()
    {
        GetComponent<AudioSource>().Play();  // 効果音を鳴らす

        yield return new WaitForSeconds(1.0f);

        /* Unityエディタ（開発環境）でゲームを実行している場合 */
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        /* スタンドアロンで実行している場合 */
        #elif UNITY_STANDALONE
            UnityEngine.Application.Quit();
        #endif
    }
}
