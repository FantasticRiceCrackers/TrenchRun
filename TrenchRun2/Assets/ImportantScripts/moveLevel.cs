using UnityEngine;
using System.Collections;

public class moveLevel : MonoBehaviour {

	public float speed;

	private void Update()
	{
		transform.Translate(Vector3.down * speed * Time.deltaTime);
	}
}
