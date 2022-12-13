using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeController : MonoBehaviour
{
    //フェードアウトする際のスピード
    private float fadeSpeed = 0.01f;

    //パネルの色と透明度
    private float red, green, blue, alfa;

    public bool isFadeOut = false;

    [SerializeField]
    private Image fadeImage;

    // Start is called before the first frame update
    void Start()
    {
        //Imageのコンポーネントを取得
        fadeImage = GetComponent<Image>();
        //パネルの色と透明度の初期化
        red = fadeImage.color.r;
        green = fadeImage.color.g;
        blue = fadeImage.color.b;
        alfa = fadeImage.color.a;
    }

    // Update is called once per frame
    void Update()
    {
        if(isFadeOut)
        {
            StartFadeOut();
        }
    }

    void StartFadeOut()
    {
        fadeImage.enabled = true;
        alfa += fadeSpeed;
        SetAlpfa();
        if(alfa >= 1)
        {
            isFadeOut =false;
        }
    }

    void SetAlpfa()
    {
        fadeImage.color = new Color(red, green, blue, alfa);
    }
}
