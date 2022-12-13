using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToStoryScene : MonoBehaviour
{
    public FadeController fadeController; //FadeController�N���X�̃C���X�^���X�𐶐�

    // ToStoryButton�������ꂽ�ۂɌĂяo�����
    public void ToStoryButton()
    {
        // �R���[�`�����Ăяo�����
        StartCoroutine("ToStorySceneCoroutine"); 
    }

    private IEnumerator ToStorySceneCoroutine()
    {
        // �{�^���N���b�N����SE����
        GetComponent<AudioSource>().Play();

        yield return new WaitForSeconds(0.8f);

        // �t�F�C�h�A�E�g����
        fadeController.isFadeOut = true;

        yield return new WaitForSeconds(1.0f);

        // StoryScene�ɑJ��
        SceneManager.LoadScene("StoryScene");

    }
}
