using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    public delegate void SetTest12(int value);
    public static event SetTest12 ST12;
    
    int testInt1=0;
    int testInt2=0;

    public void SetTestInt1(int value)
    {
        testInt1 += value;
        print("testInt1의 값" + value + "만큼증가. 총 testInt1 값 = " + testInt1);
    }
    public void SetTestInt2(int value)
    {
        testInt2 += value;
        print("testInt2의 값" + value + "만큼증가. 총 testInt2 값 = " + testInt2);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        ST12 += SetTestInt1;
        ST12 += SetTestInt2;


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnButtonClicked()
    {
        if(ST12!=null)
        ST12(5);
    }
}
