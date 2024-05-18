using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventPageUI : MonoBehaviour
{
    public GameObject EventPage;//EventPage
    public Text displayEventText;
    public GameObject selectPageObj;
    public GameObject selectBtObj;
    public Text displaySelectText;
    public GameObject selectBtObj2;
    public Text displaySelect2Text;
    public GameObject selectBtObj3;
    public Text displaySelect3Text;

    public GameObject mainUI;

    public float eventRandom = 0.0f;
    public int eventRandomToint = 0;



    void Start()
    {
        selectPageObj.SetActive(false);
        selectBtObj2.SetActive(false);
        selectBtObj3.SetActive(false);
        eventRandom = 0.0f;
        StartCoroutine(DisplayEventTextCoroutine());
    }

    void OnEnable()
    {
        //StartCoroutine(DisplayEventTextCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        //DisplayEventText();
    }

    public void onUpdate()
    {
        eventRandom = 0.0f;
        DisplayEventText();
    }

    public void OnEventNextClick()
    {
        selectPageObj.SetActive(true);
        OnSelectNumbersCheck();
    }

    public void OnSelectNumbersCheck()
    {
        selectBtObj.SetActive(true);
        if (ReportDataManager.Instance.useReportData[eventRandomToint].ResultText2 != null)
        {
            selectBtObj2.SetActive(true);
        }
        else if (ReportDataManager.Instance.useReportData[eventRandomToint].ResultText3 != null)
        {
            selectBtObj3.SetActive(true);
        }
    }

    public void Select1()
    {
        OnOff();
    }

    public void Select2()
    {
        OnOff();
    }
    
    public void Select3()
    {
        OnOff();
    }

    public void OnOff()
    {
        DeactivateAllChildren(EventPage);
        ActivateAllChildren(mainUI);
    }

    // 비동기 작업을 수행할 코루틴
    public void DisplayEventText()
    {
        StartCoroutine(DisplayEventTextCoroutine());
    }
    public IEnumerator DisplayEventTextCoroutine()
    {
        // 랜덤 값 생성
        eventRandomToint = UnityEngine.Random.Range(0, 76);

        // ReportDataManager에서 데이터 가져오기
        var reportData = ReportDataManager.Instance.useReportData[eventRandomToint];

        // EventText 업데이트
        string eventText = reportData.EventText;
        displayEventText.text = eventText;
        yield return null; // 다음 프레임까지 대기

        // SelectText1 업데이트
        string selectText = reportData.SelectText1;
        displaySelectText.text = selectText;
        yield return null; // 다음 프레임까지 대기

        // SelectText2 업데이트
        string select2Text = reportData.SelectText2;
        displaySelect2Text.text = select2Text;
        yield return null; // 다음 프레임까지 대기

        // SelectText3 업데이트
        string select3Text = reportData.SelectText3;
        displaySelect3Text.text = select3Text;
        yield return null; // 다음 프레임까지 대기
    }

    // public void DisplayEventText()
    // {
    //     eventRandom = UnityEngine.Random.Range(0, 77);
    //     eventRandomToint = Convert.ToInt32(eventRandom);
    //     //여기를 랜덤으로 하면될꺼같은데
    //     string eventText = ReportDataManager.Instance.useReportData[eventRandomToint].EventText;
    //     displayEventText.text = eventText;

    //     string slectText = ReportDataManager.Instance.useReportData[eventRandomToint].SelectText1;
    //     displaySelectText.text = slectText;

    //     string slect2Text = ReportDataManager.Instance.useReportData[eventRandomToint].SelectText2;
    //     displaySelect2Text.text = slect2Text;

    //     string slect3Text = ReportDataManager.Instance.useReportData[eventRandomToint].SelectText2;
    //     displaySelect3Text.text = slect3Text;
    // }

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