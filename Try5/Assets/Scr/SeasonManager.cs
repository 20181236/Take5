using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeasonManager : MonoBehaviour
{
    string[] seasonName = new string[]{"봄","여름","가을","겨울"};

    public Text seasonNameChange;
    private int seasonNameChangeNumber=0;
    private int seasonCount=1;

    //public Text turnCount;
    //public Text turnCount2;
    //public Text turnCount3;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Stat.instance.curTurn == 0)
            SeasonChange();
    }

    public void SeasonChange()
    {
        DataManagerTest.dataInstance.nameCount +=1;
        Stat.instance.curTurn = 12;
        seasonNameChangeNumber +=1;
        seasonNameChange.text= seasonCount+"년차 \n"+seasonName[seasonNameChangeNumber];
    }

    public void turnCounting()
    {
        
    }
}
