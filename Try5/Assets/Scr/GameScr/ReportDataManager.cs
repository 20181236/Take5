using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

[System.Serializable]
public class ReportData
{
    public int No;
    public string Name;
    public string EventText;
    public int UseStamina;
    public int SecondSelectUseStamina;
    public int ThirdSelectUseStamina;
    public string SelectText1;
    public string SelectText2;
    public string SelectText3;
    public string ResultText1;
    public string ResultText2;
    public string ResultText3;
    public int SelectMoney;
    public int SelectArmy;
    public int SelectFaith;
    public int SelectScience;
    public int SelectPolitics;
    public int SecondSelectMoney;
    public int SecondSelectArmy;
    public int SecondSelectFaith;
    public int SecondSelectScience;
    public int SecondSelectPolitics;
    public int ThirdSelectMoney;
    public int ThirdSelectArmy;
    public int ThirdSelectFaith;
    public int ThirdSelectScience;
    public int ThirdSelectPolitics;

    // 생성자 초기화
    public ReportData(int no, string name, string eventText, int useStamina,
                      int secondSelectUseStamina, int thirdSelectUseStamina,
                      string selectText1, string selectText2, string selectText3,
                      string resultText1, string resultText2, string resultText3,
                      int selectMoney, int selectArmy, int selectFaith,
                      int selectScience, int selectPolitics,
                      int secondSelectMoney, int secondSelectArmy,
                      int secondSelectFaith, int secondSelectScience,
                      int secondSelectPolitics,
                      int thirdSelectMoney, int thirdSelectArmy,
                      int thirdSelectFaith, int thirdSelectScience,
                      int thirdSelectPolitics)
    {
        No = no;
        Name = name;
        EventText = eventText;
        UseStamina = useStamina;
        SecondSelectUseStamina = secondSelectUseStamina;
        ThirdSelectUseStamina = thirdSelectUseStamina;
        SelectText1 = selectText1;
        SelectText2 = selectText2;
        SelectText3 = selectText3;
        ResultText1 = resultText1;
        ResultText2 = resultText2;
        ResultText3 = resultText3;
        SelectMoney = selectMoney;
        SelectArmy = selectArmy;
        SelectFaith = selectFaith;
        SelectScience = selectScience;
        SelectPolitics = selectPolitics;
        SecondSelectMoney = secondSelectMoney;
        SecondSelectArmy = secondSelectArmy;
        SecondSelectFaith = secondSelectFaith;
        SecondSelectScience = secondSelectScience;
        SecondSelectPolitics = secondSelectPolitics;
        ThirdSelectMoney = thirdSelectMoney;
        ThirdSelectArmy = thirdSelectArmy;
        ThirdSelectFaith = thirdSelectFaith;
        ThirdSelectScience = thirdSelectScience;
        ThirdSelectPolitics = thirdSelectPolitics;
    }
}

[System.Serializable]
public class AllReportData
{
    public List<ReportData> reportList = new List<ReportData>();
}

public class ReportDataManager : MonoBehaviour
{
    public static ReportDataManager Instance;

    public AllReportData allReportData;
    public List<ReportData> useReportData = new List<ReportData>(); // 사용할 ReportData 리스트
    public string filePath = "Assets/Resource/DataTable/EventTest3.json";
    //public const string filePath = "DataTable/EventTest3.json";

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        LoadJsonData();
    }

    void Update()
    {
    }

    void LoadJsonData()
    {
        string jsonContent = File.ReadAllText(filePath); // JSON 파일 읽기
        allReportData = JsonUtility.FromJson<AllReportData>(jsonContent); // JSON 파싱
        if (allReportData != null && allReportData.reportList != null)
        {
            Debug.Log("Loaded " + allReportData.reportList.Count + " report entries.");

            // useReportData에 모든 ReportData 추가
            useReportData.AddRange(allReportData.reportList);

            foreach (var eventDataItem in allReportData.reportList)
            {
                Debug.Log("Processing report data: " + eventDataItem.Name);
                // 추가적인 처리나 로직 수행
            }
        }
        else
        {
            Debug.LogError("Failed to load or invalid report data.");
        }
    }
}