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
                GameObject instance = Instantiate(missle, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                instance.AddComponent<objectPorperties>().speed = missleSpeed;
            }
        }
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(BurstFire());
        }
    }
}

public class objectPorperties : MonoBehaviour
{
    public float speed;

    private void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
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
