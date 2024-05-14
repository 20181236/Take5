using System;
using UnityEngine;
using UnityEngine.UI;

public class PopUpManager : MonoBehaviour
{
    private Action _onClickConfirmButton;
    private Action _onClickCancelButton;

    private static PopUpManager _popUpInstance;

    public static PopUpManager Instance
    {
        get { return _popUpInstance; }
    }

    public GameObject popUpObj;
    public Text popMsg;

    private void Awake()
    {
        if (_popUpInstance != null && _popUpInstance != this)
        {
            Destroy(gameObject);
            return;
        }

        _popUpInstance = this;
        DontDestroyOnLoad(gameObject);
        popUpObj.SetActive(false);
    }

    public void Open(string text, Action onConfirmButtonAction, Action onCancelButtonAction)
    {
        popUpObj.SetActive(true);
        popMsg.text = text;
        _onClickConfirmButton = onConfirmButtonAction;
        _onClickCancelButton = onCancelButtonAction;
    }

    public void Close()
    {
        popUpObj.SetActive(false);
    }

    public void OnClickConfirmButton()
    {
        if (_onClickConfirmButton != null)
        {
            Debug.Log("확인 버튼 클릭");
            _onClickConfirmButton.Invoke();
        }
        Close();
    }

    public void OnClickCancelButton()
    {
        if (_onClickCancelButton != null)
        {
            Debug.Log("취소 버튼 클릭");
            _onClickCancelButton.Invoke();
        }
        Close();
    }
}
