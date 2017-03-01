using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour {

    private float instanceHorizontalRight, instanceVerticalRight;
    public Transform tempObject, missleObject;
    public float offset = 4f;
    private MissleLauncher2 missleInformation;

    private void Start()
    {
        missleInformation = this.gameObject.AddComponent<MissleLauncher2>();//this class is the missle launch information for player 2
        missleInformation.fireRate = 1;
        missleInformation.parentObject = tempObject.gameObject;
        missleInformation.missle = missleObject.gameObject;
    }

    private void Update()
    {
        if(missleInformation != null)
        {
            instanceHorizontalRight = direction("Horizontal_Right");
            instanceVerticalRight = direction("Vertical_Right");
            missleInformation.Horizontal = instanceHorizontalRight;
            missleInformation.Vertical = instanceVerticalRight;

            Movement(-instanceHorizontalRight * offset, -instanceVerticalRight * offset);
        }
    }

    public void Movement(float Horizontal, float Vertical)
    {
        if (tempObject != null)
        {
            tempObject.position = new Vector3(transform.position.x + Horizontal
                        , transform.position.y -100f, transform.position.z + Vertical);
        }
    }

    private bool checkDistanceAway(float value,float distanceAway)
    {   
        if(value <= distanceAway || value <= -distanceAway)
        {
            return true;
        }
        return false;
    }

    public float direction(string movementName)
    {
        return Input.GetAxis(movementName);
    }

    private bool Checker(float direction, float stage1)
    {
        if (direction >= stage1 || direction <= -stage1)
        {
            return true;
        }
        return false;
    }
}

public class MissleLauncher2 : MonoBehaviour
{
    public GameObject missle, parentObject;//parent object is the retical
    public float Horizontal, Vertical;
    //public float speed;
    public int fireRate;
    private bool notUsable = false;
    private Transform parentOfRetical;

    private void Start()
    {
        parentOfRetical = parentObject.transform.parent;
    }

    public void Update()
    {
        if(parentObject != null)
        {
            if(Input.GetKeyDown(KeyCode.T))
            {
                StartCoroutine(BurstFire());
            }
        }
    }

    private IEnumerator BurstFire()
    {
        float shortBurstDelay = 0f;
        if (notUsable == false)
        {
            shortBurstDelay = 0.5f;
            notUsable = true;
        }

        if (notUsable == true)
        {
            while (shortBurstDelay > 0f)
            {
                shortBurstDelay -= Time.deltaTime;
                yield return null;
            }
            for (int i = 0; i < fireRate; i++)
            {
                //so i want the object to spawn infront of ship and move in the direction of the retical
                GameObject instance = Instantiate(missle, new Vector3(parentOfRetical.position.x, parentOfRetical.position.y - 5f, parentOfRetical.position.z + 10f), Quaternion.identity);
                MoveInDirection prop = instance.AddComponent<MoveInDirection>();
                instance = null;
                prop.reticalInformation = parentObject.transform;
                prop.speed = 10f;
                prop = null;
            }
        }
        StopAllCoroutines();
    }
}

public class MoveInDirection : MonoBehaviour
{
    public Transform reticalInformation;
    public float speed, timer = 5f;
    private Vector3 instanceOfDirection;
    private void Start()
    {
        instanceOfDirection = reticalInformation.position - transform.position;
        reticalInformation = null;
    }
    //pretty much we want the object to move on a angle
    private void Update()
    {
        transform.Translate(instanceOfDirection * speed * Time.deltaTime);
    }

    private IEnumerator selfDestruct()
    {
        while(timer > 0)
        {
            timer -= Time.deltaTime;
            yield return null;
        }
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Enemy")
        {
            Destroy(col.gameObject);
            Destroy(this.gameObject);
        }
    }
}