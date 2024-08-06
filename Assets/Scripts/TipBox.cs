using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipBox : MonoBehaviour
{
    public string message;

    private void OnMouseEnter()
    {
        TipBoxManager._instance.SetAndShowTip(message);
    }

    private void OnMouseExit()
    {
        TipBoxManager._instance.HideTip();
    }
}
