using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Rendering;
using UnityEngine.UI;

[System.Serializable]
public class EventData
{
    public int sequence;
    public string eventname;
    public int giveturn;
    public int hp;
    public int intel;
    public int leader;
    public int wisdom;
    public int money;
    public int army;
    public int faith;
    public int science;
    public int politics;
    public string display1;
    public string display2;
    public string display3;
    public string display4;

}
[System.Serializable]
public class AllEventData
{
    public EventData[] EventList;
}

public class DataManagerTest : MonoBehaviour
{
    public Text curDisplayText;
    public Text nextDisplayText;
    public Text nextnextDisplayText;
    public Text nextnextnextDisplayText;

    public Text curIfDisplayText;
    public Text ifDisplayText;
    public Text nextIf1DisplayText;
    public Text nextNextIf1DisplayText;
    public int nameCount = 0;
    //public int 
    
    public static DataManagerTest dataInstance;
    public TextAsset data;
    public AllEventData allEventData;
    //public AllEventData datas;//어디다쓰는지 모르겠음

    public string filePath = "Assets/Resource/DataTable/EventTest.json";
    // Start is called before the first frame update
    void Start()
    {
        LoadJsonData();
    }

    // Update is called once per frame
    void Update()
    {
        if (allEventData != null && allEventData.EventList != null && allEventData.EventList.Length > 0)
        {
            string eventName = allEventData.EventList[nameCount].eventname;
            string nextEventName = allEventData.EventList[nameCount+1].eventname;
            string nextnextEventName = allEventData.EventList[nameCount+2].eventname;
            string nextnextnextEventName = allEventData.EventList[nameCount+3].eventname;
            curDisplayText.text = eventName;
            nextDisplayText.text = nextEventName;
            nextnextDisplayText.text = nextnextEventName;
            nextnextnextDisplayText.text = nextnextnextEventName;

            string curEventIf = allEventData.EventList[nameCount].display1;
            string eventIf1 = allEventData.EventList[nameCount+1].display1;
            string nextEventIf1 = allEventData.EventList[nameCount+2].display1;
            string nextNextEventIf1 = allEventData.EventList[nameCount+3].display1;
            curIfDisplayText.text=curEventIf;
            ifDisplayText.text=eventIf1;
            nextIf1DisplayText.text=nextEventIf1;
            nextNextIf1DisplayText.text=nextNextEventIf1;

        }
        else
        {
            // 이벤트 리스트가 비어있는 경우, 에러를 방지하기 위해 텍스트를 비워줍니다.
            curDisplayText.text = "";
            Debug.Log("NON");
        }
    }

    void Awake()
    {
        if (dataInstance == null)
            dataInstance = this;
        else if (dataInstance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    void LoadJsonData()
    {
        string jsonContent = File.ReadAllText(filePath);
        AllEventData eventData = JsonUtility.FromJson<AllEventData>(jsonContent);
        allEventData = JsonUtility.FromJson<AllEventData>(jsonContent);
        //Debug.Log("JSON Content: " + jsonContent);

        if (eventData != null)
        {
            Debug.Log("Object Data is not null.");

            if (eventData.EventList != null)
            {
                Debug.Log("eventList is not null.");

                foreach (var eventDataItem in eventData.EventList)
                {
                    //Debug.Log("Sequence: " + eventDataItem.sequence);
                    //Debug.Log("Event Name: " + eventDataItem.eventname);
                    //Debug.Log("Give Turn: " + eventDataItem.giveturn);
                }
            }
            else
            {
                Debug.Log("eventList is null.");
            }
        }
        else
        {
            Debug.Log("Object Data is null.");
        }
    }
}