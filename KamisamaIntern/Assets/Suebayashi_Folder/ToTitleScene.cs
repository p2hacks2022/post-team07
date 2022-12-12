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

    // ToTitleButton‚ª‰Ÿ‚³‚ê‚½Û‚ÉŒÄ‚Ño‚³‚ê‚é
    public void ToTitleButton()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
