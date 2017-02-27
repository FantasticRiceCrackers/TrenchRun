using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour {

    private float instanceHorizontalRight, instanceVerticalRight;
    public Transform tempObject;
    public float speed = 1000, offset = 4f;

    private void Update()
    {
        instanceHorizontalRight = direction("Horizontal_Right");
        instanceVerticalRight = direction("Vertical_Right");

        Movement(-instanceHorizontalRight * offset, -instanceVerticalRight * offset);
    }

    public void Movement(float Horizontal, float Vertical)
    {
        if (tempObject != null)
        {
            tempObject.position = new Vector3(transform.position.x + Horizontal
                        , transform.position.y -12.3f, transform.position.z + Vertical);
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