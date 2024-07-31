using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    [SerializeField]
    private float timerDeah;
    void Start()
    {
        Destroy(this.gameObject,timerDeah);
    }

    
}
