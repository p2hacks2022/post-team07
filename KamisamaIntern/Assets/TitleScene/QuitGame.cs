using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour
{
    // QuitGameButton�������ꂽ�ۂɌĂяo�����
    public void QuitGameButton()
    {
        Quit(); //�Q�[���I��
    }


    // �Q�[�����I������ۂɌĂяo�����
    void Quit()
    {
        StartCoroutine("QuitGameCoroutine");
    }

    private IEnumerator QuitGameCoroutine()
    {
        GetComponent<AudioSource>().Play();  // ���ʉ���炷

        yield return new WaitForSeconds(1.0f);

        /* Unity�G�f�B�^�i�J�����j�ŃQ�[�������s���Ă���ꍇ */
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        /* �X�^���h�A�����Ŏ��s���Ă���ꍇ */
        #elif UNITY_STANDALONE
            UnityEngine.Application.Quit();
        #endif
    }
}
