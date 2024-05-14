using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class UiAll : MonoBehaviour
{

    public Transform operationButtonTr;
    public Transform growButtonTr;
    public Transform restButtonTr;

    //이건 상세창 띄고안띄우고
    public bool onCheckDeatil=false;

    // Start is called before the first frame update
    void Start()
    {
        //operationButtonTr = GameObject.Find("OperateButton").GetComponent<Transform>();
        growButtonTr = GameObject.Find("GrowButton").GetComponent<Transform>();
        restButtonTr = GameObject.Find("Rest").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BackTran()
    {
        operationButtonTr.transform.localPosition = new Vector3Int(52,-40,53);       
        growButtonTr.transform.localPosition = new Vector3Int(86,-40,53);
        restButtonTr.transform.localPosition = new Vector3Int(70,-60,53);
    }
}
