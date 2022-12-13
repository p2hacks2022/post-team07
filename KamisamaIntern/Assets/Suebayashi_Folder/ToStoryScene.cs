using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToStoryScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // ToStoryButton‚ª‰Ÿ‚³‚ê‚½Û‚ÉŒÄ‚Ño‚³‚ê‚é
    public void ToStoryButton()
    {
        StartCoroutine("WaitTimeAfterSound");
    }

    private IEnumerator WaitTimeAfterSound()
    {
        GetComponent<AudioSource>().Play();  // Œø‰Ê‰¹‚ğ–Â‚ç‚·

        yield return new WaitForSeconds(1.0f);

        SceneManager.LoadScene("StoryScene"); // StoryScene‚É‘JˆÚ

    }
}
