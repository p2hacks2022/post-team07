using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndingBranch : MonoBehaviour
{

    [SerializeField]
    private Sprite[] sprites;
    
    [SerializeField]
    private AudioClip[] clips;

    [SerializeField]
    private Image endingPanel;

    [SerializeField]
    private AudioSource audio;

    [SerializeField]
    private int endingNum = 0;

    // Start is called before the first frame update
    void Start()
    {
        endingNum = PointCount.endingNum;
        endingPanel.sprite = sprites[endingNum -1];

        switch(endingNum)
        {
            case 1:
            default:
                audio.clip = clips[0];
            break;
            case 2:
            case 3:
            case 4:
                audio.clip = clips[1];
            break;
        }

        audio.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
