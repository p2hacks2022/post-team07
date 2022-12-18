using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgricultureCard : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AgricultureCardEffect()
    {
        //農場を生成するようになる
        HumanController.isFarm = true;
    }
}
