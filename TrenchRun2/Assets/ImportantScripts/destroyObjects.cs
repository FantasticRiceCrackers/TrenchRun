using UnityEngine;
using System.Collections;

public class destroyObjects : MonoBehaviour {

	public LayerMask currentLayer;

	void OnTriggerEnter(Collider col)
	{
		Destroy(col.gameObject);
	}
}
