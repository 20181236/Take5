using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlinkAnim : MonoBehaviour
{
    public float blinkSpeed = 0.5f; // 블링크 속도
    private float timer = 0f;
    private bool isVisible = true; // 현재 보이는지 여부

    public Text textComponent;

    void Start()
    {
        textComponent = GetComponent<Text>();
    }

    void Update()
    {
        // 타이머 업데이트
        timer += Time.deltaTime;

        // 블링크 타이밍 확인
        if (timer >= blinkSpeed)
        {
            // 보이는 상태면 숨기고, 그 반대도 마찬가지
            isVisible = !isVisible;
            textComponent.enabled = isVisible;

            // 타이머 리셋
            timer = 0f;
        }
    }
}
