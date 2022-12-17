using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplainController : MonoBehaviour
{

    public TileExplainController myTile;

    public CardExplainController mycard;

    public GameExplainController myGame;

    public GameObject explainPanel;

    public GameObject tilePanel;

    public GameObject cardPanel;

    public GameObject selectPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenGameExplain()
    {
        myGame.pageNum = 0;
        explainPanel.SetActive(true);
        selectPanel.SetActive(false);
    }

    public void OpenTileExplain()
    {
        myTile.pageNum = 0;
        tilePanel.SetActive(true);
        selectPanel.SetActive(false);
    }

    public void OpenCardExplain()
    {
        mycard.pageNum = 0;
        cardPanel.SetActive(true);
        selectPanel.SetActive(false);
    }

    public void BackSelect()
    {
        explainPanel.SetActive(false);
        tilePanel.SetActive(false);
        cardPanel.SetActive(false);
        selectPanel.SetActive(true);
    }
}
