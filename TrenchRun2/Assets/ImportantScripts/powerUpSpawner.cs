using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUpSpawner : MonoBehaviour {

    public Transform node1, node2;
    public float resetTimer, mainX, mainZ, powerUpSpeed;
    public int spawnAmount;
    public List<GameObject> powerUps;
    private int isMovingUp;

    private void Start()
    {
        StartCoroutine(delay());
    }

    private IEnumerator delay()
    {
        float timer = resetTimer;
        while(timer > 0)
        {
            timer -= Time.deltaTime;
            yield return null;
        }
        for(int i = 0; i < spawnAmount; i++)
        {
            isMovingUp = 0;
            GameObject instance = Spawn(returnRandomPos(mainX),returnRandomPos(mainZ)
                , isMovingUp, returnRandomObject(powerUps));
            objectInfo prop = instance.AddComponent<objectInfo>();
            instance = null;
            prop.isMovingUp = isMovingUp;
            prop.speed = powerUpSpeed;
            prop = null;
        }

        Loop();
    }

    private GameObject returnRandomObject(List<GameObject> size)
    {
        int determin = (int)Random.Range(0, size.Count);
        return size[determin];
    }

    private float returnRandomPos(float value)
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

    private void Loop()
    {
        StopAllCoroutines();
        StartCoroutine(delay());
    }
}

public class objectInfo : MonoBehaviour
{
    public int isMovingUp = 0;
    public float speed;

    private void Update()
    {
        if (isMovingUp == 0)
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
    }
    //this class cantains all the info for the power up and its abilits

}
