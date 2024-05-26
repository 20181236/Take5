using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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

    public GameObject reportObj;
    public TMP_Text displayReportText;


    void Start()
    {
        selectPageObj.SetActive(false);
        selectBtObj2.SetActive(false);
        selectBtObj3.SetActive(false);
        eventRandom = 0.0f;
        StartCoroutine(DisplayEventTextCoroutine());
        reportObj.SetActive(false);
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
        //결과창 보이기
        reportObj.SetActive(true);
        //결과창 텍스트보이기
        // ReportDataManager에서 데이터 가져오기
        var reportData = ReportDataManager.Instance.useReportData[eventRandomToint];
        string reportText = reportData.ResultText1;
        // for (int i = 0; i < reportText.Length; i++)
        // {
        //     displayReportText.text += reportText[i];
        //     yield return new WaitForSeconds(0.05f);
        // }
        SelectStatUp();
        StartCoroutine(Typing(reportText));
        //displayReportText.text = reportText;
        //결과창 스테미나 상승보이기

    }

    public void Select2()
    {
        OnOff();
        reportObj.SetActive(true);
        var reportData = ReportDataManager.Instance.useReportData[eventRandomToint];
        string reportText = reportData.ResultText2;
        displayReportText.text = reportText;
        SelectStatUp();
    }

    public void Select3()
    {
        OnOff();
        reportObj.SetActive(true);
        var reportData = ReportDataManager.Instance.useReportData[eventRandomToint];
        string reportText = reportData.ResultText3;
        displayReportText.text = reportText;
        SelectStatUp();
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

    IEnumerator Typing(string talk)
    {
        //displayReportText.text=null;

        for (int i = 0; i < talk.Length; i++)
        {
            displayReportText.text += talk[i];
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void SelectStatUp()
    {

        var reportData = ReportDataManager.Instance.useReportData[eventRandomToint];
        // 각 필드를 nullable int로 선언
        // 각 필드를 nullable int로 선언
        int? selectedArmy = reportData.SelectArmy;
        int? selectedMoney = reportData.SelectMoney;
        int? selectedFaith = reportData.SelectFaith;
        int? selectedScience = reportData.SelectScience;
        int? selectedPolitics = reportData.SelectPolitics;

        // Army 처리
        if (selectedArmy.HasValue)
        {
            Stat.instance.army += selectedArmy.Value;
        }
        else
        {
            Debug.Log("SelectArmy는 null입니다.");
        }

        // Money 처리
        if (selectedMoney.HasValue)
        {
            Stat.instance.money += selectedMoney.Value;
        }
        else
        {
            Debug.Log("SelectMoney는 null입니다.");
        }

        // Faith 처리
        if (selectedFaith.HasValue)
        {
            Stat.instance.faith += selectedFaith.Value;
        }
        else
        {
            Debug.Log("SelectFaith는 null입니다.");
        }

        // Science 처리
        if (selectedScience.HasValue)
        {
            Stat.instance.science += selectedScience.Value;
        }
        else
        {
            Debug.Log("SelectScience는 null입니다.");
        }

        // Politics 처리
        if (selectedPolitics.HasValue)
        {
            Stat.instance.politics += selectedPolitics.Value;
        }
        else
        {
            Debug.Log("SelectPolitics는 null입니다.");
        }
    }

}