using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpDamage : MonoBehaviour
{
    public Vector2 InitialVelocity;
    public Rigidbody2D rb;
    public float lifeTime = 1.5f;

    void Start()
    {
        rb.velocity = InitialVelocity;
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}