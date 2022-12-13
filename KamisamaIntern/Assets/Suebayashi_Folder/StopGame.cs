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

    // StopGameButton�������ꂽ�ۂɌĂяo�����
    public void StopGameButton()
    {
        Quit(); //�Q�[���I��
    }


    // �Q�[�����I������ۂɌĂяo�����
    void Quit()
    {
        StartCoroutine("WaitTimeAfterSound");
    }

    private IEnumerator WaitTimeAfterSound()
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
