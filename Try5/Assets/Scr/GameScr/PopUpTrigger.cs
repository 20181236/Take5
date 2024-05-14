// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class PopUpTrigger : MonoBehaviour
// {
//     // 팝업창에 나올 메세지 json 연결필요
//     public string _popupMsg;

//     // 팝업창이 나오게 하는 트리거 버튼이벤트라 생각
//     public void OnClickTrigger()
//     {
//         PopUpManager.Instance.Open(_popupMsg,
//            OnClickConformButton: () =>
//         {
//             Debug.Log("On Trigger Conform Button");

//         }, OnClickCancelButton: () =>
//         {
//             Debug.Log("On Click Cancel Button");
//         });
//     }
//     // Start is called before the first frame update
//     void Start()
//     {

//     }

//     // Update is called once per frame
//     void Update()
//     {

//     }

// }
