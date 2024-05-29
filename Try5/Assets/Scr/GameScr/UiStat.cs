using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiStat : MonoBehaviour
{
    public Text displayText0;
    public Text displayText1;
    public Text displayText2;
    public Text displayText3;
    public Text displayText4;

    //     public Text displayText5;
    //     public Text displayText6;
    //     public Text displayText7;
    

    public Text displayTrunText;
    public Text displayCountingTurn;

    public Slider staminaSlider;

    // Start is called before the first frame update
    void Update()
    {
        UpdateUiText();
        UpdateUiSlider();
    }

    void UpdateUiText()
    {
        //     // 변수들을 텍스트로 변환하여 Text UI 요소에 할당
        //     displayText0.text = Stat.instance.HP+"/"+Stat.instance.maxHP;//.ToString();
        //     displayText1.text = Stat.instance.intel+"/"+Stat.instance.maxIntel;
        //     displayText2.text = Stat.instance.leader+"/"+Stat.instance.maxLeader;
        //     displayText3.text = Stat.instance.wisdom+"/"+Stat.instance.maxWisdom;

        displayText0.text = Stat.instance.money.ToString();
        displayText1.text = Stat.instance.army.ToString();
        displayText2.text = Stat.instance.faith.ToString();
        displayText3.text = Stat.instance.science.ToString();
        displayText4.text = Stat.instance.politics.ToString();

        displayTrunText.text = Stat.instance.curTurn.ToString();
        displayCountingTurn.text=Stat.instance.countingTurn.ToString();
    }

    void UpdateUiSlider()
    {
        staminaSlider.value = Stat.instance.stamina;
    }
}
