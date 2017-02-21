using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    //215 Z
    //120 X
    public float xValue, yValue;
    public float maxTime, fallSpeed;
    public Transform node1, node2;
    public int spawnAmount;
    public GameObject enemey;
    private int stateSwitcher;
    private float timer; 

    private void Start()
    {
        //timer = 3f;
        StartCoroutine(Generate());
    }

    private IEnumerator Generate()
    {
        while(timer > 0f)
        {
            timer -= Time.deltaTime;
            yield return null;
        }
        for(int i =0; i < spawnAmount; i++)
        {
            stateSwitcher = (int)returnRandom(2);
            GameObject instance = Spawn(returnRandom(xValue), returnRandom(yValue), stateSwitcher, enemey);
            EnemyClass instanceOfEnemy = instance.AddComponent<EnemyClass>();
            instanceOfEnemy.value = stateSwitcher;
            instanceOfEnemy.speed = fallSpeed;
            instanceOfEnemy = null;
            instance = null;
        }
        loop();
    }

    private void loop()
    {
        StopCoroutine(Generate());
        timer = maxTime;
        StartCoroutine(Generate());
    }

    private float returnRandom(float value)
    {
        return Random.Range(-value, value);
    }

    private GameObject Spawn(float x, float z, int isTop, GameObject obj)
    {
        if (isTop == 0)
        {
            return Instantiate(obj, new Vector3(node1.transform.position.x + x, node1.transform.position.y, node1.transform.position.z + z), Quaternion.identity);
        }
        return Instantiate(obj, new Vector3(node1.transform.position.x + x, node2.transform.position.y, node1.transform.position.z + z), Quaternion.identity);
    }
}

public class EnemyClass : MonoBehaviour
{
    public bool comingFromTop;
    public float value, speed = 30f;

    private void Start()
    {
        if (value != 0)
        {
            comingFromTop = false;
        }
        else
        {
            comingFromTop = true;
        }
    }

    private void Update()
    {
        if(comingFromTop)
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
    }
}