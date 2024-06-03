using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingCheckCS : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void EndingChecting()
    {
        //해피엔딩
        if (Stat.instance.money >= 150000 &&
            Stat.instance.army >= 150000 &&
            Stat.instance.faith >= 150000 &&
            Stat.instance.science >= 150000 &&
            Stat.instance.politics >= 150000 &&
            Stat.instance.HP >= 900 &&
            Stat.instance.intel >= 900 &&
            Stat.instance.wisdom >= 900 &&
            Stat.instance.leader >= 900)
        {


        }
        //배드엔딩
        else if (Stat.instance.money < 150000 &&
                 Stat.instance.army < 150000 &&
                 Stat.instance.faith < 150000 &&
                 Stat.instance.science < 150000 &&
                 Stat.instance.politics < 150000 &&
                 Stat.instance.HP < 900 &&
                 Stat.instance.intel < 900 &&
                 Stat.instance.wisdom < 900 &&
                 Stat.instance.leader < 900)
        {

        }
        //황금속 어둠
        else if (Stat.instance.money > 200000 && Stat.instance.leader < 2000)
        {

        }
        //황금속 낙원
        else if (Stat.instance.money > 200000 && Stat.instance.leader > 2000)
        {

        }
        //공포의 독재자
        else if (Stat.instance.money > 200000 && Stat.instance.army > 200000 && Stat.instance.HP < 2000)
        {

        }
        //강철의 요새
        else if (Stat.instance.army > 200000 && Stat.instance.HP >= 2000)
        {

        }
        //우리 곁에는 항상 신이 계시니
        else if (Stat.instance.faith > 200000 && Stat.instance.wisdom >= 2000)
        {

        }
        //지식의 유토피아
        else if (Stat.instance.science > 200000 && Stat.instance.intel >= 2000)
        {

        }
        //이단 국가의 탄생
        else if (Stat.instance.faith > 200000 && Stat.instance.wisdom < 2000 && Stat.instance.leader < 2000)
        {

        }
        //평화의 요새
        else if (Stat.instance.politics > 200000 && Stat.instance.wisdom >= 2000 && Stat.instance.leader >= 2000)
        {

        }

    }

    public void Ending1()
    {

    }
}
