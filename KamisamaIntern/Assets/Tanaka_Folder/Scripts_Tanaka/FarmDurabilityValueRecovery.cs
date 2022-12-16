using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmDurabilityValueRecovery : MonoBehaviour
{
    [SerializeField]
    private GameObject[] Items;

    int i = 0;
    int j = 0;
    bool full = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()

    {
    }

    // when the GameObjects collider arrange for this GameObject to travel to the left of the screen
    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.name != null)
        {
            Debug.Log(collider.gameObject.name);

            if (i < 9)
            {
                Items[i] = collider.gameObject;
                i++;
            }
            else
            {
                if (!full)
                {
                    int k = Random.Range(0, Items.Length);
                    Debug.Log("‚¦‚ç‚Î‚ê‚½‚Ì‚Í" + Items[k]);
                    Destroy(Items[k].gameObject);

                    full = true;
                }
            }
        }
    }
}