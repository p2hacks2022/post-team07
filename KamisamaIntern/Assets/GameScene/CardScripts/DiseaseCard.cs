using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiseaseCard : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DiseaseCardEffect()
    {
        //Listの宣言
        List<GameObject> humans = new List<GameObject>();

        humans.AddRange(GameObject.FindGameObjectsWithTag("Human"));

        foreach (GameObject human in humans)
        {
            int rnd = Random.Range(0,3);
            if(rnd == 0){
                Destroy(human);
            }
        }
    }
}
