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
        //���ǿ���
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
        //��忣��
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
        //Ȳ�ݼ� ���
        else if (Stat.instance.money > 200000 && Stat.instance.leader < 2000)
        {

        }
        //Ȳ�ݼ� ����
        else if (Stat.instance.money > 200000 && Stat.instance.leader > 2000)
        {

        }
        //������ ������
        else if (Stat.instance.money > 200000 && Stat.instance.army > 200000 && Stat.instance.HP < 2000)
        {

        }
        //��ö�� ���
        else if (Stat.instance.army > 200000 && Stat.instance.HP >= 2000)
        {

        }
        //�츮 �翡�� �׻� ���� ��ô�
        else if (Stat.instance.faith > 200000 && Stat.instance.wisdom >= 2000)
        {

        }
        //������ �����Ǿ�
        else if (Stat.instance.science > 200000 && Stat.instance.intel >= 2000)
        {

        }
        //�̴� ������ ź��
        else if (Stat.instance.faith > 200000 && Stat.instance.wisdom < 2000 && Stat.instance.leader < 2000)
        {

        }
        //��ȭ�� ���
        else if (Stat.instance.politics > 200000 && Stat.instance.wisdom >= 2000 && Stat.instance.leader >= 2000)
        {

        }

    }

    public void Ending1()
    {

    }
}
