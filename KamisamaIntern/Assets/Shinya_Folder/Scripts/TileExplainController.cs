using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileExplainController : MonoBehaviour
{


    public Image explainImage;

    public int pageNum = 0;

    public Text explainText;

    public Sprite[] explainsprites;

    public string[] explainString;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        explainText.text = explainString[pageNum];

        explainImage.sprite = explainsprites[pageNum];

    }

    public void PageNext()
    {
        if(pageNum < explainsprites.Length - 1)
        {
            pageNum++;
        }
    }

    public void PageBack()
    {
        if(pageNum > 0)
        {
            pageNum--;
        }
    }
}
