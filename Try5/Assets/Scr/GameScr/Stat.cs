using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class Stat : MonoBehaviour
{
    public static Stat instance;

    // 관리할 변수들
    public int HP=0;
    public int maxHP=3000;
    public int intel=0;
    public int maxIntel=3000;
    public int leader=0;
    public int maxLeader=3000;
    public int wisdom=0;
    public int maxWisdom=3000;

    public int money=0;
    public int army=0;
    public int faith=0;
    public int science=0;
    public int politics=0;

    public float stamina=100f;
    public float maxStamina=100f;
    public float minStamina=100f;

    public int curTurn=52;
    public int countingTurn=0;

    public int year=1;
    //public int givedTrun=12;

    void Awake()
    {
        if (instance == null)   
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
        public void TurnManagement()
    {
        curTurn -= 1;
        countingTurn += 1;
        stamina -= 30f;
    }

    //나중에 상속으로 하든 뭘하든 정리 할 것
    public void HPUp()
    {
        if (curTurn > 0)
        {
            HP += 300;
            TurnManagement();
        }

    }

    public void IntelUp()
    {
        if (curTurn > 0)
        {
            intel += 300;
            TurnManagement();
        }
    }

    public void LeaderUp()
    {
        if (curTurn > 0)
        {
            leader += 300;
            TurnManagement();
        }
    }

    public void WisdomUp()
    {
        if (curTurn > 0)
        {
            wisdom += 300;
            TurnManagement();
        }
    }

    public void NextYear()
    {
        if(curTurn==0)
        {
            year+=1;
            curTurn = 5;
        }
    }
    public void EndingCheck()
    {
        if(year>=2)
        {
            SceneManager.LoadScene("Bridge");
        }
    }
}
