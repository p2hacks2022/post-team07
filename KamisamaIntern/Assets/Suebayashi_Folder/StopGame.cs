using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // StopGameButtonが押された際に呼び出される
    public void StopGameButton()
    {
        Quit(); //ゲーム終了
    }


    // ゲームを終了する際に呼び出される
    void Quit()
    {
        StartCoroutine("WaitTimeAfterSound");
    }

    private IEnumerator WaitTimeAfterSound()
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
