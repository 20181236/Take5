using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class StatGage : MonoBehaviour
{
    // Radar chart 컴포넌트
    public RadarChart radarChart;

    // Stat 속성들
    public int tmp_Money = 0;
    public int tmp_Army = 0;
    public int tmp_Faith = 0;
    public int tmp_Science = 0;
    public int tmp_Politics = 0;


    public float lerpDuration = 2f;

    // Start는 첫 프레임 업데이트 전에 호출됩니다.
    void Start()
    {
        radarChart = GetComponent<RadarChart>();

        // 레이더 차트 데이터를 초기화합니다.
        InitializeRadarChart();
    }

    // Update는 매 프레임마다 호출됩니다.
    void LateUpdate()
    {
        // 필요에 따라 동적으로 레이더 차트를 업데이트합니다.
        //UpdateRadarChart();
    }

    public void StatUpdate()
    {
        // 현재 stat 값을 사용하여 레이더 차트를 업데이트합니다.
        //UpdateRadarChart();
    }

    public void InitializeRadarChart()
    {
        // graphData를 레이더 차트의 데이터로 설정합니다.
        radarChart.data[0].values = new List<float> { Stat.instance.money / 1000f, Stat.instance.army / 1000f, Stat.instance.faith / 1000f, Stat.instance.science / 1000f, Stat.instance.politics / 1000f };

        // 새로운 데이터를 반영하도록 레이더 차트를 업데이트합니다.
        radarChart.SetVerticesDirty();
    }

    public void BeforeUpdateRadarChart()
    {
        tmp_Money = Stat.instance.money;
        tmp_Army = Stat.instance.army;
        tmp_Faith = Stat.instance.faith;
        tmp_Science = Stat.instance.science;
        tmp_Politics = Stat.instance.politics;
    }
    public IEnumerator AfterUpdateRadarChart()
    {
        float lerpedValue = 0f;
        if (radarChart.data.Count > 0)
        {
            // 기존 graph 데이터 값을 업데이트합니다.
            //radarChart.data[0].values = new List<float> { Stat.instance.money / 1000f, Stat.instance.army / 1000f, Stat.instance.faith / 1000f, Stat.instance.science / 1000f, Stat.instance.politics / 1000f };
            while (lerpedValue<2.0f)
            {
                lerpedValue += Time.deltaTime;// * 0.1f;
                radarChart.SetVerticesDirty();
                radarChart.data[0].values[0] = Mathf.Lerp(tmp_Money / 1000f, Stat.instance.money / 1000f, Time.deltaTime * 2f);
                radarChart.data[0].values[1] = Mathf.Lerp(tmp_Army / 1000f, Stat.instance.army / 1000f, Time.deltaTime * 2f);
                radarChart.data[0].values[2] = Mathf.Lerp(tmp_Faith / 1000f, Stat.instance.faith / 1000f, Time.deltaTime * 2f);
                radarChart.data[0].values[3] = Mathf.Lerp(tmp_Science / 1000f, Stat.instance.science / 1000f, Time.deltaTime * 2f);
                radarChart.data[0].values[4] = Mathf.Lerp(tmp_Politics / 1000f, Stat.instance.politics / 1000f, Time.deltaTime * 2f);
                yield return null;
            }

        }
    }
}