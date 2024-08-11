using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class TipBoxManager : MonoBehaviour
{
    public static TipBoxManager _instance;
    public TextMeshProUGUI tipText;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }


    void Start()
    {
        Cursor.visible = true;
        gameObject.SetActive(false);
    }

    void Update()
    {
        transform.position = Input.mousePosition;
    }

    public void SetAndShowTip(string message)
    {
        gameObject.SetActive(true);
        tipText.text = message;
    }

    public void HideTip()
    {
        gameObject.SetActive(false);
        tipText.text = string.Empty;
    }
}
