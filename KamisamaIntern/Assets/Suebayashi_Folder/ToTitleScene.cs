using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToTitleScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // ToTitleButton�������ꂽ�ۂɌĂяo�����
    public void ToTitleButton()
    {
        StartCoroutine("WaitTimeAfterSound");
    }
    private IEnumerator WaitTimeAfterSound()
    {
        GetComponent<AudioSource>().Play();  // ���ʉ���炷

        yield return new WaitForSeconds(1.0f);

        SceneManager.LoadScene("TitleScene"); // StoryScene�ɑJ��
    }
}
