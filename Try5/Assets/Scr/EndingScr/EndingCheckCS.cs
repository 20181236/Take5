using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingCheckCS : MonoBehaviour
{

    public int endingValue = 0;

    // Start is called before the first frame update
    void Start()
    {
        void Start()
        {
            endingValue = 0;
            // ���� Ȯ�� �Լ� ȣ��
            EndingChecking();

            // ������ ���� �ٸ� ���� �ε��մϴ�.

        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GoEnding()
    {
        switch (endingValue)
        {
            case 0:
                SceneManager.LoadScene("Ending_0");
                break;
            case 1:
                SceneManager.LoadScene("Ending_1");
                break;
            case 2:
                SceneManager.LoadScene("Ending_2");
                break;
            case 3:
                SceneManager.LoadScene("GoldenParadiseScene");
                break;
            case 4:
                SceneManager.LoadScene("DictatorOfFearScene");
                break;
            case 5:
                SceneManager.LoadScene("FortressOfSteelScene");
                break;
            case 6:
                SceneManager.LoadScene("GodAlwaysWithUsScene");
                break;
            case 7:
                SceneManager.LoadScene("UtopiaOfKnowledgeScene");
                break;
            case 8:
                SceneManager.LoadScene("BirthOfHeresyScene");
                break;
            case 9:
                SceneManager.LoadScene("FortressOfPeaceScene");
                break;
            default:
                // �⺻������ � �������� �ش����� �ʴ´ٸ� �⺻ ���� �ε��մϴ�.
                SceneManager.LoadScene("DefaultScene");
                break;
        }
    }

    public void EndingChecking()
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
            endingValue = 0;
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
            endingValue = 1;
        }
        //Ȳ�ݼ� ���
        else if (Stat.instance.money > 200000 && Stat.instance.leader < 2000)
        {
            endingValue = 2;
        }
        //Ȳ�ݼ� ����
        else if (Stat.instance.money > 200000 && Stat.instance.leader > 2000)
        {
            endingValue = 3;
        }
        //������ ������
        else if (Stat.instance.money > 200000 && Stat.instance.army > 200000 && Stat.instance.HP < 2000)
        {
            endingValue = 4;
        }
        //��ö�� ���
        else if (Stat.instance.army > 200000 && Stat.instance.HP >= 2000)
        {
            endingValue = 5;
        }
        //�츮 �翡�� �׻� ���� ��ô�
        else if (Stat.instance.faith > 200000 && Stat.instance.wisdom >= 2000)
        {
            endingValue = 6;
        }
        //������ �����Ǿ�
        else if (Stat.instance.science > 200000 && Stat.instance.intel >= 2000)
        {
            endingValue = 7;
        }
        //�̴� ������ ź��
        else if (Stat.instance.faith > 200000 && Stat.instance.wisdom < 2000 && Stat.instance.leader < 2000)
        {
            endingValue = 8;
        }
        //��ȭ�� ���
        else if (Stat.instance.politics > 200000 && Stat.instance.wisdom >= 2000 && Stat.instance.leader >= 2000)
        {
            endingValue = 9;
        }

    }

    public void Ending1()
    {

    }
}
