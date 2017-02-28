using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissleLauncher : MonoBehaviour {

    public GameObject missle;
    public int fireRate;
    public float missleSpeed;
    private bool notUsable = false;

    private IEnumerator BurstFire()
    {
        float shortBurstDelay = 0f;
        if(notUsable == false)
        {
            shortBurstDelay = 0.5f;
            notUsable = true;
        }

        if(notUsable == true)
        {
            while (shortBurstDelay > 0f)
            {
                shortBurstDelay -= Time.deltaTime;
                yield return null;
            }
            for (int i = 0; i < fireRate; i++)
            {
                GameObject instance = Instantiate(missle, new Vector3(transform.position.x, transform.position.y, transform.position.z + 5f), Quaternion.identity);
                instance.AddComponent<objectProperties>().speed = missleSpeed;
                instance = null;
            }
        }
        StopAllCoroutines();
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(BurstFire());
        }
    }
}

public class objectProperties : MonoBehaviour
{
    public float speed = 2000f;
    public bool isMovingUp = true; 

    private void Update()
    {
        if(isMovingUp)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Enemy")
        {
            Destroy(col.gameObject);
            Destroy(this.gameObject);
        }
    }
}
