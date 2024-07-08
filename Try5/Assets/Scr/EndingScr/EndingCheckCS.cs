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
            // 엔딩 확인 함수 호출
            EndingChecking();

            // 엔딩에 따라 다른 씬을 로드합니다.

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
                // 기본적으로 어떤 엔딩에도 해당하지 않는다면 기본 씬을 로드합니다.
                SceneManager.LoadScene("DefaultScene");
                break;
        }
    }

    public void EndingChecking()
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
            endingValue = 0;
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
            endingValue = 1;
        }
        //황금속 어둠
        else if (Stat.instance.money > 200000 && Stat.instance.leader < 2000)
        {
            endingValue = 2;
        }
        //황금속 낙원
        else if (Stat.instance.money > 200000 && Stat.instance.leader > 2000)
        {
            endingValue = 3;
        }
        //공포의 독재자
        else if (Stat.instance.money > 200000 && Stat.instance.army > 200000 && Stat.instance.HP < 2000)
        {
            endingValue = 4;
        }
        //강철의 요새
        else if (Stat.instance.army > 200000 && Stat.instance.HP >= 2000)
        {
            endingValue = 5;
        }
        //우리 곁에는 항상 신이 계시니
        else if (Stat.instance.faith > 200000 && Stat.instance.wisdom >= 2000)
        {
            endingValue = 6;
        }
        //지식의 유토피아
        else if (Stat.instance.science > 200000 && Stat.instance.intel >= 2000)
        {
            endingValue = 7;
        }
        //이단 국가의 탄생
        else if (Stat.instance.faith > 200000 && Stat.instance.wisdom < 2000 && Stat.instance.leader < 2000)
        {
            endingValue = 8;
        }
        //평화의 요새
        else if (Stat.instance.politics > 200000 && Stat.instance.wisdom >= 2000 && Stat.instance.leader >= 2000)
        {
            endingValue = 9;
        }

    }

    public void Ending1()
    {

    }
}
