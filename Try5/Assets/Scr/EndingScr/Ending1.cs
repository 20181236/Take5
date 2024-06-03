using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Ending1 : MonoBehaviour
{
    public TMP_Text textField; // 텍스트 필드

    private string fullText = "어린 왕자는 지혜롭고 현명한 통치자로 성장하면서  국민들의 삶을 풍요롭게 만드는 데 성공했습니다. 그의 노력과 결단력 덕분에 나라는 전례 없는 번영과 평화를 누리게 되었습니다.\r\n\r\n왕궁 대연회장에는 다양한 신하들과 국민들이 모여 있습니다. 연회장은 밝은 등불로 빛나고  모두가 축제 분위기 속에 있습니다. 어린 왕자는 연단에 서서 환한 미소를 지으며 연회장에 모인 이들을 바라봅니다. 신하들과 국민들은 어린 왕자를 향해 박수를 치며 환호합니다.\r\n재무 대신은 어린 왕자 곁에 서서 나라의 재산이 어떻게 축적되었고  이를 통해 이루어진 발전을 설명하였고  과학 대신은 새로운 농업 기술과 발명품들로 인한 식량 생산의 증가를 보고하였으며  종교 대신은 복구된 신전과 신의 축복을 언급하며  국민들이 더욱 신앙심을 가지게 되었음을 전했습니다.\r\n연단에서 내려온 어린 왕자는 신하들과 함께 앞으로의 계획을 논의합니다. 그들은 모든 분야에서 균형 잡힌 발전을 이루기로 다짐하였고  과학  정치  병력  종교 등 모든 면에서의 조화로운 발전을 목표로 했습니다.\r\n새로 지어진 학교와 병원  깨끗한 도로와 다리가 보입니다. 아이들은 웃으며 아카데미에서 공부하고  농부들은 풍성한 수확을 거두고 있으며  국민들은 서로 도우며 행복한 생활을 하고 있습니다. 이 모든 것은 어린 왕자의 현명한 통치 덕분입니다.\r\n왕궁 발코니에서 어린 왕자는 국민들을 바라봅니다. 국민들은 어린 왕자를 향해 환호하고  그들의 얼굴에는 행복과 만족이 가득해 보입니다. 어린 왕자는 미소를 지으며 그들에게 손을 흔듭니다. \r\n국민들이 행복하게 생활하는 모습이 보입니다. 어린 왕자는 만족스러운 미소를 지으며 나라의 밝은 미래를 내다봅니다.";
    private int currentIndex = 0; // 현재 인덱스

    void Start()
    {
        if (textField != null)
        {
            textField.text = ""; // 텍스트 필드 초기화
            InvokeRepeating("DisplayNextChar", 0.03f, 0.03F); // 0.5초마다 다음 문자 표시
        }
        else
        {
            Debug.LogError("텍스트 필드가 설정되지 않았습니다!");
        }
    }

    // 다음 문자 표시
    void DisplayNextChar()
    {
        if (currentIndex < fullText.Length)
        {
            textField.text += fullText[currentIndex];
            currentIndex++;
        }
        else
        {
            // 모든 문자 표시 완료 시 반복 중지
            CancelInvoke("DisplayNextChar");
        }
    }
}
