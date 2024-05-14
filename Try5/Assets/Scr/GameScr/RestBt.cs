using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestBt : MonoBehaviour
{
    public GameObject restObj;
    public GameObject restPageObj; // RestPage 오브젝트를 Inspector에서 할당할 변수
    public GameObject restOkBtObj;//OkBt 오브젝트를 Inspector에서 할당할 변수
    public GameObject reCheckObj;

    void Start()
    {
        reCheckObj.SetActive(false);
    }
    void Awake()
    {
        restPageObj.SetActive(false);
        reCheckObj.SetActive(false);
    }

    public void OnRestClick()
    {
        restObj.SetActive(true);
        ActivateAllChildren(restPageObj);
        restPageObj.SetActive(true); // RestPage 오브젝트 활성화
        restOkBtObj.SetActive(true);

    }
    public void OnRestOkClick()
    {
        float ifStamina = Stat.instance.stamina;
        ifStamina += 30;

        if (ifStamina < 100)
        {
            StaminaRecovery();
            Debug.Log("100아허 눌림");
        }
        else if (ifStamina >= 100)
        {
            reCheckObj.SetActive(true);
            ActivateAllChildren(reCheckObj);
            Debug.Log("100이상 눌림");
        }
    }
    public void OnRestReCheckOKClick()
    {
        StaminaRecovery();
        restPageObj.SetActive(false);
        reCheckObj.SetActive(false);
        Stat.instance.stamina = 100;
    }
    public void OnRestCancelClick()
    {
        restPageObj.SetActive(false);
        reCheckObj.SetActive(false);
    }
    public void StaminaRecovery()
    {
        Stat.instance.stamina += 30;
        Stat.instance.curTurn -= 1;
        Stat.instance.countingTurn += 1;
        OnRestCancelClick();
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
}