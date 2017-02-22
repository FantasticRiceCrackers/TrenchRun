using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour {

    public float CompleteHealth;
    public float damageMultipler;
    public Slider healthBar;

    public void Start()
    {
        if(healthBar != null)
        {
            healthBar.maxValue = CompleteHealth;
        }
    }

    public void Update()
    {
        if(healthBar != null)
        {
            healthBar.value = CompleteHealth;
        }
    }

    public void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "obstacle")
        {
            CompleteHealth -= damageMultipler;
        }
    }

    public void OnTriggerEnter(Collider col)
    {
        if (col.tag == "obstacle")
        {
            CompleteHealth -= damageMultipler * 2f;
        }
        if (col.tag == "Enemy")
        {
            CompleteHealth -= damageMultipler * 2f;
        }
    }
}