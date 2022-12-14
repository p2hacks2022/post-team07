using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToTitleScene : MonoBehaviour
{
    // ToTitleButton�������ꂽ�ۂɌĂяo�����
    public void ToTitleButton()
    {
        // �R���[�`�����Ăяo�����
        StartCoroutine("ToTitleSceneCoroutine");
    }
    private IEnumerator ToTitleSceneCoroutine()
    {
        // �{�^���N���b�N����SE����
        GetComponent<AudioSource>().Play();

        yield return new WaitForSeconds(0.4f);

        // TitleScene�ɑJ��
        SceneManager.LoadScene("TitleScene"); 
    }
}
