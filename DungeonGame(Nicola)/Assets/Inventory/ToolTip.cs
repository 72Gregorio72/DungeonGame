using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ToolTip : MonoBehaviour
{

    public TextMeshProUGUI detailText;
    public void Start()
    {
        gameObject.SetActive(false);
    }

    public void ShowToolTip()
    {
        gameObject.SetActive(true);
    }

    public void HideToolTip()
    {
        gameObject.SetActive(false);
    }

    public void UpdateToolTip(string _detailText)
    {
        detailText.text = _detailText;
    }

    public void SetPosition(Vector2 _pos){
        transform.localPosition = _pos;
    }
}
