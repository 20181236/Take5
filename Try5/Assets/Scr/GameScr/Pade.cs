using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

public class Pade : MonoBehaviour
{
    public GameObject FadePannel;

public IEnumerator FadeInStart()
{
    FadePannel.SetActive(true);
    for (float f = 2f; f > 0; f -= 0.02f)
    {
        Color c = FadePannel.GetComponent<Image>().color;
        c.a = f;
        FadePannel.GetComponent<Image>().color = c;
        yield return null;
    }
    yield return new WaitForSeconds(0.5f);
    FadePannel.SetActive(false);
}
    public void fade()
    {
        StartCoroutine(FadeInStart());
    }
}
