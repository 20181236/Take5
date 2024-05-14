using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StateChange : MonoBehaviour
{

    //public int curState=0;
    public State curState = State.report;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //버튼 클릭시 이 함수 사용되게
    public void NextState()
    {
        if (curState == State.choice)
            curState = State.report;
        else
            curState += 1;
    }
    public void CheckState()
    {
        switch (curState)
        {
            case State.report:
                ReportPage();
                break;
            case State.process:
                ProcessPage();
                break;
            case State.eventPage:
                EventPage();
                break;
            case State.choice:
                ChoicePage();
                break;
        }
    }

    //음 보고 단계에서 해야할 함수
    public void ReportPage()
    {
        //해야할 일 : 페이지 띄우기, 텍스트 출력, 확인버튼 활성화, 
        NextState();
    }
    //보고다음 진행 함수
    public void ProcessPage()
    {
        NextState();
    }
    public void EventPage()
    {
        NextState();
    }
    public void ChoicePage()
    {
NextState();
    }

    public enum State
    {
        report,
        process,
        eventPage,
        choice,
    };
}