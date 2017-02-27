using UnityEngine;
using System.Collections;

public class nodeMovement : MonoBehaviour {

    public float speed;

    private void Update()
	{
		if(!Input.GetKey(KeyCode.UpArrow) || !Input.GetKey(KeyCode.DownArrow) || !Input.GetKey(KeyCode.LeftArrow) || !Input.GetKey(KeyCode.RightArrow))
		{
			if(direction("Vertical") > 0 || direction("Vertical") < 0)
			{
				transform.Translate(transform.forward * direction("Vertical") * speed);
			}
			if(direction("Horizontal") > 0 || direction("Horizontal") < 0)
			{
				transform.Translate(-transform.right * -direction("Horizontal") * speed);
			}
		}
	}

	public float direction(string movementName)
	{
		return Input.GetAxis(movementName);
	}
}