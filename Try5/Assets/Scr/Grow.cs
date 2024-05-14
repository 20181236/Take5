using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Grow : MonoBehaviour
{
    public GameObject bt1;
    public GameObject bt2;
    public GameObject bt3;
    public GameObject bt4;
    public GameObject bt5;

    //public Transform operationButtonTr;
    public Transform growButtonTr;
    public Transform restButtonTr;

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

    public void OperationTransActive()
    {
        //operationButtonTr.transform.localPosition = new Vector3Int(70,-60,53);       
        growButtonTr.transform.localPosition = new Vector3Int(2000,2000,2000);
        restButtonTr.transform.localPosition = new Vector3Int(2000,2000,2000);
        bt1.SetActive(true);
        bt2.SetActive(true);
        bt3.SetActive(true);
        bt4.SetActive(true);
        bt5.SetActive(true);
    }
        public void GrowTransActive()
    {
        growButtonTr.transform.localPosition = new Vector3Int(70,-60,53);       
        //operationButtonTr.transform.localPosition = new Vector3Int(2000,2000,2000);
        restButtonTr.transform.localPosition = new Vector3Int(2000,2000,2000);
        bt1.SetActive(true);
        bt2.SetActive(true);
        bt3.SetActive(true);
        bt4.SetActive(true);
    }

    public void OperationTransEnActive()
    {
        bt1.SetActive(false);
        bt2.SetActive(false);
        bt3.SetActive(false);
        bt4.SetActive(false);
        bt5.SetActive(false);
    }

    public void GrowTransEnActive()
    {
        bt1.SetActive(false);
        bt2.SetActive(false);
        bt3.SetActive(false);
        bt4.SetActive(false);
    }
}
