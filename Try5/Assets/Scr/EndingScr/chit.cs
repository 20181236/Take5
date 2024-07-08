using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Happyending()
    {
        Stat.instance.money = 150000;
            Stat.instance.army = 150000;
            Stat.instance.faith = 150000;
            Stat.instance.science = 150000;
            Stat.instance.politics = 150000;
            Stat.instance.HP = 900;
            Stat.instance.intel = 900;
            Stat.instance.wisdom = 900;
            Stat.instance.leader = 900;
        Stat.instance.year = 1;
        Stat.instance.curTurn = 1;

    }

    public void BadEnding()
    {
        Stat.instance.money = 10 ;
                 Stat.instance.army = 10;
                 Stat.instance.faith = 10;
                 Stat.instance.science = 10;
                 Stat.instance.politics = 10;
                 Stat.instance.HP = 10;
                 Stat.instance.intel = 10;
                 Stat.instance.wisdom = 10;
                 Stat.instance.leader = 10;
        Stat.instance.year = 1;
        Stat.instance.curTurn = 1;
    }
    public void richi()
    {
        Stat.instance.money = 300000; Stat.instance.leader = 1000;
    }
}
