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


    void Start()
    {
        selectPageObj.SetActive(false);
        selectBtObj2.SetActive(false);
        selectBtObj3.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
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
        if (ReportDataManager.Instance.useReportData[Stat.instance.countingTurn].ResultText2 != null)
        {
            selectBtObj2.SetActive(true);
        }
        else if (ReportDataManager.Instance.useReportData[Stat.instance.countingTurn].ResultText3 != null)
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

    public void DisplayEventText()
    {
        string eventText = ReportDataManager.Instance.useReportData[Stat.instance.countingTurn].EventText;
        displayEventText.text = eventText;

        string slectText = ReportDataManager.Instance.useReportData[Stat.instance.countingTurn].SelectText1;
        displaySelectText.text = slectText;

        string slect2Text = ReportDataManager.Instance.useReportData[Stat.instance.countingTurn].SelectText2;
        displaySelect2Text.text = slect2Text;

        string slect3Text = ReportDataManager.Instance.useReportData[Stat.instance.countingTurn].SelectText2;
        displaySelect3Text.text = slect3Text;
    }

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