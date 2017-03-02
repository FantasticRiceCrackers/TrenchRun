using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissleLauncher : MonoBehaviour {

    public GameObject missle;
    public Transform ReticalPosition;
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
                GameObject instance = Instantiate(missle, new Vector3(transform.position.x, transform.position.y + 5f, transform.position.z), Quaternion.identity);
                MoveInDirection prop = instance.AddComponent<MoveInDirection>();
                instance = null;
                prop.reticalInformation = ReticalPosition;
                prop.speed = 10f;
                prop = null;
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