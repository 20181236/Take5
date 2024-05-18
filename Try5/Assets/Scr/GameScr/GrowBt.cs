using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GrowBt;

public class GrowBt : MonoBehaviour
{
    public enum BtState
    {
        hpState,
        intelState,
        leaderState,
        wisdomState
    }

    private BtState currentState = BtState.hpState;

    public GameObject uigObj;
    public GameObject growPageObj;
    public GameObject growBGObj;
    public GameObject hpBtObj;
    public GameObject intelBtObj;
    public GameObject leaderBtObj;
    public GameObject wisdomBtObj;
    public GameObject activeArrow;

    public GameObject bgObj;
    public GameObject growBtObj;
    public GameObject mainBtObj;


    private float xPosition;
    Vector3 arrowPosition;
    Vector3 plusPosition = new Vector3(0.0f, 7.0f, 0.0f);

    public List<GameObject> backgrounds; // 배경화면 오브젝트들을 담을 리스트
    private int currentBackgroundIndex = 0; // 현재 보여지는 배경화면 인덱스

    public GameObject mainUiObj;
    public GameObject nextToEventPage;//EventPage

    public EventPageUI eventPageUIClass;


    // Start is called before the first frame update
    void Start()
    {
        growPageObj.SetActive(false);
        currentState = BtState.hpState;
        arrowPosition = growPageObj.transform.position;
        nextToEventPage.SetActive(false);
        bgObj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnGrowClick()
    {
        growPageObj.SetActive(true);
        mainBtObj.SetActive(false);
        GrowBtActive();
        ShowBackground(currentBackgroundIndex);
        ActivateAllChildren(growPageObj);
    }

    public void OnGrowHpBtClick()
    {
        currentState = BtState.hpState;
        ChangeBackground(0);
        ActiveArrowTransform(hpBtObj);
    }

    public void OnGrowIntelBtClick()
    {
        currentState = BtState.intelState;
        ActiveArrowTransform(intelBtObj);
        ChangeBackground(1);
    }
    public void OnGrowLeaderBtClick()
    {
        currentState = BtState.leaderState;
        ActiveArrowTransform(leaderBtObj);
        ChangeBackground(2);
    }

    public void OnGrowWisdomBtClick()
    {
        currentState = BtState.wisdomState;
        ActiveArrowTransform(wisdomBtObj);
        ChangeBackground(3);
    }

    public void OnGrowDecideBtClick()
    {
        switch (currentState)
        {
            case BtState.hpState:
                Stat.instance.HPUp();
                break;

            case BtState.intelState:
                Stat.instance.IntelUp();
                break;

            case BtState.leaderState:
                Stat.instance.LeaderUp();
                break;

            case BtState.wisdomState:
                Stat.instance.WisdomUp();
                break;

            default:
                // 알려지지 않은 상태에 대한 처리 없음
                break;
        }
        ChangeEventPage();
    }

    private void ChangeEventPage()
    {
        //버튼들만 끄ㅜ면될듯
        GrowBtDisActive();
        //이벤트 페이지 켜져야됨
        nextToEventPage.SetActive(true);
        ActivateAllChildren(nextToEventPage);
                //동시에
        //eventPageUIClass.DisplayEventText();
    }

    public void GrowBtActive()
    {
        ActivateAllChildren(growPageObj);
        // growBGObj.SetActive(true);
        // hpBtObj.SetActive(true);
        // intelBtObj.SetActive(true);
        // leaderBtObj.SetActive(true);
        // wisdomBtObj.SetActive(true);
    }

        public void GrowBtDisActive()
    {
        growBGObj.SetActive(false);
        hpBtObj.SetActive(false);
        intelBtObj.SetActive(false);
        leaderBtObj.SetActive(false);
        wisdomBtObj.SetActive(false);
    }
    public void ActiveArrowTransform(GameObject Object)
    {
        arrowPosition = Object.transform.position;
        activeArrow.transform.position = arrowPosition + plusPosition;
    }

    public void ChangeBackground(int currentState)
    {
        // 다음 배경화면 인덱스 계산
        currentBackgroundIndex = currentState;
        // 현재 배경화면 비활성화 후 다음 배경화면 활성화
        ShowBackground(currentBackgroundIndex);
    }
    private void ShowBackground(int index)
    {
        // 모든 배경화면 오브젝트 비활성화
        foreach (var background in backgrounds)
        {
            background.SetActive(false);
        }

        // 해당 인덱스의 배경화면 오브젝트 활성화
        backgrounds[index].SetActive(true);
    }

    // 주어진 부모 오브젝트의 모든 자식 오브젝트를 활성화하는 함수
    void ActivateAllChildren(GameObject parentObject)
    {
        foreach (Transform child in parentObject.transform)
        {
            child.gameObject.SetActive(true); // 각 자식 오브젝트를 활성화

            // 자식 오브젝트의 자식도 재귀적으로 모두 활성화
            if (child.childCount > 0)
            {
                ActivateAllChildren(child.gameObject);
            }
        }
    }

    void DeactivateAllChildren(GameObject parentObject)
    {
        foreach (Transform child in parentObject.transform)
        {
            child.gameObject.SetActive(false); // 각 자식 오브젝트를 비활성화

            // 자식 오브젝트의 자식도 재귀적으로 모두 비활성화
            if (child.childCount > 0)
            {
                DeactivateAllChildren(child.gameObject);
            }
        }
    }
}
