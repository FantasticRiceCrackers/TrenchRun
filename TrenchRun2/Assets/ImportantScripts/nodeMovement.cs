using UnityEngine;
using System.Collections;

public class nodeMovement : MonoBehaviour {

    public float speed;
    private float instanceHorizontal, instanceVertical;


    private void Update()
	{
        instanceHorizontal = direction("Horizontal_Left");
        instanceVertical = direction("Vertical_Left");


        if (!Input.GetKey(KeyCode.UpArrow) || !Input.GetKey(KeyCode.DownArrow) || !Input.GetKey(KeyCode.LeftArrow) || !Input.GetKey(KeyCode.RightArrow))
		{
            if(Checker(instanceVertical,0.1f))
            {
				transform.Translate(transform.forward * -instanceVertical * speed);
            }
            if (Checker(instanceHorizontal, 0.1f))
            {
				transform.Translate(-transform.right * -instanceHorizontal * speed);
			}

		}
	}

    private bool Checker(float direction, float stage1)
    {
        if (direction >= stage1 || direction <= -stage1)
        {
            return true;
        }
        return false;
    }

    public float direction(string movementName)
	{
		return Input.GetAxis(movementName);
	}
}